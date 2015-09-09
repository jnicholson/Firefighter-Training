using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.HalonModels
{
    public class County
    {
        [Key, Required, Display(Name = "County ID")]
        public int County_ID { get; set; }

        [Required, Display(Name = "County Name")]
        public string County_Name { get; set; }

        //Foreign Key
        [Required, Display(Name = "State ID")]
        public int? State_ID { get; set; }

        //Departments
        public virtual List<Department> Departments { get; set; }

        //Firefighters
        public virtual List<Firefighter> Firefighters { get; set; }

        public virtual State state { get; set; }
    }
}