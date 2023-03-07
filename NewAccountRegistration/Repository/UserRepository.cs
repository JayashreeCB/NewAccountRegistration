using Microsoft.EntityFrameworkCore;
using NewAccountRegistration.Interface;
using NewAccountRegistration.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using NewAccountRegistration.DataTransferModel;
using Newtonsoft.Json;
using System.Web;

namespace NewAccountRegistration.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly Cspusermgmtdb01Context _context;
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration, Cspusermgmtdb01Context cspusermgmtdb01Context)
        {
            _context = cspusermgmtdb01Context;
            _configuration = configuration;
        }

        public async Task<GetJarvisInfo> GetJarvisInfo(string SingpassID)
        {
            var uri = "http://localhost:7017/api/Jarvis/UserInfoBySingpassID/";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(SingpassID);

                response.EnsureSuccessStatusCode();

                var jarvisUser = new GetJarvisInfo();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    jarvisUser = await response.Content.ReadFromJsonAsync<GetJarvisInfo>();
                }
                else
                {
                    jarvisUser= null;
                }

                return jarvisUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }                                   
        }

        public async Task<string> UpdateJarvisUser(GetJarvisInfo jarvisInfo)
        {
            var uri = "http://localhost:7017/api/Jarvis/";

            try
            {
                var client = new HttpClient();  
                
                client.DefaultRequestHeaders.Accept.Clear();                
                
                var requestContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(jarvisInfo), Encoding.UTF8, "application/json");

                var response = await client.PutAsync(uri, requestContent);               

                response.EnsureSuccessStatusCode();

                var content = string.Empty;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    content = await response.Content.ReadAsStringAsync();
                }

                return content;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync<User>();
        }

        public async Task<MyInfo> GetMyinfo(int SingpassId)
        {

            MyInfo userinfo = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(generateURI(SingpassId)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userinfo = JsonConvert.DeserializeObject<MyInfo>(apiResponse);

                }

            }
            return userinfo ?? new MyInfo();
        }

        protected string generateURI(int singpassId)
        {
            string longurl = _configuration.GetValue<string>("JTCServiceEndpoints:Myinfoservice");
        //https://localhost:7082/api/MyInfo?SingpassId=1
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["SingpassId"] = "1";          
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();
            return longurl;
        }

        public async Task<GetAddressDto> GetAddress(int Postalcode)
        {
            var uri = "http://localhost:7017/api/Jarvis/GetAddress/";

            try 
            { 
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(Postalcode.ToString());

            response.EnsureSuccessStatusCode();

            var jarvisUser = new GetAddressDto();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                jarvisUser = await response.Content.ReadFromJsonAsync<GetAddressDto>();
            }
            else
            {
                jarvisUser = null;
            }

            return jarvisUser;
        }
            catch (Exception ex)
            {

                throw ex;
            }

}
    }
}
