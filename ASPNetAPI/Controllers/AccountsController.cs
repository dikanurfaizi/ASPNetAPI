using API.ViewModels;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Login = API.ViewModels;

namespace ASPNetAPI.Controllers
{
    public class AccountsController : Controller
    {
        readonly HttpClient client = new HttpClient 
        { 
            BaseAddress = new Uri("https://localhost:44343/API/") 
        };

        // GET: Accounts
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Accounts");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Registers", register).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            IEnumerable<LoginViewModel> logins = null;
            var responseTalk = client.GetAsync("Accounts");
            responseTalk.Wait();
            var result = responseTalk.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LoginViewModel>>();
                readTask.Wait();
                logins = readTask.Result;
                return RedirectToAction("Details","Trainees", 
                    new { id = logins.FirstOrDefault(s => s.Email == login.Email 
                    && s.Password == login.Password).Id});
            }
            return RedirectToAction("Index","Accounts");
        }

        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePass(LoginViewModel login)
        {
            HttpResponseMessage response = client.PutAsJsonAsync("Accounts", login).Result;
            return RedirectToAction("Index","Accounts");
        }
    }
}