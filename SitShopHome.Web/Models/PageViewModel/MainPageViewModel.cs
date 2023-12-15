using Entities.Models;

namespace SitShopHome.Web.Models.PageViewModel;

public class MainPageViewModel
{
    public List<MainPageProductViewModel>? Products {get;set;}
    public int PageNumber {get;set;}

    public int TotalCountOnPage {get;set;}
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => Products.Count > 1 ;

    public MainPageViewModel(List<MainPageProductViewModel> products, int pageNumber)
    {
        Products = products;
        PageNumber = pageNumber;
     
    }
}