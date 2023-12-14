using System.ComponentModel.DataAnnotations;

namespace SitShopHome.Web.Models;

public class ProductViewModel
{
    [Required(ErrorMessage = "Category is required")]
    public Guid CategoryId {get;set;} 
    
    [Required(ErrorMessage = "Picture is required")]
    public IFormFile? File {get;set;}
    [Required(ErrorMessage = "Title is required")]
    public string? Title {get;set;}
    [Required(ErrorMessage = "Description is required")]
    public string? Description {get;set;}
    [Required(ErrorMessage = "Price is required")]
    public int Price {get;set;}
}