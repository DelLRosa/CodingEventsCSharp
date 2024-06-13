using Coding_Events.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coding_Events.ViewModels;

public class AddEventViewModel
{
    public string? Name {get; set;}
    public string? Description {get; set;}
    public int CategoryId {get;set;}
    public List<SelectListItem>? Categories {get;set;}


    public AddEventViewModel()
    {
    }

    public AddEventViewModel(List<EventCategory> categories)
    {
        Categories = new List<SelectListItem>();
        foreach (var category in categories)
        {
            Categories.Add(new SelectListItem
            {
                Value = category.Id.ToString(),
                Text= category.Name
            });
        }
    }
}
