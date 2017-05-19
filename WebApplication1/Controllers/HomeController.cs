using System.Web.Mvc;
using unirest_net.http;
using Newtonsoft.Json;
namespace WebApplication1.Controllers
{
    }
public class RootObject
{
    public string text { get; set; }
    public int number { get; set; }
    public bool found { get; set; }
    public string type { get; set; }
}
public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    [HttpPost]

    public PartialViewResult Numbers(string type, int min, int max)
    {
        HttpResponse<string> response = Unirest.get("https://numbersapi.p.mashape.com/random/"+type+"?fragment=true&json=true&max="+max+"&min="+min)
            .header("X-Mashape-Key", "GILTcZVs1dmsh5CIFViX3zp0NDdEp1hnk2djsnVMUYlTZ4uVdn")
            .header("Accept", "text/plain")
            .asString();
        var Numbers = JsonConvert.DeserializeObject<RootObject>(response.Body);
        ViewBag.text = Numbers.text;
        ViewBag.type = Numbers.type;
        ViewBag.number = Numbers.number;
        return PartialView("_result");
    }



}
