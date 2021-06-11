using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ProjetoTS.Shared
{
    public class TagGame
    {
        public int Id { get; set; }//id do game
        public int TagId { get; set; }
        public Tag tag { get; set; }
        public Game game { get; set; }

    }
}
