using ScrapeCDTest.models;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScrapeCDTest.models.Common;
using ScrapeCDTest.models.CentralDispatch;
using System.Diagnostics;

namespace ScrapeCDTest
{
    public static class ScrapeCD
    {

        public static string BuildCookieHeader()
        {
            /*
             * visitedDashboard, _gid, PHPSESSID are required
             */

            var sb = new StringBuilder();
            string sep = "; ";
            sb.AppendFormat("{0}={1}", "visitedDashboard", "1").Append(sep);
            //sb.AppendFormat("{0}={1}", "defaultView", "1").Append(sep); //this was listed twice?
            //sb.AppendFormat("{0}={1}", "__utmt=", "1").Append(sep);
            //sb.AppendFormat("{0}={1}", "__utma", "262503198.138626099.1495316764.1495557398.1495557398.1").Append(sep);
            //sb.AppendFormat("{0}={1}", "__utmb", "262503198.10.10.1495557398").Append(sep);
            //sb.AppendFormat("{0}={1}", "__utmc", "262503198").Append(sep);
            //sb.AppendFormat("{0}={1}", "__utmz", "262503198.1495557398.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)").Append(sep);
            //sb.AppendFormat("{0}={1}", "_gat", "1").Append(sep);
            //sb.AppendFormat("{0}={1}", "__ga", "GA1.2.138626099.1495316764").Append(sep);
            sb.AppendFormat("{0}={1}", "_gid", "GA1.2.1877014367.1495558286").Append(sep);
            //sb.AppendFormat("{0}={1}", "test-persistent", "1").Append(sep);
            //sb.AppendFormat("{0}={1}", "test-session", "1").Append(sep); //again, twice
            sb.AppendFormat("{0}={1}", "PHPSESSID", "90de1b4bdc671d655474aebf413a632a");

            return sb.ToString();
        }


