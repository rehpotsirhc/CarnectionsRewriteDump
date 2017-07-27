using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models
{
    public enum TrailerType
    {
        Enclosed,
        Open,
        Driveaway
    }
    public class TrailerTypeWeight
    {
        public TrailerType Type { get; private set; }
        public double Weight { get; private set; }

        public TrailerTypeWeight(TrailerType type)
        {
            this.Type = type;
            if (this.Type == TrailerType.Open || this.Type == TrailerType.Driveaway)
                Weight = 1;
            else
                Weight = 1.5;
        }
    }
}
