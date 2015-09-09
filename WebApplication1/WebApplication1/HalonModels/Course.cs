using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.HalonModels
{
    public class Course
    {
        [Key, Required, Display(Name = "Course ID")]
        public int Course_ID { get; set; }

        [Required, StringLength(50), Display(Name = "Course Name")]
        public string Course_Name { get; set; }

        [Required, Display(Name = "Course Discontinued")]
        public bool Course_Discontinued { get; set; }

        [Required, Display(Name = "Course Credit Hours")]
        public string Course_Credit_Hours { get; set; }

        //Classes
        public virtual List<Class> Classes { get; set; }
    }
}