        //somehwere in here we need to validate the CentralDispatchListings object
        public static async Task<CDListings> GetListings(this string endpoint)
        {
            string response = await HttpGet.Get(endpoint, "Cookie", BuildCookieHeader());
            if (response == null)
                return null;
            try
            {
                // return JsonConvert.DeserializeObject<CentralDispatchListings>(response, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                return JsonConvert.DeserializeObject<CDListings>(response);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static CDListingsTransformed ScrapeAll()
        {
            double minPerMile = .1;
            int perPage = 500;
            var dic = new Dictionary<int, TransformedListing>();
            var allListings = new CDListingsTransformed();

            int total = perPage + 1;
            for (int t = 0,i = 0; t < total; t += perPage, i++)
            {
                allListings.TransformAndRecord(ScrapeCD.BuildEndpointAll(minPerMile, t, perPage)
                      .GetListings());
                total = allListings.Counts[i];
            }
            return allListings;
        }

   


        public static string BuildEndpoint(CityStateZip pickup, int pickupRadius, CityStateZip delivery, int deliveryRadius, TrailerType trailerType, bool operable, int shipWithin, double minPerMile)
        {
            // string condition = operable ? "1" : "0";
            var sb = new StringBuilder();
            sb.Append("https://www.centraldispatch.com/protected/listing-search/get-results-ajax?").Append("&");
            sb.AppendFormat("{0}={1}", "FatAllowCanada", "0").Append("&");
            sb.AppendFormat("{0}={1}", "pickupCitySearch", "1").Append("&");
            sb.AppendFormat("{0}={1}", "pickupRadius", pickupRadius.ToString()).Append("&");
            sb.AppendFormat("{0}={1}", "pickupCity", WebUtility.UrlEncode(pickup.City)).Append("&");
            sb.AppendFormat("{0}={1}", "pickupState", WebUtility.UrlEncode(pickup.State.Abbreviation)).Append("&");
            sb.AppendFormat("{0}={1}", "pickupZip", pickup.Zip).Append("&");
            sb.AppendFormat("{0}={1}", "origination_valid", "1").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryCitySearch", "1").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryRadius", deliveryRadius.ToString()).Append("&");
            sb.AppendFormat("{0}={1}", "deliveryCity", WebUtility.UrlEncode(delivery.City)).Append("&");
            sb.AppendFormat("{0}={1}", "deliveryState", WebUtility.UrlEncode(delivery.State.Abbreviation)).Append("&");
            sb.AppendFormat("{0}={1}", "deliveryZip", delivery.Zip).Append("&");
            sb.AppendFormat("{0}={1}", "destination_valid", "1").Append("&");
            sb.AppendFormat("{0}={1}", "trailerType", "").Append("&");
            sb.AppendFormat("{0}={1}", "vehiclesRun", "").Append("&"); //?
            sb.AppendFormat("{0}={1}", "minVehicles", "1").Append("&");
            sb.AppendFormat("{0}={1}", "maxVehicles", "").Append("&");
            sb.AppendFormat("{0}={1}", "shipWithin", shipWithin.ToString()).Append("&");
            sb.AppendFormat("{0}={1}", "minPayPrice", "").Append("&");
            sb.AppendFormat("{0}={1}", "minPayPerMile", minPerMile.ToString()).Append("&");
            sb.AppendFormat("{0}={1}", "highlightPeriod", "0").Append("&");
            sb.AppendFormat("{0}={1}", "listingsPerPage", "100").Append("&");
            sb.AppendFormat("{0}={1}", "postedBy", "").Append("&");
            sb.AppendFormat("{0}={1}", "primarySort", "1").Append("&");
            sb.AppendFormat("{0}={1}", "secondarySort", "4");
            return sb.ToString();
        }

        public static string BuildEndpointAll(double minPerMile, int pageStart, int listingsPerPage)
        {
            var sb = new StringBuilder();
            sb.Append("https://www.centraldispatch.com/protected/listing-search/get-results-ajax?").Append("&");
            //   sb.AppendFormat("{0}={1}", "FatAllowCanada", "0").Append("&");
            sb.AppendFormat("{0}={1}", "pickupAreas[]", "All").Append("&");
            sb.AppendFormat("{0}={1}", "pickupCitySearch", "0").Append("&");
            sb.AppendFormat("{0}={1}", "pickupRadius", "25").Append("&");
            sb.AppendFormat("{0}={1}", "pickupCity", "").Append("&");
            sb.AppendFormat("{0}={1}", "pickupState", "").Append("&");
            sb.AppendFormat("{0}={1}", "pickupZip", "").Append("&");
            sb.AppendFormat("{0}={1}", "origination_valid", "1").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryAreas[]", "All").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryCitySearch", "0").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryRadius", "25").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryCity", "").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryState", "").Append("&");
            sb.AppendFormat("{0}={1}", "deliveryZip", "").Append("&");
            sb.AppendFormat("{0}={1}", "destination_valid", "1").Append("&");
            sb.AppendFormat("{0}={1}", "trailerType", "").Append("&");
            sb.AppendFormat("{0}={1}", "vehiclesRun", "").Append("&"); //?
            sb.AppendFormat("{0}={1}", "minVehicles", "1").Append("&");
            sb.AppendFormat("{0}={1}", "maxVehicles", "").Append("&");
            sb.AppendFormat("{0}={1}", "shipWithin", "60").Append("&");
            sb.AppendFormat("{0}={1}", "minPayPrice", "").Append("&");
            sb.AppendFormat("{0}={1}", "minPayPerMile", minPerMile.ToString()).Append("&");
            sb.AppendFormat("{0}={1}", "highlightPeriod", "0").Append("&");
            sb.AppendFormat("{0}={1}", "listingsPerPage", listingsPerPage).Append("&");
            sb.AppendFormat("{0}={1}", "postedBy", "").Append("&");
            sb.AppendFormat("{0}={1}", "primarySort", "1").Append("&");
            sb.AppendFormat("{0}={1}", "secondarySort", "4").Append("&");
            //sb.AppendFormat("{0}={1}", "pageSize", "1000").Append("&");
            sb.AppendFormat("{0}={1}", "pageStart", pageStart);
            return sb.ToString();
        }
        public static async Task<Price> CalculatePrice(this Task<CDListings> listings, TrailerType myTrailerType, bool myIsOperable, VehicleType myVehicleType)
        {
            if (listings == null)
                return new Price(0, 0);

            double chargeForInop = 150;
            double sumPrice = 0;
            double count = 0;
            var vehicleTypeSize = new VehicleTypeSize(myVehicleType);
            var traielrTypeWeight = new TrailerTypeWeight(myTrailerType);

            foreach (CDListing l in (await listings).Listings)
            {
                TransformedListing transformedListing = new TransformedListing(l);

                double price = transformedListing.ListingOriginal.Price / transformedListing.VehicleCount;

                price *= vehicleTypeSize.SizeWeight.Weight / transformedListing.AverageVehicleWeight;
                price *= traielrTypeWeight.Weight / transformedListing.TrailerTypeWeight.Weight;

                if (!transformedListing.ListingOriginal.VehicleOperable && myIsOperable) // listing is inop, we're op so decrease price 
                    chargeForInop *= -1;
                else if (transformedListing.ListingOriginal.VehicleOperable == myIsOperable) //listing is same as my vehicle, so don't change
                    chargeForInop = 0;

                price += (chargeForInop * transformedListing.VehicleCount);

                if (price > 0)
                {
                    sumPrice += price;
                    count += 1;
                }
            }

            if (count == 0) return new Price(0, 0);
            else
            {
                double price = (sumPrice / count).ToNearestQuarter();
                double deposit = price >= 1500 ? 200 : price < 150 ? 75 : 150;
                return new Price(price, deposit);
            }

        }




        public static double ToNearestQuarter(this double number)
        {
            return Math.Round(number / 25.0) * 25;
        }
    }
}
