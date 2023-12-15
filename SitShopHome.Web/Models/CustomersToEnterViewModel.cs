using System.ComponentModel.DataAnnotations;

namespace SitShopHome.Web.Models;

public class CustomersToEnterViewModel
{
    [Required(ErrorMessage ="Email field is required")]
    [EmailAddress(ErrorMessage ="That address cant be real, Email field")]
    public string? LoginEmail{get; set;}
    [Required(ErrorMessage = "Password field is required")]
    public string? Password{get;set;}
}