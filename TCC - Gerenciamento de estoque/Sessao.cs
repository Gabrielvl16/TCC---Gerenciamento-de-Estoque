using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC___Gerenciamento_de_estoque
{
    public static class Sessao
    {
        public static int Id { get; set; }
        public static string Nome { get; set; }
        public static string Email { get; set; }
        public static string Usuario { get; set; }
        public static byte[] Imagem { get; set; }
        public static string NivelAcesso { get; set; }
    }
}
