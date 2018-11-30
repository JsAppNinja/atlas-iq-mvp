using Microsoft.Extensions.Configuration;

namespace AtlasIQMVP.DataAccessLayer
{
    public static class Extensions
    {
        //public static string ToFriendlyPropertyStatus(this PropertyStatusEnum status)
        //{
        //    switch (status)
        //    {
        //        case PropertyStatusEnum.AVAILABLE:
        //            return "Available";
        //        case PropertyStatusEnum.UNAVAILABLE:
        //            return "Unavailable";
        //        case PropertyStatusEnum.DELETED:
        //            return "Deleted";
        //        default:
        //            throw new NotImplementedException();
        //    }
        //}

        //public static string ToFriendlyPropertyType(this PropertyTypeEnum type)
        //{
        //    switch (type)
        //    {               
        //        case PropertyTypeEnum.BUILDING:
        //            return "Building";
        //        case PropertyTypeEnum.SITE:
        //            return "Site";
        //        default:
        //            throw new NotImplementedException();
        //    }
        //}

        public static class ConfigHelper
        {
            public static IConfiguration GetConfig()
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(System.AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build();
            }
        }
    }
}
