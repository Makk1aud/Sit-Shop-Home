using Shared.DataTransferObjects;
using SitShopHome.Web.Models;

namespace SitShopHome.Web.Service;

public static class ConvertService
{
    public static List<MainPageProductViewModel> ConvertProductDTOtoViewModel(IEnumerable<ProductDTO> productDTOList)
    {
        List<MainPageProductViewModel> productList = new List<MainPageProductViewModel>();
        foreach(var productDTO in productDTOList)
        {
            var product = new MainPageProductViewModel()
            {
                ProductId = productDTO.ProductId,
                ProductImage = productDTO.ProductImage,
                ProductPrice = productDTO.ProductPrice,
                ProductTitle = productDTO.ProductTitle
            };
            productList.Add(product);
        }

        return productList;
    }

    public static ProductForManipulationDTO ConvertProductViewModelToDTO(ProductViewModel model, string imagePath)
    {
        var product = new ProductForManipulationDTO()
        {
            ProductTitle = model.Title,
            ProductCategoryId = model.CategoryId,
            ProductDescription = model.Description,
            ProductDisplay = true,
            ProductImage = imagePath,
            ProductPrice = model.Price 
        };

        return product;
    }
}