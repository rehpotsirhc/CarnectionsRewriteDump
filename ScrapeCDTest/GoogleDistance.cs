using Newtonsoft.Json;
using ScrapeCDTest.models;
using ScrapeCDTest.models.Google;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeCDTest
{
    public static class GoogleDistance
    {


        private const string API_KEY = "AIzaSyD0HHgCCE-aeckWjEJ7eIr-EMr8HYLVGVo";

        // https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=90210&destinations=84119&key=


        //somehwere in here we need to validate the GoogleDistanceMatrix object
        public static async Task<GoogleDistanceMatrix> GetDistanceMatrix(this string endpoint)
        {
            string response = await HttpGet.Get(endpoint);
            if (response == null)
                return null;

            try
            {
                return JsonConvert.DeserializeObject<GoogleDistanceMatrix>(response);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static async Task<TransformedDistanceMatrix> TransformDistanceMatrix(this Task<GoogleDistanceMatrix> matrix)
        {
            return new TransformedDistanceMatrix(await matrix);
        }

   

       


        public static string BuildEndpoint(CityStateZip pickup, CityStateZip delivery, string apiKey)
        {
            var sb = new StringBuilder();
            sb.Append("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial").Append("&");
            sb.AppendFormat("{0}={1}", "origins", pickup.ToString()).Append("&");
            sb.AppendFormat("{0}={1}", "destinations", delivery.ToString()).Append("&");
            sb.AppendFormat("{0}={1}", "key", apiKey);
            return sb.ToString();
        }

        public static string BuildEndpoint(CityStateZip pickup, CityStateZip delivery)
        {
            return BuildEndpoint(pickup, delivery, API_KEY);
        }




    }
}
