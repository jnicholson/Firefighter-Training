using System;
using System.Linq;
using System.Web.ModelBinding;
using WebApplication1.HalonModels;

namespace WebApplication1.Admin.Firefighter
{
    public partial class Firefighter_Edit : System.Web.UI.Page
    {
        private HalonContext _db = new HalonContext();
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Firefighter_ID"]);
            IQueryable<WebApplication1.HalonModels.Firefighter> query = _db.Firefighters;
            query = query.Where(f => f.Firefighter_ID == id);
            HalonModels.Firefighter ffInfo = query.FirstOrDefault();

            if (!IsPostBack)
            {
                FnameTB.Text = ffInfo.Firefighter_Fname;
                MITB.Text = ffInfo.Firefighter_MI;
                LnameTB.Text = ffInfo.Firefighter_Lname;
                DOBTB1.Text = ffInfo.Firefighter_DOB.Substring(0, 2);
                DOBTB2.Text = ffInfo.Firefighter_DOB.Substring(3, 2);
                DOBTB3.Text = ffInfo.Firefighter_DOB.Substring(6, 4);
                DLNumTB.Text = ffInfo.Firefighter_DL_Num;
                DLStateDD.SelectedIndex = (int)ffInfo.DL_State_ID;
                AddressTB.Text = ffInfo.Firefighter_Address;
                CityTB.Text = ffInfo.Firefighter_City;
                StateDD.SelectedIndex = (int)ffInfo.State_ID - 1;
                ZipTB.Text = ffInfo.Firefighter_Zip;
                CountyDD.SelectedIndex = (int)ffInfo.County_ID - 1;
                EducationDD.SelectedValue = ffInfo.Firefighter_High_Ed_Lvl;
                HSDiplomaRBL.SelectedValue = ffInfo.Firefighter_Diploma.ToString();
                EthnicityDD.SelectedValue = ffInfo.Firefighter_Race;
                GenderRBL.SelectedValue = ffInfo.Firefighter_Gender;
                VerifiedRBL.SelectedValue = ffInfo.Firefighter_Verified.ToString();
                FFCertRBL.SelectedValue = ffInfo.Firefighter_Cert.ToString();
                EMTCertRBL.SelectedValue = ffInfo.Firefighter_Cert_Emt.ToString();
                RetiredRBL.SelectedValue = ffInfo.Firefighter_Retired.ToString();
                CertSuspRBL.SelectedValue = ffInfo.Firefighter_Cert_Suspensions.ToString();
                SuspExpTB.Text = ffInfo.Firefighter_Cert_Sus_Exp;
                DeptDD.SelectedIndex = (int)ffInfo.Dept_ID - 1;
                RankDD.SelectedValue = ffInfo.Firefighter_Rank;
                CallsignTB.Text = ffInfo.Firefighter_Callsign_ID;
                EmailTB.Text = ffInfo.Firefighter_Email;
                if (!ffInfo.Firefighter_Home_Ph.StartsWith("-"))
                {
                    HomePhoneTB1.Text = ffInfo.Firefighter_Home_Ph.Substring(0, 3);
                    HomePhoneTB2.Text = ffInfo.Firefighter_Home_Ph.Substring(4, 3);
                    HomePhoneTB3.Text = ffInfo.Firefighter_Home_Ph.Substring(8, 4);
                }
                if (!ffInfo.Firefighter_Cell_Ph.StartsWith("-"))
                {
                    CellPhoneTB1.Text = ffInfo.Firefighter_Cell_Ph.Substring(0, 3);
                    CellPhoneTB2.Text = ffInfo.Firefighter_Cell_Ph.Substring(4, 3);
                    CellPhoneTB3.Text = ffInfo.Firefighter_Cell_Ph.Substring(8, 4);
                }
                if (!ffInfo.Firefighter_Emer_Ph.StartsWith("-"))
                {
                    EmerPhoneTB1.Text = ffInfo.Firefighter_Emer_Ph.Substring(0, 3);
                    EmerPhoneTB2.Text = ffInfo.Firefighter_Emer_Ph.Substring(4, 3);
                    EmerPhoneTB3.Text = ffInfo.Firefighter_Emer_Ph.Substring(8, 4);
                }
            }
        }

