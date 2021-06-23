using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace BackEnd.EvolutionXP.Entities.DbSet
{
    public class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "Id")]
        public string Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Status")]
        public bool Status { get; set; }

        [DataMember(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}
