using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.HalonModels
{
    public class Firefighter
    {
        [Key, Required, ScaffoldColumn(false)]
        public int Firefighter_ID { get; set; }

        [Required, StringLength(50), Display(Name = "First Name")]
        public string Firefighter_Fname { get; set; }

        [Required, StringLength(50), Display(Name = "Last Name")]
        public string Firefighter_Lname { get; set; }

        [StringLength(1), Display(Name = "Middle Initial")]
        public string Firefighter_MI { get; set; }

        [StringLength(10), Display(Name = "Callsign")]
        public string Firefighter_Callsign_ID { get; set; }

        [StringLength(100), Display(Name = "Rank")]
        public string Firefighter_Rank { get; set; }

        [StringLength(1), Display(Name = "Gender")]
        public string Firefighter_Gender { get; set; }

        [StringLength(10), Display(Name = "Date of Birth")]
        public string Firefighter_DOB { get; set; }

        [StringLength(100), Display(Name = "Race")]
        public string Firefighter_Race { get; set; }

        [StringLength(100), Display(Name = "Driver's Licence")]
        public string Firefighter_DL_Num { get; set; }

        [StringLength(100), Display(Name = "Street Address")]
        public string Firefighter_Address { get; set; }

        [StringLength(100), Display(Name = "City")]
        public string Firefighter_City { get; set; }

        [Display(Name = "Zip")]
        public string Firefighter_Zip { get; set; }

        [StringLength(100), Display(Name = "Email")]
        public string Firefighter_Email { get; set; }

        [StringLength(12), Display(Name = "Cell Phone")]
        public string Firefighter_Cell_Ph { get; set; }

        [StringLength(12), Display(Name = "Home Phone")]
        public string Firefighter_Home_Ph { get; set; }

        [StringLength(12), Display(Name = "Emergency Phone")]
        public string Firefighter_Emer_Ph { get; set; }

        [Display(Name = "HS Diploma")]
        public bool Firefighter_Diploma { get; set; }

        [Display(Name = "Certified")]
        public bool Firefighter_Cert { get; set; }

        [Display(Name = "EMT Certified")]
        public bool Firefighter_Cert_Emt { get; set; }

        [Display(Name = "Cert Suspension")]
        public bool Firefighter_Cert_Suspensions { get; set; }

        [StringLength(250), Display(Name = "Cert Sus Explaination")]
        public string Firefighter_Cert_Sus_Exp { get; set; }

        [StringLength(100), Display(Name = "Highest Ed. Level")]
        public string Firefighter_High_Ed_Lvl { get; set; }

        [Display(Name = "Retired")]
        public bool Firefighter_Retired { get; set; }

        [Display(Name = "Verified")]
        public bool Firefighter_Verified { get; set; }

        public string Firefighter_Account_Username { get; set; }

        //Foreign Keys
        public int? DL_State_ID { get; set; }

        [Required]
        public int? State_ID { get; set; }

        //[Required]
        public int? County_ID { get; set; }

        public int? Dept_ID { get; set; }

        public virtual Department Department { get; set; }

        //Enrollments
        public virtual List<Enrollment> Enrollments { get; set; }
    }
}