using AtlasIQMVP.WebAPI.DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AtlasIQMVP.WebAPI.xUnitTests
{
    public class SearchControllerTests
    {
        private const string baseUrl = "https://localhost:44301";

        [Fact]
        public async Task Test_AutoPopulateCityHttp_Get_ListOfCityNames()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync("/Utilities/GetCityNamesThatContainSearchItem/est");
                var contentResult = response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var listOfCityNames = JsonConvert.DeserializeObject<List<string>>(contentResult.Result);
                Assert.True(listOfCityNames.Count > 0);
            }
        }

        [Fact]
        public async Task Test_AutoPopulateCity_LessThan_3_character_input_EmptyList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync("/Utilities/GetCityNamesThatContainSearchItem/es");
                var contentResult = response.Content.ReadAsStringAsync();

                var listOfCityNames = JsonConvert.DeserializeObject<List<string>>(contentResult.Result);
                Assert.Empty(listOfCityNames);
            }
        }

        [Fact]
        public async Task Test_AutoPopulateCountyHttp_Get_ListOfCountyNames()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync("/Utilities/GetCountyNamesThatContainSearchItem/scott");
                var contentResult = response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var listOfCityNames = JsonConvert.DeserializeObject<List<string>>(contentResult.Result);
                Assert.True(listOfCityNames.Count > 0);
            }
        }

        [Fact]
        public async Task Test_AutoPopulateCounty_LessThan_3_character_input_EmptyList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync("/Utilities/GetCountyNamesThatContainSearchItem/sc");
                var contentResult = response.Content.ReadAsStringAsync();

                var listOfCityNames = JsonConvert.DeserializeObject<List<string>>(contentResult.Result);
                Assert.Empty(listOfCityNames);
            }
        }

        [Fact]
        public async Task Test_SearchPropertiesByCityName_Get_ListOfCityNames()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync("/PropertySearch/ByCityName/forest");
                var contentResult = response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var listOfCityNames = JsonConvert.DeserializeObject<List<ProspectPortalRealEstate>>(contentResult.Result);
                Assert.True(listOfCityNames.Count > 0);
            }
        }

        [Fact]
        public async Task Test_SearchPropertiesByCountyName_Get_ListOfCityNames()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.GetAsync("/PropertySearch/ByCountyName/scott");
                var contentResult = response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var listOfCountyNames = JsonConvert.DeserializeObject<List<ProspectPortalRealEstate>>(contentResult.Result);
                Assert.True(listOfCountyNames.Count > 0);
            }
        }
    }
}
