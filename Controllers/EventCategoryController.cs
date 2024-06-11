using Microsoft.AspNetCore.Mvc;
using Coding_Events.Models;
using Coding_Events.Data;
using Coding_Events.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    [HttpGet]
    public IActionResult Create()
    {
        AddEventCategoryViewModel addEventCategoryViewModel= new();
        return View(addEventCategoryViewModel);
    }

    [HttpPost("/createCategory")]
    public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
    {
        if(ModelState.IsValid)
        {
            EventCategory newEventCategory = new EventCategory
            {
                Name = addEventCategoryViewModel.Name
            };
            context.Categories.Add(newEventCategory);
            context.SaveChanges();

            return Redirect("/eventcategory/Index");
        }
        return View("Create",addEventCategoryViewModel);
    }
}
