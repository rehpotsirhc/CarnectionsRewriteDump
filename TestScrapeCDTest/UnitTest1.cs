using ScrapeCDTest;
using ScrapeCDTest.models;
using ScrapeCDTest.models.Google;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using ScrapeCDTest.models.CentralDispatch;
using System.Collections.Generic;

namespace TestScrapeCDTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var trailer = TrailerType.Open;
            bool operable = true;
            var vehicleType = VehicleType.Car;
            int shipWithin = 60;
            double minPerMile = .2;
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine((await ScrapeCD.BuildEndpoint(new CityStateZip()
            {
                City = "Medford",
                State = "MA",
                Zip = ""
            }, 100, new CityStateZip()
            {
                City = "Atlanta",
                State = "GA",
                Zip = "30318"
            }, 100, trailer, operable, shipWithin, minPerMile).GetListings().CalculatePrice(trailer, operable, vehicleType)).Total);
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("");
        }

        [Fact]
        public async Task CentralDispatchErrorTest()
        {
            int shipWithin = 60;
            double minPerMile = 0;

            double sumOver100Error = 0;
            double sumUnder100 = 0;
            double countOver100 = 0;
            double countUnder100 = 0;

            foreach (TestField test in TestFields.Fields)
            {

                var transformedGoogleDistanceMatrix = await GoogleDistance.BuildEndpoint(test.Pickup, test.Delivery).GetDistanceMatrix().TransformDistanceMatrix();

                var pickup = transformedGoogleDistanceMatrix.Pickup;
                var delivery = transformedGoogleDistanceMatrix.Delivery;
                var estimatedPrice = await ScrapeCD.BuildEndpoint(pickup, 100, delivery, 100, test.TrailerType, test.Operable, shipWithin, minPerMile)
                    .GetListings().CalculatePrice(test.TrailerType, test.Operable, test.VehicleType);

                var errorObj = new Error(test, estimatedPrice.Total);

                var perError = errorObj.PercentError;

                if (errorObj.PercentError >= 100)
                {
                    sumOver100Error += perError;
                    countOver100++;
                }
                else
                {
                    sumUnder100 += perError;
                    countUnder100++;
                }

                Debug.WriteLine(pickup.ToString() + " to " + delivery.ToString());
                Debug.WriteLine(test.VehicleType);
                Debug.WriteLine(test.TrailerType);
                Debug.WriteLine(test.Operable);
                Debug.WriteLine("Estimated Price: " + estimatedPrice);
                Debug.WriteLine("Michelle's Price: " + errorObj.TestField.Price);
                Debug.WriteLine(perError);
                Debug.WriteLine("\n");
            }

            double error = (sumOver100Error + sumUnder100) / (countOver100 + countUnder100);
            double errorUnder100 = sumUnder100 / countUnder100;

            Debug.WriteLine("\n\n\n");
            Debug.WriteLine("Error " + error);
            Debug.WriteLine("Error (over 100)" + errorUnder100);
            Debug.WriteLine("Count (total)" + (countOver100 + countUnder100));
            Debug.WriteLine("Count (over 100)" + countOver100);
            Debug.WriteLine("Count (under 100)" + countUnder100);
            Debug.WriteLine("\n\n\n");

        }

        [Fact]
        public async Task Test2()
        {
            var distanceMatrix = await GoogleDistance.BuildEndpoint(new CityStateZip()
            {
                City = "Salt Lake City",
                State = "",
                Zip = "UT"
            }, new CityStateZip()
            {
                City = "Atlanta",
                State = "GA",
                Zip = "30318"
            }).GetDistanceMatrix();

            var transformedMatrix = new TransformedDistanceMatrix(distanceMatrix);
        }

        [Fact]
        public async Task TestState()
        {

            var stateFull = new State("Utah");
            var stateAbbr = new State("UT");

            Assert.Equal(stateFull.Abbreviation, stateAbbr.Abbreviation);
            Assert.Equal(stateFull.FullName, stateAbbr.FullName);
            Assert.Equal(stateFull.Abbreviation, "UT");
            Assert.Equal(stateFull.FullName, "Utah");
        }


        ///Salt Lake City, UT, 84111
        //Salt Lake City, UT 84111
        //Salt Lake City, UT
        //Salt Lake City 84111
        //84111
        //Salt Lake City
        //Ut
        [Fact]
        public async Task TestLocation()
        {
            string city = "Salt Lake City";
            string state = "ut";
            string zip = "84111";
            string fullLocationString = "Salt Lake City, UT 84111";
            CityStateZip location = new CityStateZip(city, state, zip);

            Assert.Equal(fullLocationString, location.ToString());
        }


     
        [Fact]
        public void ScrapeAllTest()
        {
           var allListings = ScrapeCD.ScrapeAll();

            Console.WriteLine("Done");
        }

        [Fact]
        public void Test()
        {
            IDictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add(1, "abc");
            dic.Add(1, "zyx");
        }
    }
}
