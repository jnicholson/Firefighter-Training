using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.HalonModels
{
    public class State
    {
        [Key, Required, Display(Name = "State ID")]
        public int State_ID { get; set; }

        [Required, Display(Name = "State Abb.")]
        public string State_Abbreviation { get; set; }

        [Required, Display(Name = "State Name")]
        public string State_Name { get; set; }

        //Counties
        public virtual List<County> Counties { get; set; }
    }
}