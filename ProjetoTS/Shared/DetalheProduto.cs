using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoTS.Shared
{
    public class DetalheGame
    {
        public string Descricao { get; set; }
        public string TempoDeUso { get; set; }
        public string EstadodeConservacao { get; set; }


        public int IdGame { get; set; }
        public Game Game { get; set; }
    }
}
