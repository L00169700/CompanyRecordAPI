using CompanyRecordAPI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace CompanyRedordsIntegrationTests
{
    public class RecordsIntegrationTests : IClassFixture<TestSetting<Startup>>
    {
        //private HttpClient Client;

        //public RecordsIntegrationTests(TestSetting<Startup> fixture)
        //{
        //    Client = fixture.Client;
        //}

        //private async Task Login()
        //{
        //    var user = new
        //    {
        //        Password = "admin",
        //        Username = "admin"
        //    };

        //    //var request = "api/v1/Authorization/token";
        //    var request = "api/v1/Authorization";

        //    var response = await Client.PostAsync(request, ContentHelper.GetStringContent(user));
        //    if (response.Content != null)
        //    {
        //        var responseContent = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
        //        var token = "";
        //        if (result.ContainsKey("access_token"))
        //        {
        //            token = result["access_token"];
        //        }
        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        }
        //    }
        //}

        //[Fact]
        //public async Task TestGetCompanyRecordAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord";

        //    //Act
        //    var responseGet = await Client.GetAsync(request);

        //    //Asset
        //    responseGet.EnsureSuccessStatusCode();
        //}

        //[Fact]
        //public async Task TestGetByIdAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord/id/1";

        //    //Act
        //    var responseGet = await Client.GetAsync(request);

        //    //Asset
        //    responseGet.EnsureSuccessStatusCode();
        //}

        //[Fact]
        //public async Task TestGetByISINAsync()
        //{
        //    await Login();

        //    // Arrange

        //    var request = "api/v1/companyrecord/isin/CC38668345";
        //    //Act
        //    var responseGet = await Client.GetAsync(request);

        //    //Asset
        //    responseGet.EnsureSuccessStatusCode();
        //}

        //[Fact]
        //public async Task TestCreateAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord";
        //    var company = new
        //    {
        //        Name = "Create Test 1",
        //        Exchange = "Exchange 1",
        //        Ticker = "6752",
        //        ISIN = "CC38668345",
        //        Website = "Test.com"

        //    };
        //    //Act
        //    var responseGet = await Client.PostAsync(request, ContentHelper.GetStringContent(company));
            
        //    //Asset
        //    responseGet.EnsureSuccessStatusCode();
        //}

        //[Fact]
        //public async Task TestCreateInvalidCompanyAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord";
        //    var company = new
        //    {
        //        Name = "Create Test 2",
        //        Exchange = "Exchange 1",
        //        Ticker = "6752",
        //        ISIN = "1138668345",
        //        Website = "Test.com"

        //    };
        //    //Act
        //    var responseGet = await Client.PostAsync(request, ContentHelper.GetStringContent(company));

        //    //Asset
        //    Assert.Equal(responseGet.StatusCode.ToString(), HttpStatusCode.BadRequest.ToString());
        //}

        //[Fact]
        //public async Task TestCreateInvalidCompanySameISINAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord";
        //    var company = new
        //    {
        //        Name = "Create Test 3",
        //        Exchange = "Exchange 1",
        //        Ticker = "6752",
        //        ISIN = "JP38668345",
        //        Website = "Test.com"

        //    };
        //    //Act
        //    var responseGet = await Client.PostAsync(request, ContentHelper.GetStringContent(company));

        //    //Asset
        //    Assert.Equal(responseGet.StatusCode.ToString(), HttpStatusCode.BadRequest.ToString());
        //}


        //[Fact]
        //public async Task TestUpdateAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord";
        //    var company = new
        //    {
        //        Name = "Update Test 1",
        //        Exchange = "Exchange 1",
        //        Id = 1,
        //        Ticker = "6752",
        //        ISIN = "BR38668345",
        //        Website = "Test.com"

        //    };
        //    //Act
        //    var responseGet = await Client.PutAsync(request, ContentHelper.GetStringContent(company));
            
        //    //Asset
        //    responseGet.EnsureSuccessStatusCode();
        //}


        //[Fact]
        //public async Task TestUpdateInvalidISINAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord";
        //    var company = new
        //    {
        //        Name = "Update Test 1",
        //        Exchange = "Exchange 1",
        //        Id = 1,
        //        Ticker = "6752",
        //        ISIN = "1R38668345",
        //        Website = "Test.com"

        //    };

        //    //Act
        //    var responseGet = await Client.PutAsync(request, ContentHelper.GetStringContent(company));
            
        //    //Asset
        //    Assert.Equal(responseGet.StatusCode.ToString(), HttpStatusCode.BadRequest.ToString());
        //}

        //[Fact]
        //public async Task TestUpdateInvalidISINAlreadyInsertedAsync()
        //{
        //    await Login();

        //    // Arrange
        //    var request = "api/v1/companyrecord";
        //    var company = new
        //    {
        //        Name = "Update Test 1",
        //        Exchange = "Exchange 1",
        //        Id = 1,
        //        Ticker = "6752",
        //        ISIN = "JP38668345",
        //        Website = "Test.com"

        //    };

        //    //Act
        //    var responseGet = await Client.PutAsync(request, ContentHelper.GetStringContent(company));

        //    //Asset
        //    Assert.Equal(responseGet.StatusCode.ToString(), HttpStatusCode.BadRequest.ToString());
        //}

    }
}
