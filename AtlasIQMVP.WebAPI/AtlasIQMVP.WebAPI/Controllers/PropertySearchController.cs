using AtlasIQMVP.WebAPI.DataAccess;
using AtlasIQMVP.WebAPI.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlasIQMVP.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PropertySearchController: ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        private readonly ILogger<PropertySearchController> _logger;

        public PropertySearchController(IDataRepository dataRepository,
            ILogger<PropertySearchController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;
        }

        [HttpGet("{cityname}")]
        public async Task<ActionResult> ByCityName(string cityname)
        {
            if (string.IsNullOrEmpty(cityname))
                return Ok(new List<ProspectPortalRealEstate>());
            try
            {
                var result = await _dataRepository.SearchPropertyByCityName(cityname);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return StatusCode(500, "Error occurred on the server");
        }


        [HttpGet("{countyname}")]
        public async Task<ActionResult> ByCountyName(string countyname)
        {
            if (string.IsNullOrEmpty(countyname))
                return Ok(new List<ProspectPortalRealEstate>());
            try
            {
                var result = await _dataRepository.SearchPropertyByCountyName(countyname);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return StatusCode(500, "Error occurred on the server");
        }
    }
}
