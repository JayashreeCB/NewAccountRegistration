using Microsoft.EntityFrameworkCore;
using NewAccountRegistration.Interface;
using NewAccountRegistration.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace NewAccountRegistration.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly Cspusermgmtdb01Context _context;
        public UserRepository( Cspusermgmtdb01Context cspusermgmtdb01Context)
        {
            _context = cspusermgmtdb01Context;
        }

        public async Task<GetJarvisInfo> GetJarvisInfo(string SingpassID)
        {
            var uri = "http://localhost:7017/api/Jarvis/";

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
                
                var requestContent = new StringContent(JsonSerializer.Serialize(jarvisInfo), Encoding.UTF8, "application/json");

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
    }
}
