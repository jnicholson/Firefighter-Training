using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication1.HalonModels
{
    public class HalonDatabaseInitializer : DropCreateDatabaseIfModelChanges<HalonContext>
    {
        protected override void Seed(HalonContext context)
        {
            GetFirefighterDetails().ForEach(f => context.Firefighters.Add(f));
            GetStates().ForEach(s => context.States.Add(s));
            GetCourses().ForEach(c => context.Courses.Add(c));
            GetEnrollments().ForEach(e => context.Enrollments.Add(e));
            GetCounties().ForEach(count => context.Counties.Add(count));
            GetClasses().ForEach(cls => context.Classes.Add(cls));
            GetDepartments().ForEach(Dept => context.Departments.Add(Dept));
        }

        private static List<Firefighter> GetFirefighterDetails()
        {
            var firefighterDetails = new List<Firefighter> {
                new Firefighter{
                    Firefighter_ID = 1,
                    Firefighter_Fname = "John",
                    Firefighter_MI = "E",
                    Firefighter_Lname = "Smith",
                    Firefighter_Cell_Ph = "123-456-7890",
                    Firefighter_Emer_Ph = "098-765-4321",
                    Firefighter_Home_Ph = "987-654-3210",
                    Firefighter_Address = "123 Main Street",
                    Firefighter_City = "Fort Smith",
                    State_ID = 4,
                    DL_State_ID = 4,
                    Dept_ID = 1,
                    County_ID = 1,
                    Firefighter_Account_Username="Chief",
                    Firefighter_Cert = true,
                    Firefighter_Cert_Emt = false,
                    Firefighter_Cert_Suspensions = false,
                    Firefighter_Cert_Sus_Exp = "None",
                    Firefighter_Diploma = true,
                    Firefighter_Callsign_ID = "1",
                    Firefighter_DL_Num = "test-1234-123",
                    Firefighter_DOB = "12/12/1900",
                    Firefighter_Email = "John.Smith@halon.com",
                    Firefighter_High_Ed_Lvl = "None",
                    Firefighter_Gender = "M",
                    Firefighter_Race = "Native American",
                    Firefighter_Rank = "None",
                    Firefighter_Zip = "12345"
                },
                new Firefighter{
                    Firefighter_ID = 2,
                    Firefighter_Fname = "James",
                    Firefighter_MI = "D",
                    Firefighter_Lname = "Vo",
                    Firefighter_Cell_Ph = "123-456-7890",
                    Firefighter_Emer_Ph = "098-765-4321",
                    Firefighter_Home_Ph = "987-654-3210",
                    Firefighter_Address = "123 Second Street",
                    Firefighter_City = "Fort Smith",
                    State_ID = 4,
                    DL_State_ID = 4,
                    Dept_ID = 2,
                    County_ID = 1,
                    Firefighter_Account_Username="Instructor",
                    Firefighter_Cert = false,
                    Firefighter_Cert_Emt = false,
                    Firefighter_Cert_Suspensions = false,
                    Firefighter_Cert_Sus_Exp = "None",
                    Firefighter_Diploma = true,
                    Firefighter_Callsign_ID = "2",
                    Firefighter_DL_Num = "test-5432-123",
                    Firefighter_DOB = "01/24/1900",
                    Firefighter_Email = "James.Vo@halon.com",
                    Firefighter_High_Ed_Lvl = "Bachelor's in Information Technology",
                    Firefighter_Gender = "M",
                    Firefighter_Race = "African-American",
                    Firefighter_Rank = "New Guy",
                    Firefighter_Zip = "23582"
                },
                new Firefighter{
                    Firefighter_ID = 3,
                    Firefighter_Fname = "DJ",
                    Firefighter_MI = "",
                    Firefighter_Lname = "Sawyer",
                    Firefighter_Cell_Ph = "153-476-7980",
                    Firefighter_Emer_Ph = "098-725-4521",
                    Firefighter_Home_Ph = "988-674-3610",
                    Firefighter_Address = "123 Arkansas Street",
                    Firefighter_City = "Fort Smith",
                    State_ID = 4,
                    DL_State_ID = 4,
                    Dept_ID = 1,
                    County_ID = 1,
                    Firefighter_Account_Username="TrainingOfficer",
                    Firefighter_Cert = true,
                    Firefighter_Cert_Emt = true,
                    Firefighter_Cert_Suspensions = false,
                    Firefighter_Cert_Sus_Exp = "None",
                    Firefighter_Diploma = true,
                    Firefighter_Callsign_ID = "3",
                    Firefighter_DL_Num = "test-1204-123",
                    Firefighter_DOB = "12/12/1910",
                    Firefighter_Email = "DJ.Sawyer@halon.com",
                    Firefighter_High_Ed_Lvl = "None",
                    Firefighter_Gender = "M",
                    Firefighter_Race = "Asian",
                    Firefighter_Rank = "Training Officer",
                    Firefighter_Zip = "52368"
                },
                new Firefighter{
                    Firefighter_ID = 4,
                    Firefighter_Fname = "Hung",
                    Firefighter_MI = "M",
                    Firefighter_Lname = "Tran",
                    Firefighter_Cell_Ph = "122-452-7290",
                    Firefighter_Emer_Ph = "198-766-4821",
                    Firefighter_Home_Ph = "977-654-3210",
                    Firefighter_Address = "123 Test Street",
                    Firefighter_City = "Fort Smith",
                    State_ID = 4,
                    DL_State_ID = 4,
                    Dept_ID = 2,
                    County_ID = 1,
                    Firefighter_Account_Username="User",
                    Firefighter_Cert = true,
                    Firefighter_Cert_Emt = false,
                    Firefighter_Cert_Suspensions = false,
                     Firefighter_Cert_Sus_Exp = "None",
                    Firefighter_Diploma = true,
                    Firefighter_Callsign_ID = "4",
                    Firefighter_DL_Num = "test-1204-123",
                    Firefighter_DOB = "12/02/1900",
                    Firefighter_Email = "Hung.Tran@halon.com",
                    Firefighter_High_Ed_Lvl = "None",
                    Firefighter_Gender = "M",
                    Firefighter_Race = "Native Mongolian",
                    Firefighter_Rank = "Bossman",
                    Firefighter_Zip = "36951"
                },
                new Firefighter{
                    Firefighter_ID = 5,
                    Firefighter_Fname = "Jesse",
                    Firefighter_MI = "F",
                    Firefighter_Lname = "Nicholson",
                    Firefighter_Cell_Ph = "123-426-7860",
                    Firefighter_Emer_Ph = "097-763-4821",
                    Firefighter_Home_Ph = "981-184-3210",
                    Firefighter_Address = "123 42nd Street",
                    Firefighter_City = "Fort Smith",
                    State_ID = 4,
                    DL_State_ID = 4,
                    Dept_ID = 2,
                    County_ID = 1,
                    Firefighter_Account_Username="Admin",
                    Firefighter_Cert = false,
                    Firefighter_Cert_Emt = true,
                    Firefighter_Cert_Suspensions = false,
                    Firefighter_Cert_Sus_Exp = "None",
                    Firefighter_Diploma = true,
                    Firefighter_Callsign_ID = "test-1",
                    Firefighter_DL_Num = "test-1234-123",
                    Firefighter_DOB = "12/12/1900",
                    Firefighter_Email = "John.Smith@halon.com",
                    Firefighter_High_Ed_Lvl = "None",
                    Firefighter_Gender = "M",
                    Firefighter_Race = "Native Ethiopian",
                    Firefighter_Rank = "Test Rank",
                    Firefighter_Zip = "96482"
                },
                new Firefighter{
                    Firefighter_ID = 6,
                    Firefighter_Fname = "Ryan",
                    Firefighter_MI = "X",
                    Firefighter_Lname = "Timmerman",
                    Firefighter_Cell_Ph = "133-484-7360",
                    Firefighter_Emer_Ph = "010-955-4811",
                    Firefighter_Home_Ph = "991-604-3200",
                    Firefighter_Address = "123 103rd Street",
                    Firefighter_City = "Fort Smith",
                    State_ID = 4,
                    DL_State_ID = 4,
                    Dept_ID = 1,
                    County_ID = 1,
                    Firefighter_Cert = true,
                    Firefighter_Cert_Emt = false,
                    Firefighter_Cert_Suspensions = false,
                    Firefighter_Cert_Sus_Exp = "None",
                    Firefighter_Diploma = true,
                    Firefighter_Callsign_ID = "test-1",
                    Firefighter_DL_Num = "test-1234-123",
                    Firefighter_DOB = "12/12/1900",
                    Firefighter_Email = "John.Smith@halon.com",
                    Firefighter_High_Ed_Lvl = "None",
                    Firefighter_Gender = "M",
                    Firefighter_Race = "Caucasian",
                    Firefighter_Rank = "None",
                    Firefighter_Zip = "12345"
                },
                new Firefighter{
                    Firefighter_ID = 7,
                    Firefighter_Fname = "Jane",
                    Firefighter_MI = "L",
                    Firefighter_Lname = "Doe",
                    Firefighter_Cell_Ph = "321-321-1258",
                    Firefighter_Emer_Ph = "965-987-6523",
                    Firefighter_Home_Ph = "523-698-5231",
                    Firefighter_Address = "12 Blank Street",
                    Firefighter_City = "Fort Smith",
                    State_ID = 4,
                    DL_State_ID = 4,
                    Dept_ID = 1,
                    County_ID = 1,
                    Firefighter_Account_Username= null,
                    Firefighter_Cert = true,
                    Firefighter_Cert_Emt = false,
                    Firefighter_Cert_Suspensions = false,
                    Firefighter_Cert_Sus_Exp = "None",
                    Firefighter_Diploma = true,
                    Firefighter_Callsign_ID = null,
                    Firefighter_DL_Num = "DL-123--44534",
                    Firefighter_DOB = "01/25/1960",
                    Firefighter_Email = "Jane.Doe@halon.com",
                    Firefighter_High_Ed_Lvl = "None",
                    Firefighter_Gender = "F",
                    Firefighter_Race = "Native American",
                    Firefighter_Rank = "None",
                    Firefighter_Zip = "52458"
                },
            };
            return firefighterDetails;
        }

        private static List<State> GetStates()
        {
            var orders = new List<State> {
                new State{
                   State_ID = 1,
                   State_Name = "Alabama",
                   State_Abbreviation = "AL"
                },
                new State{
                   State_ID = 2,
                   State_Name = "Alaska",
                   State_Abbreviation = "AK"
                },
                new State{
                   State_ID = 3,
                   State_Name = "Arizona",
                   State_Abbreviation = "AZ"
                },
                new State{
                   State_ID = 4,
                   State_Name = "Arkansas",
                   State_Abbreviation = "AR"
                },
                new State{
                   State_ID = 5,
                   State_Name = "California",
                   State_Abbreviation = "CA"
                },
                new State{
                   State_ID = 6,
                   State_Name = "Colorado",
                   State_Abbreviation = "CO"
                },
                new State{
                   State_ID = 7,
                   State_Name = "Connecticut",
                   State_Abbreviation = "CT"
                },
                new State{
                   State_ID = 8,
                   State_Name = "Delaware",
                   State_Abbreviation = "DE"
                },
                new State{
                   State_ID = 9,
                   State_Name = "District of Columbia",
                   State_Abbreviation = "DC"
                },
                new State{
                   State_ID = 10,
                   State_Name = "Florida",
                   State_Abbreviation = "FL"
                },
                new State{
                   State_ID = 11,
                   State_Name = "Georgia",
                   State_Abbreviation = "GA"
                },
                new State{
                   State_ID = 12,
                   State_Name = "Hawaii",
                   State_Abbreviation = "HI"
                },
                new State{
                   State_ID = 13,
                   State_Name = "Idaho",
                   State_Abbreviation = "ID"
                },
                new State{
                   State_ID = 14,
                   State_Name = "Illinois",
                   State_Abbreviation = "IL"
                },
                new State{
                   State_ID = 15,
                   State_Name = "Indiana",
                   State_Abbreviation = "IN"
                },
                new State{
                   State_ID = 16,
                   State_Name = "Iowa",
                   State_Abbreviation = "IA"
                },
                new State{
                   State_ID = 17,
                   State_Name = "Kansas",
                   State_Abbreviation = "KS"
                },
                new State{
                   State_ID = 18,
                   State_Name = "Kentucky",
                   State_Abbreviation = "KY"
                },
                new State{
                   State_ID = 19,
                   State_Name = "Louisiana",
                   State_Abbreviation = "LA"
                },
                new State{
                   State_ID = 20,
                   State_Name = "Maine",
                   State_Abbreviation = "ME"
                },
                new State{
                   State_ID = 21,
                   State_Name = "Maryland",
                   State_Abbreviation = "MD"
                },
                new State{
                   State_ID = 22,
                   State_Name = "Massachusetts",
                   State_Abbreviation = "MA"
                },
                new State{
                   State_ID = 23,
                   State_Name = "Michigan",
                   State_Abbreviation = "MI"
                },
                new State{
                   State_ID = 24,
                   State_Name = "Minnesota",
                   State_Abbreviation = "MN"
                },
                new State{
                   State_ID = 25,
                   State_Name = "Mississippi",
                   State_Abbreviation = "MS"
                },
                new State{
                   State_ID = 26,
                   State_Name = "Missouri",
                   State_Abbreviation = "MO"
                },
                new State{
                   State_ID = 27,
                   State_Name = "Montana",
                   State_Abbreviation = "MT"
                },
                new State{
                   State_ID = 28,
                   State_Name = "Nebraska",
                   State_Abbreviation = "NE"
                },
                new State{
                   State_ID = 29,
                   State_Name = "Nevada",
                   State_Abbreviation = "NV"
                },
                new State{
                   State_ID = 30,
                   State_Name = "New Hampshire",
                   State_Abbreviation = "NH"
                },
                new State{
                   State_ID = 31,
                   State_Name = "New Jersey",
                   State_Abbreviation = "NJ"
                },
                new State{
                   State_ID = 32,
                   State_Name = "New Mexico",
                   State_Abbreviation = "NM"
                },
                new State{
                   State_ID = 33,
                   State_Name = "New York",
                   State_Abbreviation = "NY"
                },
                new State{
                   State_ID = 34,
                   State_Name = "North Carolina",
                   State_Abbreviation = "NC"
                },
                new State{
                   State_ID = 35,
                   State_Name = "North Dakota",
                   State_Abbreviation = "ND"
                },
                new State{
                   State_ID = 36,
                   State_Name = "Ohio",
                   State_Abbreviation = "OH"
                },
                new State{
                   State_ID = 37,
                   State_Name = "Oklahoma",
                   State_Abbreviation = "OK"
                },
                new State{
                   State_ID = 38,
                   State_Name = "Oregon",
                   State_Abbreviation = "OR"
                },
                new State{
                   State_ID = 39,
                   State_Name = "Pennsylvania",
                   State_Abbreviation = "PA"
                },
                new State{
                   State_ID = 40,
                   State_Name = "Rhode Island",
                   State_Abbreviation = "RI"
                },
                new State{
                   State_ID = 41,
                   State_Name = "South Carolina",
                   State_Abbreviation = "SC"
                },
                new State{
                   State_ID = 42,
                   State_Name = "South Dakota",
                   State_Abbreviation = "SD"
                },
                new State{
                   State_ID = 43,
                   State_Name = "Tennessee",
                   State_Abbreviation = "TN"
                },
                new State{
                   State_ID = 44,
                   State_Name = "Texas",
                   State_Abbreviation = "TX"
                },
                new State{
                   State_ID = 45,
                   State_Name = "Utah",
                   State_Abbreviation = "UT"
                },
                new State{
                   State_ID = 46,
                   State_Name = "Vermont",
                   State_Abbreviation = "VT"
                },
                new State{
                   State_ID = 47,
                   State_Name = "Virginia",
                   State_Abbreviation = "VA"
                },
                new State{
                   State_ID = 48,
                   State_Name = "Washington",
                   State_Abbreviation = "WA"
                },
                new State{
                   State_ID = 49,
                   State_Name = "West Virginia",
                   State_Abbreviation = "WV"
                },
                new State{
                   State_ID = 50,
                   State_Name = "Wisconsin",
                   State_Abbreviation = "WI"
                },
                new State{
                   State_ID = 51,
                   State_Name = "Wyoming",
                   State_Abbreviation = "WY"
                }
            };
            return orders;
        }

        private static List<Course> GetCourses()
        {
            var courses = new List<Course> {
                new Course{
                    Course_ID = 1,
                    Course_Name = "Introduction",
                    Course_Credit_Hours = "12",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 2,
                    Course_Name = "PPE",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 3,
                    Course_Name = "Chapter 2 Safety",
                    Course_Credit_Hours = "3",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 4,
                    Course_Name = "Chapter 3 Communications",
                    Course_Credit_Hours = "2",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 5,
                    Course_Name = "Chapter 4 Building Construction",
                    Course_Credit_Hours = "4",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 6,
                    Course_Name = "Chapter 5 Fire Behavior",
                    Course_Credit_Hours = "4",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 7,
                    Course_Name = "Chapter 6 Personal Protective Equipment",
                    Course_Credit_Hours = "6",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 8,
                    Course_Name = "Chapter 7 Portable Extinguishers",
                    Course_Credit_Hours = "4",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 9,
                    Course_Name = "Chapter 11 Forcible Entry",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 10,
                    Course_Name = "Chapter 12 Ladders",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 11,
                    Course_Name = "Chapter 13 Ventilation",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 12,
                    Course_Name = "Chapter 14 Water Supply",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 13,
                    Course_Name = "Chapter 15 Fire Hose",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 14,
                    Course_Name = "Chapter 16 Fire Streams",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 15,
                    Course_Name = "Chapter 18 Overhaul",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 16,
                    Course_Name = "Chapter 1 Review of the Intro",
                    Course_Credit_Hours = "2",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 17,
                    Course_Name = "Chapter 8 Ropes and Knots",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 18,
                    Course_Name = "Chapter 9 Basic Search and Rescue",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 19,
                    Course_Name = "Chapter 10 Scene Lighting",
                    Course_Credit_Hours = "2",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 20,
                    Course_Name = "Structure Fires I",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 21,
                    Course_Name = "Structure Fires II",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 22,
                    Course_Name = "Structure Fires III",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 23,
                    Course_Name = "Structure Fires IV",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 24,
                    Course_Name = "Exterior Fires",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 25,
                    Course_Name = "Chapter 10 Extrication and Rescue",
                    Course_Credit_Hours = "16",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 26,
                    Course_Name = "Chapter 19 Fire Origin and Cause Determination",
                    Course_Credit_Hours = "2",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 27,
                    Course_Name = "Chapter 20 Protective Systems",
                    Course_Credit_Hours = "4",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 28,
                    Course_Name = "Chapter 21 Fire and Life Safety Initiatives",
                    Course_Credit_Hours = "4",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 29,
                    Course_Name = "Chapter 17 FF II",
                    Course_Credit_Hours = "8",
                    Course_Discontinued = false
                },
                new Course{
                    Course_ID = 30,
                    Course_Name = "In House Training",
                    Course_Credit_Hours = "1",
                    Course_Discontinued = false
                }
            };
            return courses;
        }

        public static List<Class> GetClasses()
        {
            var classes = new List<Class> {
                new Class
                {
                    Class_ID = 1,
                    Class_Date = "1/10/2008",
                    Firefighter_ID = 1,
                    Course_ID = 1,
                    Class_Note = "None",
                    Class_Cancelled = false
                },
                new Class
                {
                    Class_ID = 2,
                    Class_Date = "3/30/2011",
                    Firefighter_ID = 4,
                    Course_ID = 3,
                    Class_Note = "None",
                    Class_Cancelled = false
                },
                new Class
                {
                    Class_ID = 3,
                    Class_Date = "2/9/2014",
                    Firefighter_ID = 2,
                    Course_ID = 2,
                    Class_Note = "None",
                    Class_Cancelled = false
                },
                new Class
                {
                    Class_ID = 4,
                    Class_Date = "10/12/2014",
                    Firefighter_ID = 2,
                    Course_ID = 10,
                    Class_Cancelled = false,
                    Class_Note = "None"
                },
                new Class
                {
                    Class_ID = 5,
                    Class_Date = "3/15/2014",
                    Firefighter_ID = 2,
                    Course_ID = 2,
                    Class_Cancelled = false,
                    Class_Note = "None"
                },
                new Class
                {
                    Class_ID = 6,
                    Class_Date = "3/22/2014",
                    Firefighter_ID = 2,
                    Course_ID = 30,
                    Class_Cancelled = false,
                    Class_Note = "None"
                },
                new Class
                {
                    Class_ID = 7,
                    Class_Date = "3/22/2014",
                    Firefighter_ID = 2,
                    Course_ID = 30,
                    Class_Cancelled = false,
                    Class_Note = "None"
                }
            };
            return classes;
        }

        private static List<Enrollment> GetEnrollments()
        {
            var enrollments = new List<Enrollment> {
                new Enrollment
                {
                    Enrollment_ID = 1,
                    Class_ID = 1,
                    Firefighter_ID = 1
               },
               new Enrollment
                {
                    Enrollment_ID = 2,
                    Class_ID = 3,
                    Firefighter_ID = 4
               },
               new Enrollment
                {
                    Enrollment_ID = 3,
                    Class_ID = 2,
                    Firefighter_ID = 5
               },
               new Enrollment
                {
                    Enrollment_ID = 4,
                    Class_ID = 5,
                    Firefighter_ID = 4
               },
               new Enrollment
                {
                    Enrollment_ID = 5,
                    Class_ID = 6,
                    Firefighter_ID = 1
               },
               new Enrollment
                {
                    Enrollment_ID = 6,
                    Class_ID = 7,
                    Firefighter_ID = 1
               }
            };

            return enrollments;
        }

        private static List<County> GetCounties()
        {
            var counties = new List<County> {
                new County
                {
                    County_ID = 1,
                    County_Name = "Sebastian",
                    State_ID = 4
               },
               new County
                {
                    County_ID = 2,
                    County_Name = "Best",
                    State_ID = 4
               },
               new County
                {
                    County_ID = 3,
                    County_Name = "Test",
                    State_ID = 4
               }
            };

            return counties;
        }

        private static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department> {
                new Department
                {
                    Dept_ID = 1,
                    Dept_FDID = "1234",
                    Dept_Name = "Greensboro",
                    Dept_Address = "321 72nd Avenue",
                    Dept_City = "Greensboro",
                    Dept_Tel_No = "125-283-3829",
                    Dept_Zip = "32156",
                    Firefighter_ID = 1,
                    County_ID = 1,
                    Dept_Callsign = "GB",
               },
               new Department
                {
                    Dept_ID = 2,
                    Dept_FDID = "4321",
                    Dept_Name = "Bloomburg",
                    Dept_Address = "10 Greenswell Circle",
                    Dept_City = "Bloomburg",
                    Dept_Tel_No = "521-358-4297",
                    Dept_Zip = "48523",
                    Firefighter_ID = 6,
                    County_ID = 2,
                    Dept_Callsign = "BB",
               }
            };

            return departments;
        }
    }
}