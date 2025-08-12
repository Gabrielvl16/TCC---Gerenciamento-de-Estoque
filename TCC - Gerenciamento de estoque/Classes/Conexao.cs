using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SistemaLoja
{
    public class Conexao
    {
        private static string servidor = "localhost";
        private static string bancoDados = "loja_roupas_2_0"; 
        private static string usuario = "root";
        private static string senha = "";

        private static string stringConexao = $"server={servidor};user={usuario};database={bancoDados};password={senha};SslMode=none";

        public MySqlConnection Conectar()
        {
            var conexao = new MySqlConnection(stringConexao);
            try
            {
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                return null;
            }
        }
    }
}