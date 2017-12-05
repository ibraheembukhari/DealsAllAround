using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DealsAllAround.DataAccess;
using DealsAllAround.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web.Security;

namespace DealsAllAround.Controllers
{
    public class HomeController : Controller
    {
        private IUserInfoProvider userInfoProvider = new UserInfoProvider();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User userpro)
        {         
            if (ModelState.IsValid)
            {
                DealsViewModel dealsVM = new DealsViewModel();
                dealsVM.Registeration(userpro);
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("whitefather91@gmail.com")); 
                message.Subject = "Your email subject";
                message.Body = string.Format(body, userpro.name, userpro.email, userpro.password, userpro.contact, userpro.brand, userpro.address, userpro.message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent","Home");
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(LoginInfo user)
        {
            if (ModelState.IsValid)
            { 
            if (userInfoProvider.IsValid(user.email, user.password))
            {
                    Session["SessionEmail"] = user.email;   
                    //FormsAuthentication.SetAuthCookie(user.email, user.rememberme);
                    return RedirectToAction("Choose");
                }
            else
            {
                ViewBag.Message = "Invalid Email or Password";
                return View();
            }
        }
            return View(user);
        }
        public ActionResult Choose()
        {

            var vSessionValue = new LoginInfo();
            try
            {
                if ((Object)Session["SessionEmail"] != null)
                    vSessionValue.sessions = "Welcome  " +
            Session["SessionEmail"].ToString();
                else
                    vSessionValue.sessions = "Session Expired";
            }
            catch
            {
            }
            return View(vSessionValue);
        }
        public ActionResult Logout()
        {
            Session.Remove("SessionEmail");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(User userpro)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("whitefather91@gmail.com")); //replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, userpro.name, userpro.email, userpro.message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent", "Home");
                }
            }
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        
        public ActionResult AddDeals()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDeals(Deal dealpro)
        {
                 if (ModelState.IsValid)
                            {
                                DealsViewModel dealsVM = new DealsViewModel();
                                dealsVM.GetDetails(dealpro);
                                return RedirectToAction("Choose");
                            }
                            return View();
        }
        public ActionResult UpdateDeals()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateDeals(Deal dealpro)
        {
            if (ModelState.IsValid)
            {
                DealsViewModel dealsVM = new DealsViewModel();
                dealsVM.UpdateData(dealpro);
                return RedirectToAction("Choose");
            }
            return View();
        }
        public ActionResult ShowAllData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowAllData(DealsViewModel dealsVM, Deal dp)
        {
            List<Deal> dealpro = dealsVM.GetAllData();
            return View(dealpro);
        }
        public ActionResult DeleteDeals()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteDeals(Deal dealpro)
        {
            if (ModelState.IsValid)
            {
                DealsViewModel dealsVM = new DealsViewModel();
                dealsVM.DeleteData(dealpro);
                return RedirectToAction("DeleteDeals");
            }
            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}

