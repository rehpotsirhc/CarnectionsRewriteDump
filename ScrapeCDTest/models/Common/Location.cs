using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models.Common
{

    public interface ILonLat
    {
        double Longitude { get; set; }
        double Latitude { get; set; }
    }
    public class Location : CityStateZip, ILonLat
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
