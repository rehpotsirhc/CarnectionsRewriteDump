using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models
{

    public interface ICityStateZip
    {
        string City { get; set; }
        State State { get; set; }
        string Zip { get; set; }

    }
    public class CityStateZip : ICityStateZip
    {
        public string City { get; set; }
        public State State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }


        public CityStateZip()
        {

        }


        /// <summary>
        /// Example strings supported:
        ///Salt Lake City, UT, 84111
        //Salt Lake City, UT 84111
        //Salt Lake City, UT
        //Salt Lake City 84111
        //84111
        /// </summary>
        /// <param name="fullLocationString"></param>
        public CityStateZip(string fullLocationString)
        {

            if (String.IsNullOrWhiteSpace(fullLocationString))
                return;

            if (fullLocationString.EndsWith(", USA"))
                fullLocationString = fullLocationString.Substring(0, fullLocationString.Length - 5);
            else if (fullLocationString.EndsWith(" USA"))
                fullLocationString = fullLocationString.Substring(0, fullLocationString.Length - 4);



            string[] parts = fullLocationString.Split(',');
            string city = null, state = null, zip = null;

            //Salt Lake City 84111
            //84111
            if (parts.Length == 1)
            {
                string[] cityZip = parts[0].Trim().Split(' ');
                if (cityZip.Length >= 1)
                {
                    zip = cityZip[0].Trim();
                }
                if (cityZip.Length > 1)
                {
                    city = cityZip[0].Trim();
                }
            }
            //Salt Lake City, UT 84111
            //Salt Lake City, UT
            else if (parts.Length == 2)
            {
                city = parts[0].Trim();
                string[] stateZip = parts[1].Trim().Split(' ');

                if (stateZip.Length >= 1)
                {
                    state = stateZip[0].Trim();
                }
                if (stateZip.Length > 1)
                {
                    zip = stateZip[1].Trim();
                }
            }
            else if (parts.Length >= 3)
            {
                city = parts[0].Trim();
                state = parts[1].Trim();
                zip = parts[2].Trim();
            }



            this.City = city;
            this.State = state;
            this.Zip = zip;


        }

        public CityStateZip(string city = null, string state = null, string zip = null)
        {
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }

        ///Salt Lake City, UT, 84111
        //Salt Lake City, UT 84111
        //Salt Lake City, UT
        //Salt Lake City 84111
        //84111
        //Salt Lake City
        //Ut
        public string ToString(bool useStateFullName)
        {

            string state = useStateFullName ? State?.FullName : State?.Abbreviation;

            bool cityBlank = String.IsNullOrWhiteSpace(City);
            bool stateBlank = String.IsNullOrWhiteSpace(state);
            bool zipBlank = String.IsNullOrWhiteSpace(Zip);

            string city = cityBlank ? "" : City + ", ";
            state = stateBlank ? "" : state + " ";
            string zip = zipBlank ? "" : Zip;


            //Salt Lake City 84111
            if (stateBlank && !zipBlank && !cityBlank)
                city = city.Remove(city.Length - 2);

            return (city + state + zip).Trim();
        }
        public override string ToString()
        {
            return ToString(false);
        }
    }
}
