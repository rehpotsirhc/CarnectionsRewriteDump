using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

namespace ScrapeCDTest.models
{
    public enum StateEnumeration
    {
        [Description("UNKNOWN")]
        UNKNOWN,

        [Description("Alabama")]
        AL,

        [Description("Alaska")]
        AK,

        [Description("Arkansas")]
        AR,

        [Description("Arizona")]
        AZ,

        [Description("California")]
        CA,

        [Description("Colorado")]
        CO,

        [Description("Connecticut")]
        CT,

        [Description("D.C.")]
        DC,

        [Description("Delaware")]
        DE,

        [Description("Florida")]
        FL,

        [Description("Georgia")]
        GA,

        [Description("Hawaii")]
        HI,

        [Description("Iowa")]
        IA,

        [Description("Idaho")]
        ID,

        [Description("Illinois")]
        IL,

        [Description("Indiana")]
        IN,

        [Description("Kansas")]
        KS,

        [Description("Kentucky")]
        KY,

        [Description("Louisiana")]
        LA,

        [Description("Massachusetts")]
        MA,

        [Description("Maryland")]
        MD,

        [Description("Maine")]
        ME,

        [Description("Michigan")]
        MI,

        [Description("Minnesota")]
        MN,

        [Description("Missouri")]
        MO,

        [Description("Mississippi")]
        MS,

        [Description("Montana")]
        MT,

        [Description("North Carolina")]
        NC,

        [Description("North Dakota")]
        ND,

        [Description("Nebraska")]
        NE,

        [Description("New Hampshire")]
        NH,

        [Description("New Jersey")]
        NJ,

        [Description("New Mexico")]
        NM,

        [Description("Nevada")]
        NV,

        [Description("New York")]
        NY,

        [Description("Oklahoma")]
        OK,

        [Description("Ohio")]
        OH,

        [Description("Oregon")]
        OR,

        [Description("Pennsylvania")]
        PA,

        [Description("Rhode Island")]
        RI,

        [Description("South Carolina")]
        SC,

        [Description("South Dakota")]
        SD,

        [Description("Tennessee")]
        TN,

        [Description("Texas")]
        TX,

        [Description("Utah")]
        UT,

        [Description("Virginia")]
        VA,

        [Description("Vermont")]
        VT,

        [Description("Washington")]
        WA,

        [Description("Wisconsin")]
        WI,

        [Description("West Virginia")]
        WV,

        [Description("Wyoming")]
        WY


    }


    public class State
    {
        private string _abbreviation;
        private string _fullName;

        public State(string stateString)
        {
            stateString = stateString.Trim();
            StateEnumeration tmp;

            //try to convert based on StateEnumeration value (which are the abbreviations)
            if (Enum.TryParse(stateString, true, out tmp))
            {
                this.StateEnum = tmp;
            }
            else
            {
                this.StateEnum = EnumHelper.TryGetValueFromDescriptionWithDefault<StateEnumeration>(stateString);
            }
        }
        public StateEnumeration StateEnum { get; private set; }
        public string FullName
        {
            get
            {
                if (_fullName == null)
                    _fullName = StateEnum.GetAttributeOfType<DescriptionAttribute>().Description;

                return _fullName;
            }
        }
        public string Abbreviation
        {
            get
            {
                if (_abbreviation == null)
                    _abbreviation = StateEnum.ToString();

                return _abbreviation;
            }
        }

        public static implicit operator State(string stateString)
        {
            if (!String.IsNullOrWhiteSpace(stateString))
                return new State(stateString);
            else return null;
        }


        //public static implicit operator string(State stateEnum)
        //{
        //    return stateEnum.StateString;
        //}
    }
}


