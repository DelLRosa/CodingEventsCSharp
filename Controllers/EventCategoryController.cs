using Microsoft.AspNetCore.Mvc;
using Coding_Events.Models;
using Coding_Events.Data;

namespace Coding_Events;

public class EventCategoryController : Controller
{
    private EventDbContext context;

    public EventCategoryController(EventDbContext dbContext)
    {
        
        context = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<EventCategory> categories = context.Categories.ToList();
        return View(categories);
    }
}
