using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Helpers
{
    class SendRequestAPI
    {
        public HttpClient httpClient = new HttpClient();
        public async Task<ApiResponse> GetRequest(string apiUrl)
        {

            try
            {
                string url = $"{Properties.Resources.web_api_url}/{apiUrl}";

                HttpResponseMessage response = await httpClient.GetAsync(url);

                string ResponseContent = response.Content.ReadAsStringAsync().Result;

                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(ResponseContent);

                return apiResponse;

            }
            catch(Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }

        public async Task<ApiResponse> PostRequest(string apiUrl, object model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"{Properties.Resources.web_api_url}/{apiUrl}";

                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                string ResponseContent = response.Content.ReadAsStringAsync().Result;
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(ResponseContent);

                return apiResponse;
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
            
        }

        public async Task<ApiResponse> PutRequest(string apiUrl, object model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"{Properties.Resources.web_api_url}/{apiUrl}";

                HttpResponseMessage response = await httpClient.PutAsync(url, content);
                string ResponseContent = response.Content.ReadAsStringAsync().Result;
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(ResponseContent);
                return apiResponse;
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
            
        }

        public async Task<ApiResponse> DeleteRequest(string apiUrl, object model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"{Properties.Resources.web_api_url}/{apiUrl}";

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = await httpClient.SendAsync(request);

                string ResponseContent = response.Content.ReadAsStringAsync().Result;
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(ResponseContent);
                return apiResponse;
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }

    }
}
