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
using CourseLogicWeb.ConfigurationService;
using CourseLogicWeb.Cryptography;

namespace CourseLogicWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

   
       

        public ActionResult Index()
        {
            //return View();
            LoginModel model = new LoginModel();
            if (ModelState.IsValid)
            {
                return View(model);
                //return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.RememberMe)
                {
                    if (Request.Cookies["CLU"] != null)
                    {
                        DeleteCookieRememberMe();
                    }
                }
                
                if (Request.Cookies["CLU"] != null)
                {
                    model.RememberMe = true;
                    model.Username = Request.Cookies["CLU"].Value.ToString();
                }            

                string AuthenticationStatus = String.Empty;
                _connectSession = new ConnectSession(APPLICATION_KEY, SECRET_KEY);
                _connectSession.Logout();
                _connectSession.Login();

                //Check User Is Login in with Facebook
                if (_connectSession.IsConnected())
                {
                    AuthenticationStatus = ManageFacebook();
                    if (AuthenticationStatus == "true")
                    {
                        return Redirect("~/Profile/CurrentCourses");
                        //return Redirect("~/CourseHome/CourseHome?CourseID=10&IsTopVoted=0");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(model.Password))
                        {
                            model.Password = Cryptography.Cryptography.Encrypt(model.Password);
                            AuthenticationStatus = AuthenticateUser(model.Username, model.Password, model.RememberMe);
                        }
                        if (AuthenticationStatus == "true")
                        {
                            return Redirect("~/Profile/CurrentCourses");
                            //return Redirect("~/CourseHome/CourseHome?CourseID=10&IsTopVoted=0");
                        }
                        else
                        {
                            ViewData["Message"] = string.Format("Facebook user does not exist !");
                            WebCookies WebCookieInstance = new WebCookies();
                            WebCookieInstance.ClearCookies();
                            FormsAuthentication.SignOut();
                            return View(model);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        model.Password = Cryptography.Cryptography.Encrypt(model.Password);
                        AuthenticationStatus = AuthenticateUser(model.Username, model.Password, model.RememberMe);
                    }
                    if (AuthenticationStatus == "true")
                    {
                        return Redirect("~/Profile/CurrentCourses");
                        //return Redirect("~/CourseHome/CourseHome?CourseID=10&IsTopVoted=0");
                    }
                    else
                    {
                        if ((model.Username != null || model.Password != null))
                        {
                            if (Request.Cookies["CLU"] != null)
                            {
                                model.RememberMe = true;
                                model.Username = Request.Cookies["CLU"].Value.ToString();
                                if (AuthenticationStatus == "false" && model.Password != null)
                                {
                                    ViewData["Message"] = string.Format("Invalid username/password combination. Please try again.");
                                }
                            }
                            else
                            {
                                ViewData["Message"] = string.Format("Invalid username/password combination. Please try again.");
                            }
                        }
                        WebCookies WebCookieInstance = new WebCookies();
                        WebCookieInstance.ClearCookies();
                        FormsAuthentication.SignOut();
                        return View(model);
                    }
                }
            }
            else
            {
                //ViewData["Message"] = string.Format("Invalid username/password combination. Please try again.");
                return View(model);
            }
        }

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
                            ProfileImage = row["ProfileImage"].ToString(),
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
                    SetCookieRememberMe("CLU", objLoginModel.Username.ToString(), DateTime.Now, new TimeSpan(30, 0, 0, 0));
                }

                SetCookie("ID", objLoginModel.AccountID.ToString());
                SetCookie("AccountTitle", objLoginModel.AccountTitle);
                SetCookie("PImage", objLoginModel.ProfileImage);

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
                            ProfileImage = row["ProfileImage"].ToString(),
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
                //if (RememberME)
                //{
                SetCookie("UserName", objLoginModel.AccountTitle.ToString());
                //}

                SetCookie("ID", objLoginModel.AccountID.ToString());
                SetCookie("AccountTitle", objLoginModel.AccountTitle);
                SetCookie("PImage", objLoginModel.ProfileImage);

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

        #region SetCookieRememberMe
        private void SetCookieRememberMe(string Name, string Value, DateTime ExpireDate, TimeSpan ExpireTime)
        {
            HttpCookie cookie = new HttpCookie(Name, Value);
            cookie.Expires = ExpireDate + ExpireTime;
            Response.Cookies.Add(cookie);
        }
        #endregion

        #region DeleteCookieRememberMe
        public ActionResult DeleteCookieRememberMe()
        {
            HttpCookie cookie = new HttpCookie("CLU", "XYZ");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return View();
        }
        #endregion

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

                    return FacebookUserAuthicatedCheck;
                }
            }

            return FacebookUserAuthicatedCheck;
        }
        #endregion

 
        public String getPassword(String userId, String mailId)
        {
            string result = "false";
            string dpwd = "";
            AccountsDAL objLogin = new AccountsDAL();
            string pwd = "";
            string username = "";
            string mailid = "";
            DataSet objDS = new DataSet();
            objDS = objLogin.getPassword(userId, mailId);
            if (objDS.Tables.Count > 0)
            {
                if (objDS.Tables[0].Rows.Count > 0)
                {
                    pwd = objDS.Tables[0].Rows[0]["Password"].ToString();
                    username = objDS.Tables[0].Rows[0]["UserName"].ToString();
                    mailid = objDS.Tables[0].Rows[0]["PrimaryEmail"].ToString();
                    //decryption
                    dpwd = Cryptography.Cryptography.Decrypt(pwd);
                    SendEmail objSendEmail = new SendEmail();
                    Boolean btnIsMailSent = objSendEmail.sendRecoveredPasswordMail(username, mailid, dpwd);
                    if (btnIsMailSent == true)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "2";
                    }
                }
                else
                {
                    result = "0";
                }
            }
            else
            {
                return "0";
            }

            return result;

        }


    }
}
