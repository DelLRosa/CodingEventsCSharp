namespace Coding_Events;
using Microsoft.AspNetCore.Mvc;
using Coding_Events.Data;
using Coding_Events.Models;
using Coding_Events.ViewModels;
using Microsoft.EntityFrameworkCore;

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
        List<Event> events = context.Events.Include(e=>e.Category).ToList();

        return View(events);

    }

    // Get: <port>/events/add
    [HttpGet]
    public IActionResult Add()
    {
        List<EventCategory> categories = context.Categories.ToList();
        AddEventViewModel addEventViewModel = new AddEventViewModel(categories);
        return View( addEventViewModel);
        
    }

    [HttpPost]
    [Route("/Events/Add")]
    public IActionResult NewEvent(AddEventViewModel addEventViewModel)
    {
        if(ModelState.IsValid)
        {
            EventCategory theCategory = context.Categories.Find(addEventViewModel.CategoryId);
            Event newEvent= new Event
            {
                Name = addEventViewModel.Name,
                Description = addEventViewModel.Description,
                Category = theCategory
            }; 
            
            context.Events.Add(newEvent);
            context.SaveChanges();

            return Redirect("/Events");
        }
        return View(addEventViewModel);
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
            
            if(theEvent!=null)
            {
            context.Events.Remove(theEvent);
            }
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
