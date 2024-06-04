namespace Coding_Events;
using Microsoft.AspNetCore.Mvc;
public class EventsController : Controller
{

    // GET: <port>/events
    [HttpGet]
    public IActionResult Index() 
    {
        
        ViewBag.events = EventData.GetAll();
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
    public IActionResult NewEvent(Event newEvent)
    {
        EventData.Add(newEvent);

        return Redirect("/Events");
    }

    [HttpGet]
    public IActionResult Delete()
    {
        ViewBag.events = EventData.GetAll();
        return View();
    }

    [HttpPost]
    public IActionResult Delete(int[] eventIds)
    {
        foreach (int eventId in eventIds)
        {
            EventData.Remove(eventId);
        }
        return Redirect("/Events");
    }

    [HttpPost]
    [Route("/event/edit/{eventId}")]
    public IActionResult Edit (int eventId)
    {
       Event editEvent = EventData.GetById(eventId);
       ViewBag.eventToEdit = editEvent;
       ViewBag.title = "Edit Event "+ editEvent.Name + "(id = "+editEvent.Id + ")";

        return View();
    }

    [HttpPost]
    [Route("/events/edit")]
    public IActionResult SubmitEditEventForm(int eventId, string name, string description)
    {
        Event editEvent = EventData.GetById(eventId);
        editEvent.Name = name;
        editEvent.Description = description;

        return Redirect("/events");
    }


}
