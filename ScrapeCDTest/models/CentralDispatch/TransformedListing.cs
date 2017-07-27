using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScrapeCDTest.models.CentralDispatch
{
    public class CDListingsTransformed
    {
        public IDictionary<int, TransformedListing> TransformedListings { get; private set; }
        public IList<int> PageStarts { get; private set; }
        public IList<int> Counts { get; private set; }
        public IList<CDListing> Duplicates { get; private set; }
        public async void TransformAndRecord(Task<CDListings> originalListings)
        {
            var newListings = (await originalListings).Listings;
            var newCount = (await originalListings).Count;
            var newPageStart = (await originalListings).PageStart;

       
            if (TransformedListings == null)
            {
                TransformedListings = new Dictionary<int, TransformedListing>();
                Duplicates = new List<CDListing>();
                PageStarts = new List<int>();
                Counts = new List<int>();
            }
            PageStarts.Add(newPageStart);
            Counts.Add(newCount);
            foreach (CDListing listing in newListings)
            {
                if (TransformedListings.ContainsKey(listing.ListingId))
                    Duplicates.Add(listing);
                else TransformedListings.Add(listing.ListingId, new TransformedListing(listing));
            }
        }

    }

    //assumes the listings it receives are valid
    public class TransformedListing: IHasId<int>
    {
        public int Id { get; private set; }
        public CDListing ListingOriginal { get; private set; }
        public TransformedListing(CDListing listingOriginal)
        {
            this.ListingOriginal = listingOriginal;
            this.Id = ListingOriginal.Id;
            ParseVehicles();
            ParseTrailerType();
            double pricePerMile = ListingOriginal.PricePerMile;
            this.MilesInterpolated = pricePerMile > 0 ? (int)(ListingOriginal.Price / ListingOriginal.PricePerMile) : 0;
        }
        private void ParseVehicles()
        {
            string[] vehicleStringWithQtyParts = ListingOriginal.VehicleTypes.Replace("(", "").Replace(")", "").Trim().Split(',');
            VehicleTypesSizes = new List<VehicleTypeSize>();
            foreach (string vehicleStringWithQty in vehicleStringWithQtyParts)
            {
                int qty;
                string vehicleString;
                MatchCollection matches = Regex.Matches(vehicleStringWithQty.Trim(), @"^\d");
                if (matches.Count > 0)
                {
                    string numberTemp = matches[0].Groups[0].Value;
                    qty = int.Parse(numberTemp.Trim());
                    vehicleString = vehicleStringWithQty.Replace(numberTemp, "").Trim();
                }
                else
                {
                    qty = 1;
                    vehicleString = vehicleStringWithQty.Trim();
                }
                for (int i = 0; i < qty; i++)
                {
                    VehicleType vehicleType;
                    if (Enum.TryParse(Regex.Replace(vehicleString, "\\s+", ""), out vehicleType))
                    {
                        var typeSize = new VehicleTypeSize(vehicleType);
                        VehicleTypesSizes.Add(typeSize);
                        AverageVehicleWeight += typeSize.SizeWeight.Weight;
                        VehicleCount += 1;
                    }
                }
            }
            AverageVehicleWeight /= VehicleCount;
        }

        private void ParseTrailerType()
        {
            TrailerTypeWeight = new TrailerTypeWeight(ListingOriginal.ShipMethod);
        }

        public TrailerTypeWeight TrailerTypeWeight { get; private set; }

        public IList<VehicleTypeSize> VehicleTypesSizes { get; private set; }
        public double AverageVehicleWeight { get; private set; }
        public int VehicleCount { get; private set; }
        public int MilesInterpolated { get; private set; }
     

        public override string ToString()
        {
            string vehicles = "";

            for (int i = 0; i < VehicleTypesSizes.Count; i++)
            {
                vehicles += VehicleTypesSizes[i].Type;
                if (i < VehicleTypesSizes.Count - 1)
                    vehicles += "\t";
            }

            return String.Format("{0}\t{1}\t{2}\t{3}", ListingOriginal.ToString(), VehicleCount, vehicles, MilesInterpolated);
        }


    }
}
