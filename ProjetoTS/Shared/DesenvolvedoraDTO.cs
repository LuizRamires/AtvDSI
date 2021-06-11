using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoTS.Shared
{
    public class DesenvolvedoraDTO
    {
        public string IdDesenvolvedora { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Game> Game { get; set; }

    }
}
