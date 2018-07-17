using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Brainence.Helpers;
using Brainence.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brainence.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext context;

        public HomeController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.SentenceRecords.OrderByDescending(i => i.Id).ToList());
        }


        [HttpPost]
        public async Task<IActionResult> Index(PostViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                var text = "";
                using (var stream = pvm.File.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    text = await reader.ReadToEndAsync();
                }


                var listResult = text.Parse(pvm.Word);
                await context.AddRangeAsync(listResult);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}