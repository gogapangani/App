using AdvertisementData;
using IAdvertsService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdvertService
{
    public class AdvertisementService : IAdvertService
    {
        public Advertisement GetAdvertisement(int id)
        {
            string url = $"https://localhost:44376/Api/Advertisements/{ id }";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var advertisement = response.Content.ReadAsAsync<Advertisement>().Result;

                    return advertisement;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            string url = $"https://localhost:44376/Api/Advertisements";
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var advertisement = response.Content.ReadAsAsync<IEnumerable<Advertisement>>().Result;

                    return advertisement;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public void InsertAdvertisement(Advertisement ad)
        {
            string url = $"https://localhost:44376/Api/Advertisements";

            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(ad);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                var response = client.PostAsync(url, stringContent).Result;
            }
        }

        public void UpdateAdvertisement(Advertisement ad)
        {
            string url = $"https://localhost:44376/Api/Advertisements/{ ad.Id}";

            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(ad);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                var response = client.PutAsync(url, stringContent).Result;
            }
        }

        public void DeleteAdvertisement(int id)
        {
            string url = $"https://localhost:44376/Api/Advertisements/{ id}";

            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(url).Result;
            }
        }
    }
}