        protected void CancelUpdateFirefighter_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Firefighter/Firefighter_Display.aspx");
        }

        protected void RemoveUpdateFirefighter_Click(object sender, EventArgs e)
        {
            var firefighter = _db.Firefighters.SingleOrDefault(p => p.Firefighter_ID == id);
            if (deleteCB.Checked.Equals(true))
            {
                _db.Firefighters.Remove(firefighter);
                _db.SaveChanges();
                Response.Redirect("/Admin/Firefighter/Firefighter_Display.aspx");
            }
        }

        public IQueryable<WebApplication1.HalonModels.Firefighter> GetFirefighterInfo([QueryString("Firefighter_ID")]int? firefighterId)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            IQueryable<WebApplication1.HalonModels.Firefighter> query = _db.Firefighters;

            if (firefighterId.HasValue && firefighterId > 0)
            {
                query = query.Where(f => f.Firefighter_ID == firefighterId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public IQueryable<State> GetStates()
        {
            IQueryable<State> states = _db.States;
            return states;
        }

        public IQueryable<HalonModels.County> GetCounties()
        {
            IQueryable<HalonModels.County> counties = _db.Counties;
            return counties;
        }

        public IQueryable<HalonModels.Department> GetDepartments()
        {
            IQueryable<HalonModels.Department> departments = _db.Departments;
            return departments;
        }

        protected void UpdateFirefighter_Click(object sender, EventArgs e)
        {
            bool updateSuccess = false;

            try
            {
                updateSuccess = UpdateFirefighter(

                    FnameTB.Text,
                    MITB.Text,
                    LnameTB.Text,
                    DOBTB1.Text + "/" + DOBTB2.Text + "/" + DOBTB3.Text,
                    DLNumTB.Text,
                    Convert.ToInt16(DLStateDD.Text),
                    AddressTB.Text,
                    CityTB.Text,
                    Convert.ToInt16(StateDD.Text),
                    ZipTB.Text,
                    Convert.ToInt16(CountyDD.Text),
                    EducationDD.Text,
                    Convert.ToBoolean(HSDiplomaRBL.SelectedValue),
                    EthnicityDD.SelectedItem.Text,
                    GenderRBL.SelectedValue,
                    Convert.ToBoolean(VerifiedRBL.SelectedValue),
                    Convert.ToBoolean(EMTCertRBL.SelectedValue),
                    Convert.ToBoolean(RetiredRBL.SelectedValue),
                    Convert.ToBoolean(FFCertRBL.SelectedValue),
                    Convert.ToBoolean(CertSuspRBL.SelectedValue),
                    SuspExpTB.Text,
                    Convert.ToInt16(DeptDD.Text),
                    RankDD.Text,
                    CallsignTB.Text,
                    EmailTB.Text,
                    HomePhoneTB1.Text + "-" + HomePhoneTB2.Text + "-" + HomePhoneTB3.Text,
                    CellPhoneTB1.Text + "-" + CellPhoneTB2.Text + "-" + CellPhoneTB3.Text,
                    EmerPhoneTB1.Text + "-" + EmerPhoneTB2.Text + "-" + EmerPhoneTB3.Text);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("/Admin/Firefighter/Firefighter_Edit.aspx");
            }
            if (updateSuccess == true)
            {
                Response.Redirect("/Admin/Firefighter/Firefighter_Display.aspx");
            }
        }

        public bool UpdateFirefighter(string Fname, string MI, string Lname,
            string DOB, string DLNum, int DLState, string Address,
            string City, int State, string Zip, int County, string EdLvl, bool HSDiploma,
            string Ethnicity, string Gender, bool Verified, bool EMTCert,
            bool Retired, bool FFCert, bool CertSusp, string SuspExp, int Dept,
            string Rank, string Callsign, string Email,
            string HomePhone, string CellPhone, string EmerPhone)
        {
            var firefighter = _db.Firefighters.SingleOrDefault(p => p.Firefighter_ID == id);

            firefighter.Firefighter_Fname = Fname;
            firefighter.Firefighter_MI = MI;
            firefighter.Firefighter_Lname = Lname;
            firefighter.Firefighter_DOB = DOB;
            firefighter.Firefighter_DL_Num = DLNum;
            firefighter.DL_State_ID = DLState;
            firefighter.Firefighter_Address = Address;
            firefighter.Firefighter_City = City;
            firefighter.State_ID = State;
            firefighter.Firefighter_Zip = Zip;
            firefighter.County_ID = County;
            firefighter.Firefighter_High_Ed_Lvl = EdLvl;
            firefighter.Firefighter_Diploma = HSDiploma;
            firefighter.Firefighter_Race = Ethnicity;
            firefighter.Firefighter_Gender = Gender;
            firefighter.Firefighter_Verified = Verified;
            firefighter.Firefighter_Cert_Emt = EMTCert;
            firefighter.Firefighter_Retired = Retired;
            firefighter.Firefighter_Cert = FFCert;
            firefighter.Firefighter_Cert_Suspensions = CertSusp;
            firefighter.Firefighter_Cert_Sus_Exp = SuspExp;
            firefighter.Dept_ID = Dept;
            firefighter.Firefighter_Rank = Rank;
            firefighter.Firefighter_Callsign_ID = Callsign;
            firefighter.Firefighter_Email = Email;
            firefighter.Firefighter_Home_Ph = HomePhone;
            firefighter.Firefighter_Cell_Ph = CellPhone;
            firefighter.Firefighter_Emer_Ph = EmerPhone;

            if (Page.IsValid)
            {
                _db.SaveChanges();
            }

            return true;
        }
    }
}