using System.ComponentModel.DataAnnotations;

namespace WebApplication1.HalonModels
{
    public class Enrollment
    {
        [Key, Required, Display(Name = "Enrollment ID")]
        public int Enrollment_ID { get; set; }

        //Foreign Key
        [Required, Display(Name = "Student ID")]
        public int? Firefighter_ID { get; set; }

        [Required, Display(Name = "Class ID")]
        public int? Class_ID { get; set; }

        public virtual Class Class { get; set; }

        public virtual Firefighter Firefighter { get; set; }
    }
}