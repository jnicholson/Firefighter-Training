using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.HalonModels
{
    public class Department
    {
        [Key, Required, Display(Name = "Department ID")]
        public int Dept_ID { get; set; }

        [Required, Display(Name = "Department State ID")]
        public string Dept_FDID { get; set; }

        [Required, StringLength(50), Display(Name = "Department Name")]
        public string Dept_Name { get; set; }

        [StringLength(12), Display(Name = "Department Phone")]
        public string Dept_Tel_No { get; set; }

        [StringLength(25), Display(Name = "Dept_Callsign")]
        public string Dept_Callsign { get; set; }

        [StringLength(100), Display(Name = "Department Street Address")]
        public string Dept_Address { get; set; }

        [StringLength(100), Display(Name = "Department City")]
        public string Dept_City { get; set; }

        [StringLength(100), Display(Name = "Department Zip")]
        public string Dept_Zip { get; set; }

        //Foreign Keys
        [Required, Display(Name = "Chief ID")]
        public int? Firefighter_ID { get; set; } //chief

        public int? County_ID { get; set; }

        //Firefighters
        public virtual List<Firefighter> Firefighters { get; set; }
    }
}