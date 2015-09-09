using System;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.Chief.Firefighter
{
    public partial class FirefighterAdd : System.Web.UI.Page
    {
        private HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                AddStatusLabel.Text = "**Firefighter has been added**";
                AddStatusLabel.Visible = true;
                AddAnotherFFButton.Visible = true;
                submitButton.Visible = false;
                submitButton.Text = "Okay";
            }
            else
            {
                AddStatusLabel.Visible = false;
                AddAnotherFFButton.Visible = false;
                submitButton.Visible = true;
            }
        }

        protected void CancelAddFirefighter_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Chief/Firefighter/Firefighter_Display.aspx");
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

        protected void AddFirefighter_Click(object sender, EventArgs e)
        {
            bool addSuccess = false;
            try
            {
                addSuccess = AddFirefighter(
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
                Response.Redirect("/Chief/Firefighter/Firefighter_Add.aspx");
            }
            if (addSuccess == true)
            {
                Response.Write("Firefighter has been added");
            }
        }

        public bool AddFirefighter(string Fname, string MI, string Lname,
            string DOB, string DLNum, int DLState, string Address,
            string City, int State, string Zip, int County, string EdLvl, bool HSDiploma,
            string Ethnicity, string Gender, bool Verified, bool EMTCert,
            bool Retired, bool FFCert, bool CertSusp, string SuspExp, int Dept,
            string Rank, string Callsign, string Email,
            string HomePhone, string CellPhone, string EmerPhone)
        {
            var firefighter = new WebApplication1.HalonModels.Firefighter();

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
                _db.Firefighters.Add(firefighter);
                _db.SaveChanges();
            }

            return true;
        }

        protected void AddAnotherFFButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Chief/Firefighter/Firefighter_Add.aspx");
        }
    }
}