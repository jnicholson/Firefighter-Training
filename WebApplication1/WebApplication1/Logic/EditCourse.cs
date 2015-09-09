using System.Linq;

namespace WebApplication1.Logic
{
    public class EditCourse
    {
        public bool EditRoll(int courseId, string courseName, bool courseDiscontinued, string courseCreditHours)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            var myCourse = (from c in _db.Courses where c.Course_ID == courseId select c).FirstOrDefault();

            myCourse.Course_Name = courseName;
            myCourse.Course_Discontinued = courseDiscontinued;
            myCourse.Course_Credit_Hours = courseCreditHours;

            // Add product to DB.

            _db.SaveChanges();

            // Success.
            return true;
        }

        public bool EditRoll(string courseName, bool courseDiscontinued, string courseCreditHours)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            HalonModels.Course myCourse = new HalonModels.Course();
            myCourse.Course_Name = courseName;
            myCourse.Course_Discontinued = courseDiscontinued;
            myCourse.Course_Credit_Hours = courseCreditHours;

            // Add product to DB.
            _db.Courses.Add(myCourse);
            _db.SaveChanges();

            // Success.
            return true;
        }
    }
}