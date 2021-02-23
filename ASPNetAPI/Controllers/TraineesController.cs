using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASPNetAPI.Controllers
{
    public class TraineesController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44343/API/")
        };

        // GET: Trainees
        public ActionResult Index()
        {
            return RedirectToAction("Details", "Trainees");
        }

        public ActionResult Edit(int Id)
        {
            IEnumerable<Trainee> trainees = null;
            var responseTalk = client.GetAsync("Trainees");
            responseTalk.Wait();
            var result = responseTalk.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Trainee>>();
                readTask.Wait();
                trainees = readTask.Result;
            }
            return View(trainees.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Edit(Trainee trainee, int Id)
        {
            HttpResponseMessage response = client.PutAsJsonAsync<Trainee>("Trainees/" + Id, trainee).Result;
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync("Trainees");
            var data = await response.Content.ReadAsAsync<IList<Trainee>>();
            var trainee = data.FirstOrDefault(s => s.Id == id);
            return View(trainee);
        }
    }
}