using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AtlasIQMVP.WebAPI.DataAccess.Models;

namespace AtlasIQMVP.WebAPI.DataAccess
{
    public class DataRepository : IDataRepository
    {
        private readonly cms_TVAContext dataContext;

        private const int AutoLimit = 10;

        public DataRepository(cms_TVAContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task<List<string>> GetCitiesOrCountiesByCharacter(string characters)
        {
            var outputListOfCitiesAndCounties = new List<string>();

            if (string.IsNullOrEmpty(characters))
                return Task.FromResult(new List<string>());

            var nameResults = dataContext.ProspectPortalRealEstate
                .Where(property => property.City.Contains(characters, StringComparison.CurrentCultureIgnoreCase) ||
                property.County.Contains(characters, StringComparison.CurrentCultureIgnoreCase));

            if (nameResults.Any())
            {
                outputListOfCitiesAndCounties = nameResults.Select(r => r.City).Distinct().ToList();
                outputListOfCitiesAndCounties.Concat(nameResults.Select(r => r.County).Distinct().ToList());
                outputListOfCitiesAndCounties = outputListOfCitiesAndCounties.Take(AutoLimit).ToList();
                outputListOfCitiesAndCounties.Sort();

            }
            return Task.FromResult(outputListOfCitiesAndCounties);
        }        

        public Task<List<ProspectPortalRealEstate>> SearchPropertyByCityName(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
                return Task.FromResult(new List<ProspectPortalRealEstate>());

            var tempResults = dataContext.ProspectPortalRealEstate.Where(c => c.City.ToLower().Equals(cityName.ToLower().Trim()));

            if (tempResults.Any())
                return Task.FromResult(tempResults.ToList());

            return Task.FromResult(new List<ProspectPortalRealEstate>());
        }

        public Task<List<ProspectPortalRealEstate>> SearchPropertyByCountyName(string countyName)
        {
            if (string.IsNullOrEmpty(countyName))
                return Task.FromResult(new List<ProspectPortalRealEstate>());

            var tempResults = dataContext.ProspectPortalRealEstate.Where(c => c.County.ToLower().Equals(countyName.ToLower().Trim()));

            if (tempResults.Any())
                return Task.FromResult(tempResults.ToList());

            return Task.FromResult(new List<ProspectPortalRealEstate>());
        }

        public async Task<List<ProspectPortalRealEstate>> SearchPropertyByCityNameAdvance(CityAdvanceSearchParams args)
        {
            var properties = await SearchPropertyByCityName(args.CityName);
            if (properties.Count == 0)
                return properties;

            //property name
            if (string.IsNullOrWhiteSpace(args.PropertyName))
            {
                properties = properties
                    .Where(p => p.Name.Equals(args.PropertyName, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            //property address
            if (string.IsNullOrWhiteSpace(args.PropertyAddress))
            {
                properties = properties
                    .Where(p => p.Address1.Equals(args.PropertyAddress, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            ////property building or site type
            //if (string.IsNullOrWhiteSpace(args.PropertyType))
            //{
            //    var types = args.PropertyType.Split(',');
            //    if (types.Length > 0)
            //    {
            //        properties = properties
            //            .Where(p => types.Contains(p.Buildingtype) || types.Contains(p.Site
            //            .ToList();
            //    }
            //}

            //property address
            if (string.IsNullOrWhiteSpace(args.PropertyAddress))
            {
                properties = properties
                    .Where(p => p.Address1.Equals(args.PropertyAddress, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            ////Minimum size
            //if(args.MinimumSize != null)
            //{
            //    properties = properties
            //       .Where(p => p.Address1.Equals(args.PropertyAddress, StringComparison.CurrentCultureIgnoreCase))
            //       .ToList();
            //}



            return new List<ProspectPortalRealEstate>();
        }
    }
}
