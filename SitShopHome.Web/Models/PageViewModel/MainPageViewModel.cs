using Entities.Models;

namespace SitShopHome.Web.Models.PageViewModel;

public class MainPageViewModel
{
    public List<MainPageProductViewModel>? Products {get;set;}
    public int PageNumber {get;set;}

    public int TotalCountOnPage {get;set;}
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => Products.Count > 1 ;
    
    public int? MinPrice {get;set;}
    public int? MaxPrice {get;set;}
    public string? SearchName {get;set;}
    public Guid? ProductCategoryId {get;set;}

}