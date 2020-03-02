using MinhaWebAPI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebAPI.Models
{
    public class ClientesModel
    {
        public int clienteid { get; set; }
        public string nome { get; set; }
        public string agencia { get; set; }
        public string conta { get; set; }

        public void RegistrarCliente()
        {
            DAL objDAL = new DAL();
            string sql = "insert into projeto1.clientes(nome, agencia, conta) " +
                        $"VALUES('{nome}','{agencia}','{conta}')";
            objDAL.ExecutarComandoSQL(sql);
        }

        public List<ClientesModel> Listagem()
        {
            List<ClientesModel> lista = new List<ClientesModel>();
            ClientesModel item;

            DAL objDAL = new DAL();
            string sql = "SELECT * FROM clientes order by nome asc";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClientesModel()
                {
                    clienteid = int.Parse(dados.Rows[i]["idclientes"].ToString()),
                    nome = dados.Rows[i]["nome"].ToString(),
                    agencia = dados.Rows[i]["agencia"].ToString(),
                    conta = dados.Rows[i]["conta"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public ClientesModel RetornarCliente(int id)
        {
            ClientesModel item;
            DAL objDAL = new DAL();

            string sql = $"SELECT * FROM clientes where idclientes = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);

            item = new ClientesModel()
            {
                clienteid = int.Parse(dados.Rows[0]["idclientes"].ToString()),
                nome = dados.Rows[0]["nome"].ToString(),
                agencia = dados.Rows[0]["agencia"].ToString(),
                conta = dados.Rows[0]["conta"].ToString()
            };
            return item;
        }

        public void AtualizarCliente()
        {
            DAL objDAL = new DAL();
            string sql = "UPDATE projeto1.clientes SET " +
                         $"nome ='{nome}'," +
                         $"agencia = '{agencia}'," +
                         $"conta = '{conta}' where idclientes={clienteid}";
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"DELETE from projeto1.clientes WHERE idclientes = {id}";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
