using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ScrapeCDTest.models
{
    public enum VehicleType
    {
        Unknown,
        ATV,
        Boat,
        Car,
        [Display(Name = "Heavy Equipment")]
        HeavyEquipment,
        [Display(Name = "Large Yacht")]
        LargeYacht,
        Motorcycle,
        Pickup,
        RV,
        SUV,
        [Display(Name = "Travel Trailer")]
        TravelTrailer,
        Van,
        Other

    }
    public enum VehicleSize
    {
        Large,
        Small
    }
    public class VehicleSizeWeight
    {
        public VehicleSize Size { get; private set; }
        public double Weight { get; private set; }
        public VehicleSizeWeight(VehicleSize size)
        {
            this.Size = size;
            if (this.Size == VehicleSize.Small)
                this.Weight = 1;
            else if (this.Size == VehicleSize.Large)
                this.Weight = 1.25;
        }
    }
    public class VehicleTypeSize
    {
        public VehicleType Type { get; private set; }
        public VehicleSizeWeight SizeWeight { get; private set; }
        public VehicleTypeSize(VehicleType type)
        {
            this.Type = type;
            if (this.Type == VehicleType.Car || this.Type == VehicleType.Motorcycle || this.Type == VehicleType.ATV)
                SizeWeight = new VehicleSizeWeight(VehicleSize.Small);
            else
                SizeWeight = new VehicleSizeWeight(VehicleSize.Large);
        }
    }
}
