using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using System.Web.Security;
using System.Data;
using CLFacadeLayer;
using Facebook.Rest;
using Facebook.Schema;
using Facebook.Session;
using Facebook.Utility;
using CourseLogicWeb.Cryptography;

namespace CourseLogicWeb.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        /*
        public ActionResult Index()
        {
            string AuthenticationStatus = String.Empty;
            string ActivationKey = string.Empty;
            string ResponseString = string.Empty;
            AuthenticationStatus = ManageFacebook();
            if (AuthenticationStatus == "true" || AuthenticationStatus == "UserAlreadyExists")
            {
                return Redirect("~/CourseHome/CourseHome?CourseID=10");
            }
            else
            {
                return View();
            }
        }
         * */

        public ActionResult Index()
        {
            string AuthenticationStatus = String.Empty;
            string ActivationKey = string.Empty;
            Int32 ResponseString = 0;
            if (Request.QueryString["ActivationKey"] == null)
            {
                return Redirect("/login/login");
            }
            else
            {
                ActivationKey = Request.QueryString["ActivationKey"].ToString();
                System.Text.RegularExpressions.Regex isGuid
                = new System.Text.RegularExpressions.Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
                    System.Text.RegularExpressions.RegexOptions.Compiled);
                if (isGuid.IsMatch(ActivationKey))
                {
                    VerifyInvitation objVerifyInvitation = new VerifyInvitation(ActivationKey);
                    ResponseString = objVerifyInvitation.FinialResults;
                    if (ResponseString == 2)
                    {
                        ViewModel.Message = "Your are already registered with CourseLogic. You can directly sign in.Thank you!";
                        ViewData["Message"] = "Your are already registered with CourseLogic. You can directly sign in.Thank you!";
                        return View();
                    }
                    if (ResponseString == 0)
                    {
                        ViewModel.Message = "Link is not valid.Please follow proper signup step again.Thanks!";
                        ViewData["Message"] = "Link is not valid.Please follow proper signup step again.Thanks!";
                        return View();
                    }
                    if (ResponseString == 0)
                    {
                        ViewModel.Message = "Link is not valid.Please follow proper signup step again.Thanks!";
                        ViewData["Message"] = "Link is not valid.Please follow proper signup step again.Thanks!";
                        return View();
                    }
                    if (ResponseString == 1)
                    {
                        AuthenticationStatus = ManageFacebook();
                        if (AuthenticationStatus == "true" || AuthenticationStatus == "UserAlreadyExists")
                        {
                            //return Redirect("~/CourseHome/CourseHome?CourseID=10");
                            return Redirect("/Profile/CurrentCourses");
                        }
                        else
                        {
                            return View();
                        }
                    }
                    return View();
                }
                else
                {
                    ViewModel.Message = "Please verify link,which was sent to you in your E-mail Account.";
                    ViewData["Message"] = "Please verify link,which was sent to you in your E-mail Account.";
                    return View();
                }
            }
        }

        #region Private Members

        // NOTE: In production app, these keys would be stored in config file
        private string APPLICATION_KEY = ConfigurationService.ConfigurationService.APPLICATION_KEY().ToString();
        //private string APPLICATION_KEY = "a98b239b45c02c14b5e0101874ce2cce";
        private string SECRET_KEY = ConfigurationService.ConfigurationService.SECRET_KEY().ToString();
        //private string SECRET_KEY = "372d5fc217d14b4bd8674a6dff9f5da9";
        string[] _QueryKeys;
        private Api _facebookAPI;
        private ConnectSession _connectSession;
        int AccountID;
        #endregion Private Members

        #region ManageFacebook
        private string ManageFacebook()
        {
            string FacebookUserAuthicatedCheck = "false";
            RegisterModel objRegisterModel = new RegisterModel();
            // Authenticated, created session and API object
            _connectSession = new ConnectSession(APPLICATION_KEY, SECRET_KEY);
            _connectSession.Logout();
            _connectSession.Login();

            //Check User Is Login in with Facebook
            if (_connectSession.IsConnected())
            {
                // Authenticated, create API instance

                _facebookAPI = new Api(_connectSession);
                user user = null;
                if (_facebookAPI != null)
                {
                    try
                    {
                        // Load user
                        user = _facebookAPI.Users.GetInfo();
                        string a = _facebookAPI.LogOffUrl;
                    }
                    catch (Exception ex)
                    {
                        return FacebookUserAuthicatedCheck;
                    }
                }

                if (user != null)
                {
                    long FacebookID = user.uid.Value;
                    FacebookUserAuthicatedCheck = FacebookAuthenticateUser(FacebookID);
                    // registation code here
                    if (FacebookUserAuthicatedCheck == "true")
                    {
                        // user already exists redirect to User Profile Home Paqge
                        FacebookUserAuthicatedCheck = "UserAlreadyExists";
                    }
                    else
                    {
                        if (Request.QueryString["ActivationKey"] == null)
                        {
                            return FacebookUserAuthicatedCheck;
                        }
                        else
                        {
                            string ActivationKey = Request.QueryString["ActivationKey"].ToString();
                            System.Text.RegularExpressions.Regex isGuid
                            = new System.Text.RegularExpressions.Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
                                System.Text.RegularExpressions.RegexOptions.Compiled);
                            if (isGuid.IsMatch(ActivationKey))
                            {
                                GetRegisterUserData objGetRegisterUserData = new GetRegisterUserData(ActivationKey);
                                objRegisterModel = objGetRegisterUserData._RegisterUserList.Single(AKEY => AKEY.VerificationGuid.ToUpper() == ActivationKey.ToUpper());
                            }
                        }
                        // Enter New User Entry into database.
                        objRegisterModel.FirstName = user.first_name;
                        objRegisterModel.LastName = user.last_name;
                        objRegisterModel.FacebookUserID = user.uid.Value;
                        objRegisterModel.IsFacebookID = true;

                        RegisterUserWithFacebook objRegisterUserWithFacebook = new RegisterUserWithFacebook(objRegisterModel.FirstName, objRegisterModel.LastName, objRegisterModel.FacebookUserID, objRegisterModel.IsFacebookID, objRegisterModel.Email,objRegisterModel.VerificationGuid);
                        if (objRegisterUserWithFacebook._RegUserList.Count() > 0)
                        {
                            LoginModel objLoginModel = objRegisterUserWithFacebook._RegUserList.Single();
                            if (objLoginModel.AccountID > 0)
                            {
                                FacebookUserAuthicatedCheck = FacebookAuthenticateUser(FacebookID);
                            }
                            else
                            {
                                FacebookUserAuthicatedCheck = "false";
                            }
                        }
                        else
                        {
                            FacebookUserAuthicatedCheck = "false";
                        }
                        return FacebookUserAuthicatedCheck;
                    }
                    return FacebookUserAuthicatedCheck;
                }
            }
            return FacebookUserAuthicatedCheck;
        }
        #endregion

        #region FacebookAuthenticateUser
        public string FacebookAuthenticateUser(long FacebookID)
        {
            DataSet objDS = new DataSet();
            LoginModel objLoginModel = new LoginModel();
            AccountsDAL objAccountsDAL = new AccountsDAL();

            objDS = objAccountsDAL.FacebookUserExit(FacebookID);
            if (objDS.Tables.Count > 0)
            {
                DataTable dataTable = objDS.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    List<LoginModel> _LoginList = new List<LoginModel>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        objLoginModel = new LoginModel
                        {
                            AccountID = Convert.ToInt64(row["AccountID"]),
                            Username = row["UserName"].ToString(),
                            Password = row["password"].ToString(),
                            AccountTitle = row["AccountTitle"].ToString(),
                        };
                        _LoginList.Add(objLoginModel);
                    }

                    objLoginModel = _LoginList.Single();
                }
                else
                {
                    return "false";
                }
            }
            if (objLoginModel.AccountID > 0)
            {
                SetCookie("UserName", objLoginModel.AccountTitle.ToString());
                SetCookie("ID", objLoginModel.AccountID.ToString());
                SetCookie("AccountTitle", objLoginModel.AccountTitle);

                FormsAuthentication.SetAuthCookie(objLoginModel.Username, true);
                FormsAuthentication.RedirectFromLoginPage(objLoginModel.Username, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                "user",
                DateTime.Now,
                DateTime.Now.AddMinutes(3),
                true,
                "fabiano!",
                FormsAuthentication.FormsCookiePath);

                // Create encrypted cookie
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }

                // Set and done
                Response.Cookies.Add(cookie); //Necessary, otherwise UserData property gets lost

                return "true";

            }
            if (objLoginModel.AccountID < 1)
            {
                return "false";
            }
            return String.Empty;
        }
        #endregion

        #region SetCookie
        private void SetCookie(string Name, string Value)
        {
            HttpCookie cookie = new HttpCookie(Name, Value);
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }
        #endregion

        #region CLRegistration Get Method
        //
        // GET: /RegisterModel/NormalRegistration
        public ActionResult CLRegistration()
        {
            string AuthenticationStatus = String.Empty;
            string ActivationKey = string.Empty;
            Int32 ResponseString = 0;
            RegisterModel objRegisterModel = new RegisterModel();
            if (Request.QueryString["ActivationKey"] == null)
            {
                return Redirect("/login/login");
            }
            else
            {
                ActivationKey = Request.QueryString["ActivationKey"].ToString();
                System.Text.RegularExpressions.Regex isGuid
                = new System.Text.RegularExpressions.Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
                    System.Text.RegularExpressions.RegexOptions.Compiled);
                if (isGuid.IsMatch(ActivationKey))
                {

                    VerifyInvitation objVerifyInvitation = new VerifyInvitation(ActivationKey);
                    ResponseString = objVerifyInvitation.FinialResults;
                    if (ResponseString == 2)
                    {
                        ViewModel.Message = "Your are already registered with CourseLogic. You can directly sign in.Thank you!";
                        ViewData["Message"] = "Your are already registered with CourseLogic. You can directly sign in.Thank you!";
                        return View(objRegisterModel);
                    }
                    if (ResponseString == 0)
                    {
                        ViewModel.Message = "Link is not valid.Please follow proper signup step again.Thanks!";
                        ViewData["Message"] = "Link is not valid.Please follow proper signup step again.Thanks!";
                        return View(objRegisterModel);
                    }
                    if (ResponseString == 0)
                    {
                        ViewModel.Message = "Link is not valid.Please follow proper signup step again.Thanks!";
                        ViewData["Message"] = "Link is not valid.Please follow proper signup step again.Thanks!";
                        return View(objRegisterModel);
                    }
                    if (ResponseString == 1)
                    {
                        // call Normal Regirestation 
                        GetRegisterUserData objGetRegisterUserData = new GetRegisterUserData(ActivationKey);
                        objRegisterModel = objGetRegisterUserData._RegisterUserList.Single(AKEY => AKEY.VerificationGuid.ToUpper() == ActivationKey.ToUpper());
                        //AuthenticationStatus = ManageFacebook();
                        if (AuthenticationStatus == "true" || AuthenticationStatus == "UserAlreadyExists")
                        {
                            //return Redirect("~/CourseHome/CourseHome?CourseID=10");
                            return Redirect("/Profile/CurrentCourses");
                        }
                        else
                        {
                            return View(objRegisterModel);
                        }
                    }
                    return View(objRegisterModel);
                    //return View(new RegisterModel());
                }
                else
                {
                    ViewModel.Message = "Please varify link,which was sent you in your E-mail Account.";
                    ViewData["Message"] = "Please varify link,which was sent you in your E-mail Account.";
                    return View(objRegisterModel);
                }
            }
        }
        #endregion

        #region CLRegistration Post Method
        //
        // POST: /RegisterModel/NormalRegistration
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CLRegistration(RegisterModel model)
        {
            Int32 CheckUserNameExitsResult = 0;
            Int32 CheckRegisterUserWithOutFacebook = 0;
            string AuthenticationStatus = String.Empty;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Add User to database and start spamming daemon here
            string ActivationKey = string.Empty;
            string UserName = model.UserName;
            ActivationKey = model.VerificationGuid;
            //return null;
            CheckUserNameExist objCheckUserNameExist = new CheckUserNameExist(model.UserName);
            CheckUserNameExitsResult = objCheckUserNameExist.FinialResults;
            if (CheckUserNameExitsResult > 0)
            {
                // Error UserName is in Use
                model.UserNameAvaliable = "ID not available";
                return View(model);
            }
            else
            {
                model.Password = Cryptography.Cryptography.Encrypt(model.Password);
                RegisterUserWithOutFacebook objRegisterUserWithOutFacebook = new RegisterUserWithOutFacebook(model.AccountID, model.UserName, model.Password, model.FirstName, model.LastName, model.Email, model.Email, "", model.VerificationGuid, 0, 0, false);
                // User Name is avaliable Enter User Into DB
                CheckRegisterUserWithOutFacebook = objRegisterUserWithOutFacebook.FinialResults;
                if (CheckRegisterUserWithOutFacebook > 0)
                {
                    // New User Entry Done Now Need to Form Authorincation
                    AuthenticationStatus = AuthenticateUser(model.UserName, model.Password, true);
                    if (AuthenticationStatus == "true")
                    {
                        //return Redirect("~/CourseHome/CourseHome?CourseID=10");
                        return RedirectToAction("RedirectPage");
                    }
                }
                else
                {
                    // May Be error occur please check re-tyre it.
                    model.UserNameAvaliable = "Error occur during registation please follow proper signup step again.Thanks!";
                    return View(model);
                }
            }
            return RedirectToAction("CLRegistration");
        }
        #endregion

        #region AuthenticateUser
        public string AuthenticateUser(string UserName, string Password, bool RememberME)
        {
            DataSet objDS = new DataSet();
            LoginModel objLoginModel = new LoginModel();
            AccountsDAL objAccountsDAL = new AccountsDAL();

            objDS = objAccountsDAL.CheckAccountExists(UserName, Password);
            if (objDS.Tables.Count > 0)
            {
                DataTable dataTable = objDS.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    List<LoginModel> _LoginList = new List<LoginModel>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        objLoginModel = new LoginModel
                        {
                            AccountID = Convert.ToInt64(row["AccountID"]),
                            Username = row["UserName"].ToString(),
                            Password = row["password"].ToString(),
                            AccountTitle = row["AccountTitle"].ToString(),
                        };
                        _LoginList.Add(objLoginModel);
                    }

                    objLoginModel = _LoginList.Single();
                }
                else
                {
                    return "false";
                }
            }
            if (objLoginModel.AccountID > 0)
            {
                if (RememberME)
                {
                    SetCookie("UserName", objLoginModel.AccountTitle.ToString());
                }

                SetCookie("ID", objLoginModel.AccountID.ToString());
                SetCookie("AccountTitle", objLoginModel.AccountTitle);

                FormsAuthentication.SetAuthCookie(objLoginModel.Username, true);
                FormsAuthentication.RedirectFromLoginPage(objLoginModel.Username, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                "user",
                DateTime.Now,
                DateTime.Now.AddMinutes(3),
                true,
                "fabiano!",
                FormsAuthentication.FormsCookiePath);

                // Create encrypted cookie
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }

                // Set and done
                Response.Cookies.Add(cookie); //Necessary, otherwise UserData property gets lost

                return "true";

            }
            if (objLoginModel.AccountID < 1)
            {
                return "false";
            }
            return String.Empty;
        }
        #endregion

        #region RedirectPage
        public ActionResult RedirectPage()
        {
            //ViewData["URL"] = "/CourseHome/CourseHome?CourseID=10";
            ViewData["URL"] = "/Profile/CurrentCourses";
            return View();
        }
        #endregion
    }
}
