using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.HalonModels
{
    public class Class
    {
        [Key, Required, Display(Name = "Class ID")]
        public int Class_ID { get; set; }

        [Required, Display(Name = "Class Date")]
        public string Class_Date { get; set; }

        [StringLength(250), Display(Name = "Class Note")]
        public string Class_Note { get; set; }

        [Display(Name = "Class Cancelled")]
        public bool Class_Cancelled { get; set; }

        //Foreign Key
        [Required, Display(Name = "Instructor ID")]
        public int? Firefighter_ID { get; set; }

        [Required, Display(Name = "Course ID")]
        public int? Course_ID { get; set; }

        public virtual Course Course { get; set; }

        //Enrollments
        public virtual List<Enrollment> Enrollments { get; set; }
    }
}