using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Text;
using System.Text.Json;
using SQLite;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Net.Http.Json;
namespace EADCA2AndroidApp.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public string Developer { get; set; }
        public DateTime releaseDate { get; set; }
        public string platform { get; set; }

        //Base URI - The first part of the call to the API
        private static readonly string baseURI = "https://10.0.2.2:5001/api/";
        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
#if DEBUG
        static HttpClientHandler insecureHandler = GetInsecureHandler();
        private static readonly HttpClient httpClient = new HttpClient(insecureHandler);
#else
   HttpClient httpClient = new HttpClient();
#endif

        //Get Games by platform
        public static async Task<List<Game>> geGamesByPlatform(string platformIn)
        {
            try
            {
                var result = await httpClient.GetAsync(baseURI + $"Games/getGamesByPlatform?platformIN={platformIn}");
                var GameData = await result.Content.ReadAsStreamAsync();
                List<Game> fetchedGames = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Game>>(GameData);
                result.EnsureSuccessStatusCode();
                return fetchedGames;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Get All Games
 public static async Task<List<Game>> getAllGames()
 {
     try
     {
         var result = await httpClient.GetAsync(baseURI + "Games/");
         var GameData = await result.Content.ReadAsStreamAsync();
         var fetchedGames = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Game>>(GameData);
         result.EnsureSuccessStatusCode();
         return fetchedGames;
     }
     catch (Exception e)
     {
         Console.WriteLine(e.Message);
         return null;
     }
 }




}
}
