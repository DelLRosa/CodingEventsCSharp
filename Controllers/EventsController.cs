namespace Coding_Events;
using Microsoft.AspNetCore.Mvc;
public class EventsController : Controller
{
    static private List<string> Events = new List<string>{"Gundam Build Night", "Salsa Class", "Bike Ride"};

    // GET: <port>/events
    [HttpGet]
    public IActionResult Index() 
    {
        
        ViewBag.events = Events;
        return View();

    }
    // Get: <port>/events/add
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Route("/Events/Add")]
    public IActionResult NewEvent(string name)
    {
        Events.Add(name);
        return Redirect("/Events");
    }
}
