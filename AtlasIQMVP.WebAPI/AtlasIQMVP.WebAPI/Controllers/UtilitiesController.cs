using AtlasIQMVP.WebAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlasIQMVP.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        private readonly ILogger<UtilitiesController> _logger;

        public UtilitiesController(IDataRepository dataRepository, ILogger<UtilitiesController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;
        }

        [HttpGet("{searchitem}")]
        public async Task<ActionResult> GetCityAndCountyNames(string searchitem)
        {
            if (string.IsNullOrEmpty(searchitem) || searchitem.Length < 3)
                return Ok(new List<string>());
            try
            {
                var result = await _dataRepository.GetCitiesOrCountiesByCharacter(searchitem);
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
