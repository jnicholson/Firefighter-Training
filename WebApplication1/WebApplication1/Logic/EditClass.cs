using System;
using System.Linq;

namespace WebApplication1.Logic
{
    public class EditClass
    {
        public bool EditClasses(string classId, bool cancelled, string firefighterID, string course, string note, string dateVar)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            int class_ID = Convert.ToInt32(classId);
            var myClass = (from c in _db.Classes where c.Class_ID == class_ID select c).FirstOrDefault();
            myClass.Class_Cancelled = cancelled;
            myClass.Firefighter_ID = Convert.ToInt32(firefighterID);
            myClass.Course_ID = Convert.ToInt32(course);
            myClass.Class_Note = note;
            myClass.Class_Date = dateVar;

            // Add product to DB.
            _db.SaveChanges();

            // Success.
            return true;
        }

        public bool EditClasses(bool cancelled, string firefighterID, string course, string note, string dateVar)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            HalonModels.Class myClass = new HalonModels.Class();
            myClass.Class_Cancelled = cancelled;
            myClass.Firefighter_ID = Convert.ToInt32(firefighterID);
            myClass.Course_ID = Convert.ToInt32(course);
            myClass.Class_Note = note;
            myClass.Class_Date = dateVar;

            // Add product to DB.
            _db.Classes.Add(myClass);
            _db.SaveChanges();

            // Success.
            return true;
        }
    }
}