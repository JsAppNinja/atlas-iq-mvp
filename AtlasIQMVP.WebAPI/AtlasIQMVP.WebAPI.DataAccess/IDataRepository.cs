using AtlasIQMVP.WebAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlasIQMVP.WebAPI.DataAccess
{
    public interface IDataRepository
    {
        Task<List<string>> GetCitiesOrCountiesByCharacter(string characters);
        
        Task<List<ProspectPortalRealEstate>> SearchPropertyByCityName(string cityName);
        Task<List<ProspectPortalRealEstate>> SearchPropertyByCountyName(string countyName);
        Task<List<ProspectPortalRealEstate>> SearchPropertyByCityNameAdvance(CityAdvanceSearchParams args);
    }
}
