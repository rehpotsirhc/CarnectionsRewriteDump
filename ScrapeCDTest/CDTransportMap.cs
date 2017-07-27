using ScrapeCDTest.models;
using ScrapeCDTest.models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest
{
    public class CDTransportMap
    {


        //long range: -66.84(E) ==> -124.45(W)   *57.61
        //lat range:  25.13(S) ==> 49.35 (N)    *24.22

        //MESH long range: 64 ==> 126 *62 (extra for padding)
        //MESH lat range: 24 ==> 51   *27 (extra for padding)
        //MESH Unit length: .5, MESH is *124 x *54

        private CoordMeshWithItems<CDListing> _locations;

       public CDTransportMap(IEnumerable<CDListing> listings)
        {
            var settings = new CoordMeshSettings(.5, 64, 126, 24, 51);
            this._locations = new CoordMeshWithItems<CDListing>(settings);

            foreach (CDListing listing in listings)
            {
                this._locations.Add(listing.Pickup.Longitude, listing.Pickup.Latitude, listing);
            }
        }

        public IEnumerable<CDListing> Search(Location pickup, Location delivery)
        {
            //Get all listings leaving from the pickup location
            var pickupListings = this._locations.GetItems(pickup.Longitude, pickup.Latitude);

            //get the coordinates of the delivery location
            var deliveryCoords = this._locations.FitLonLat(delivery.Longitude, delivery.Latitude);

            
            foreach (CDListing pickupListing in pickupListings.Values)
            {
                //get the delivery coords of the listings leaving from the pickup location
                var coords = this._locations.FitLonLat(pickupListing.Delivery.Longitude, pickupListing.Delivery.Latitude);

                //return only those being delivered to the delivery location
                if (deliveryCoords.Equals(coords))
                    yield return pickupListing;
            }
        }

    }
}
