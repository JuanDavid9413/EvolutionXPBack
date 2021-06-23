using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackEnd.EvolutionXP.Entities.DbSet
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameRound { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
