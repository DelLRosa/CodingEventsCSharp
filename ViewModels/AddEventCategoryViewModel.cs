using System.ComponentModel.DataAnnotations;

namespace Coding_Events.ViewModels;

public class AddEventCategoryViewModel
{
    [Required(ErrorMessage ="This field is required")]
    [StringLength(20, MinimumLength =3,ErrorMessage ="Name must be between 3 and 20 characters long")]
    public string? Name{get;set;}
}
