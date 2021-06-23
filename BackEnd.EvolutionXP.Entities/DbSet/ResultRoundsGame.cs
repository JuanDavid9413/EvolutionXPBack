using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackEnd.EvolutionXP.Entities.DbSet
{
    public class ResultRoundsGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Id_Game")]
        public int Id_Game { get; set; }
        public Game Game { get; set; }
        [ForeignKey("Id_Player")]
        public string Id_Player { get; set; }
        public string Resultado { get; set; }
    }
}
