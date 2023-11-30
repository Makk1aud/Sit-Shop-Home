using Microsoft.AspNetCore.Mvc;
using SitShopHome.API.Converters;
using System.ComponentModel;

namespace SitShopHome.API.Extensions
{
    public static class MvcOptionsExtensions
    {
        public static MvcOptions UseDateOnlyStringConverters(this MvcOptions options)
        {
            TypeDescriptor.AddAttributes(typeof(DateOnly), new TypeConverterAttribute(typeof(DateOnlyTypeConverter)));
            return options;
        }
    }
}
