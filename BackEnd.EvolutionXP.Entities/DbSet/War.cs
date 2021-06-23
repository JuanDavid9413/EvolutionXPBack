using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackEnd.EvolutionXP.Entities.DbSet
{
    public class War
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Players")]
        public string Id_Player {get; set;}
        public Players Players { get; set; }
        [ForeignKey("Game")]
        public int Id_Game { get; set; }
        public Game Game { get; set; }
        [ForeignKey("Movimients")]
        public int Id_Movimient { get; set; }
        public Movimients Movimients { get; set; }
        public int Round { get; set; }
    }
}
