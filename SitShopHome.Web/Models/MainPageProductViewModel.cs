namespace SitShopHome.Web.Models;

public class MainPageProductViewModel
{
    public Guid ProductId { get; set; }
    public string? ProductTitle { get; set; }

    public string? ProductImage { get; init; }
    public int ProductPrice {get;set;}
}