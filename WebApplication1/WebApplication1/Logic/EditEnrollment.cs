using System;
using System.Linq;

namespace WebApplication1.Logic
{
    public class EditEnrollment
    {
        public bool EditRoll(int enrollmentId, string classID, string firefighterID)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            var myEnrollment = (from c in _db.Enrollments where c.Enrollment_ID == enrollmentId select c).FirstOrDefault();
            myEnrollment.Class_ID = Convert.ToInt32(classID);
            myEnrollment.Firefighter_ID = Convert.ToInt32(firefighterID);

            // Add product to DB.

            _db.SaveChanges();

            // Success.
            return true;
        }

        public bool EditRoll(string classID, string firefighterID)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            HalonModels.Enrollment myEnrollment = new HalonModels.Enrollment();
            myEnrollment.Class_ID = Convert.ToInt32(classID);
            myEnrollment.Firefighter_ID = Convert.ToInt32(firefighterID);

            // Add product to DB.
            _db.Enrollments.Add(myEnrollment);
            _db.SaveChanges();

            // Success.
            return true;
        }
    }
}