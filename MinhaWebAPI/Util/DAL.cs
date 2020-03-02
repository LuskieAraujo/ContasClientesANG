using MySql.Data.MySqlClient;
using System.Data;

namespace MinhaWebAPI.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "projeto1";
        private static string User = "root";
        private static string Password = "129783";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={Database};User={User};Password={Password};charset=utf8";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();

        }

        public void ExecutarComandoSQL (string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();

        }

        public DataTable RetornarDataTable (string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdapter.Fill(Dados);
            return Dados;

        }
    }
}
