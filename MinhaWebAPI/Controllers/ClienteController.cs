using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaWebAPI.Models;
using MinhaWebAPI.Util;

namespace MinhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("listagem")]
        public List<ClientesModel> Listagem()
        {
            return new ClientesModel().Listagem();
        }

        // GET api/values/5
        [HttpGet]
        [Route("cliente/{id}")]
        public ClientesModel RetornarCliente (int id)
        {
            return new ClientesModel().RetornarCliente(id);
        
        }

        // POST api/values
        [HttpPost]
        [Route("RegistrarCliente")]
        public ReturnAllServices RegistrarCliente([FromBody]ClientesModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar um cliente " + ex.Message;
            }
            return retorno;
        }

        // PUT api/values/5
        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody]ClientesModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.clienteid = id;
                dados.AtualizarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar um cliente" + ex.Message;
            }
            return retorno;
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("excluir/{id}")]
        public void Excluir(int id)
        {
            new ClientesModel().Excluir(id);
        }
    }
}
