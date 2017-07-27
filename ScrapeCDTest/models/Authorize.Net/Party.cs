using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models.Authorize.Net
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
    }
    public interface IAddress
    {
        string Address { get; set; }
    }
    public class Party : IPerson, IAddress, ICityStateZip
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zip { get; set; }
    }
}
