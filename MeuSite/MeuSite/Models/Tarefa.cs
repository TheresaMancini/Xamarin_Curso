using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSite.Models
{
    public class Tarefa
    {
        public int TarefaID { get; set; } //chave primaria do Banco de Dados
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Finalizado { get; set; }
    }
}
