using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ProjetoTS.Shared //CADA PRODUTO PODERA ESTAR LIGADO À VARIAS TAGS
{
    public class Game
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Preco { get; set; }
        public List<TagGame> TagGame { get; set; }//lista de tags que o game vai ter
        public DetalheGame DetalheGame { get; set; }//Relacao 1 para 1
        public int IdDesenvolvedora { get; set; }
        public Desenvolvedora Desenvolvedora { get; set; }
    }
}
