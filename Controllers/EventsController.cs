namespace Coding_Events;
using Microsoft.AspNetCore.Mvc;
using Coding_Events.Data;
using Coding_Events.Models;

public class EventsController : Controller
{
    private EventDbContext context;

    public EventsController(EventDbContext dbContext)
    {
        context = dbContext;
    }


    // GET: <port>/events
    [HttpGet]
    public IActionResult Index() 
    {
        
        List<Event> events = context.Events.ToList();
        return View(events);

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
        // EventData.Add(newEvent);
        context.Events.Add(newEvent);
        context.SaveChanges();

        return Redirect("/Events");
    }

    [HttpGet]
    public IActionResult Delete()
    {
        ViewBag.events =context.Events.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Delete(int[] eventIds)
    {
        foreach (int eventId in eventIds)
        {
            Event? theEvent = context.Events.Find(eventId);
            context.Events.Remove(theEvent);
        }

        context.SaveChanges();

        return Redirect("/Events");
    }

    // [HttpPost]
    // [Route("/event/edit/{eventId}")]
    // public IActionResult Edit (int eventId)
    // {
    //    Event editEvent = EventData.GetById(eventId);
    //    ViewBag.eventToEdit = editEvent;
    //    ViewBag.title = "Edit Event "+ editEvent.Name + "(id = "+editEvent.Id + ")";

    //     return View();
    // }


}
