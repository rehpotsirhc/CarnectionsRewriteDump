using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models.Google
{


    public class GoogleDistanceMatrix
    {
        [JsonProperty(PropertyName = "origin_addresses")]
        public IList<string> OriginAddresses { get; set; }
        [JsonProperty(PropertyName = "destination_addresses")]
        public IList<string> DestinationAddresses { get; set; }
        public IList<Row> Rows { get; set; }
        public string Status { get; set; }

    }
    public class Row
    {
        public IList<Element> Elements { get; set; }
    }

    public class Element
    {
        public ElementObject Distance { get; set; }
        public ElementObject Duration { get; set; }
        public string Status { get; set; }
    }
    public class ElementObject
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }


    //assumes the distance matrix it receives is valid
    public class TransformedDistanceMatrix
    {
        public GoogleDistanceMatrix GoogleDistanceMatrixOriginal { get; private set; }
        public CityStateZip Pickup { get; private set; }
        public CityStateZip Delivery { get; private set; }
        public double Miles { get; private set; }
        public double Hours { get; private set; }

        public TransformedDistanceMatrix(GoogleDistanceMatrix distanceMatrixOriginal)
        {
            this.GoogleDistanceMatrixOriginal = distanceMatrixOriginal;


            Pickup = new CityStateZip(GoogleDistanceMatrixOriginal.OriginAddresses[0]);
            Delivery = new CityStateZip(GoogleDistanceMatrixOriginal.DestinationAddresses[0]);
        }

    }
}
  //      {
  //"destination_addresses": [
  //  "Salt Lake City, UT 84111, USA"
  //],
  //"origin_addresses": [
  //  "Salt Lake City, UT 84119, USA"
  //],
  //"rows": [
  //  {
  //    "elements": [
  //      {
  //        "distance": {
  //          "text": "7.9 mi",
  //          "value": 12650
  //        },
  //        "duration": {
  //          "text": "14 mins",
  //          "value": 836
  //        },
  //        "status": "OK"
  //      }
  //    ]
  //  }
  //],
  //"status": "OK"
