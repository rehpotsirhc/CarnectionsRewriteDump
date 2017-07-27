using ScrapeCDTest.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestScrapeCDTest
{

    public class TestField
    {
        public CityStateZip Pickup { get; set; }
        public CityStateZip Delivery { get; set; }
        public VehicleType VehicleType { get; set; }
        public TrailerType TrailerType { get; set; }
        public bool Operable { get; set; }
        public double Price { get; set; }

        public TestField()
        {
            Operable = true;
            TrailerType = TrailerType.Open;
        }
    }

    public class Error
    {
        public TestField TestField { get; set; }
        public double PercentError { get; private set; }

        public Error(TestField field, double estimatedPrice)
        {
            TestField = field;
            PercentError = (Math.Abs(TestField.Price - estimatedPrice) / TestField.Price) * 100;
        }
    }

    public static class TestFields
    {

        public static IList<TestField> Fields = new List<TestField>
        {
            new TestField()
            {
                Pickup = new CityStateZip("Herriman", "UT", "84096"),
                Delivery = new CityStateZip("Washington", "UT", "84780"),
                VehicleType = VehicleType.SUV,
                Price = 375
            },
                new TestField()
            {
                Pickup = new CityStateZip(zip:"84115"),
                Delivery = new CityStateZip(zip:"79706"),
                VehicleType = VehicleType.SUV,
                Price = 675
            },
                 new TestField()
            {
                Pickup = new CityStateZip(zip:"84104"),
                Delivery = new CityStateZip(zip:"46032"),
                VehicleType = VehicleType.Car,
                Price = 800
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"84103"),
                Delivery = new CityStateZip(zip:"91351"),
                VehicleType = VehicleType.Car,
                TrailerType = TrailerType.Enclosed,
                Price = 700
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"21401"),
                Delivery = new CityStateZip(zip:"84120"),
                VehicleType = VehicleType.Van,
                Price = 2200
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"84108"),
                Delivery = new CityStateZip(zip:"42254"),
                VehicleType = VehicleType.SUV,
                Price = 850
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"02188"),
                Delivery = new CityStateZip(zip:"07203"),
                VehicleType = VehicleType.Pickup,
                Price = 400
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"84115"),
                Delivery = new CityStateZip(zip:"49015"),
                VehicleType = VehicleType.SUV,
                Price = 850
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"93442"),
                Delivery = new CityStateZip(zip:"84111"),
                VehicleType = VehicleType.Car,
                Price = 750
            },
                new TestField(){
                Pickup = new CityStateZip(zip:"93619"),
                Delivery = new CityStateZip(zip:"94804"),
                VehicleType = VehicleType.Car,
                Price = 300
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"11001"),
                Delivery = new CityStateZip(zip:"07203"),
                VehicleType = VehicleType.Car,
                Price = 350
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"84105"),
                Delivery = new CityStateZip(zip:"89117"),
                VehicleType = VehicleType.Car,
                Price = 300
            },
                  new TestField()
                 {
                Pickup = new CityStateZip(zip:"84120"),
                Delivery = new CityStateZip(zip:"75652"),
                VehicleType = VehicleType.Van,
                Price = 1400
            },
                  new TestField()
                 {
                Pickup = new CityStateZip(zip:"84120"),
                Delivery = new CityStateZip(zip:"75652"),
                VehicleType = VehicleType.Van,
                Price = 1400
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"46055"),
                Delivery = new CityStateZip(zip:"07203"),
                VehicleType = VehicleType.Car,
                Price = 550
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"46055"),
                Delivery = new CityStateZip(zip:"07203"),
                VehicleType = VehicleType.Car,
                Price = 550
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"33990"),
                Delivery = new CityStateZip(zip:"33167"),
                VehicleType = VehicleType.Car,
                Price = 300,
                Operable = false
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"80229"),
                Delivery = new CityStateZip(zip:"84604"),
                VehicleType = VehicleType.Car,
                Price = 475,
                Operable = false
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"84631"),
                Delivery = new CityStateZip(zip:"90220"),
                VehicleType = VehicleType.Car,
                TrailerType = TrailerType.Enclosed,
                Price = 650
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"84601"),
                Delivery = new CityStateZip(zip:"84015"),
                VehicleType = VehicleType.SUV,
                TrailerType = TrailerType.Open,
                Price = 150,
                Operable = false
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"46040"),
                Delivery = new CityStateZip(zip:"07036"),
                VehicleType = VehicleType.Car,
                TrailerType = TrailerType.Enclosed,
                Price = 1450,
                Operable = false
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"77707"),
                Delivery = new CityStateZip(zip:"11694"),
                VehicleType = VehicleType.Car,
                TrailerType = TrailerType.Enclosed,
                Price = 1050
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"94566"),
                Delivery = new CityStateZip(zip:"90220"),
                VehicleType = VehicleType.Car,
                Price = 400,
                Operable = false
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"74133"),
                Delivery = new CityStateZip(zip:"84043"),
                VehicleType = VehicleType.Car,
                TrailerType = TrailerType.Enclosed,
                Price = 1425,
            },
                 new TestField()
                 {
                Pickup = new CityStateZip(zip:"84081"),
                Delivery = new CityStateZip(zip:"60555"),
                VehicleType = VehicleType.Car,
                Price = 650,
                Operable = false
            },
                  new TestField()
                 {
                Pickup = new CityStateZip(zip:"84010"),
                Delivery = new CityStateZip(zip:"82002"),
                VehicleType = VehicleType.Pickup,
                Price = 550
            },
                  new TestField()
                 {
                Pickup = new CityStateZip(zip:"84054"),
                Delivery = new CityStateZip(zip:"92240"),
                VehicleType = VehicleType.Pickup,
                Price = 725
            },
                  new TestField()
                 {
                Pickup = new CityStateZip(zip:"33415"),
                Delivery = new CityStateZip(zip:"84075"),
                VehicleType = VehicleType.Pickup,
                Price = 1700
            }
        };
    }
}
