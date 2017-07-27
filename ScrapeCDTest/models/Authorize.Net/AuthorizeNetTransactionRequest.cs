using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models.Authorize.Net
{
    public class MerchantAuthentication
    {
        public string name { get; set; }
        public string transactionKey { get; set; }
    }

    public class CreditCard
    {
        public string cardNumber { get; set; }
        public string expirationDate { get; set; }
        public string cardCode { get; set; }
    }

    public class Payment
    {
        public CreditCard creditCard { get; set; }
    }


    public interface ILineItem
    {
        string Name { get; set; }
        string Description { get; set; }
        double Amount { get; set; }
    }


    public class LineItemWithQuantity : ILineItem
    {

        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("unitPrice")]
        public double Amount { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }

       
    }

    public class LineItemsWithQuantity
    {
        public LineItemWithQuantity lineItem { get; set; }
    }

    public class LineItemSimple : ILineItem
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

    }

    public class Customer
    {
        public string id { get; set; }
    }



    public class Setting
    {
        public string settingName { get; set; }
        public string settingValue { get; set; }
    }

    public class TransactionSettings
    {
        public Setting setting { get; set; }
    }

    public class UserField
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class UserFields
    {
        public IList<UserField> userField { get; set; }
    }

    public class TransactionRequest
    {
        public string transactionType { get; set; }
        public string amount { get; set; }
        public Payment payment { get; set; }
        public LineItemsWithQuantity lineItems { get; set; }
        public LineItemSimple tax { get; set; }
        public LineItemSimple duty { get; set; }
        public LineItemSimple shipping { get; set; }
        public string poNumber { get; set; }
        public Customer customer { get; set; }
        public Party BillTo { get; set; }
        public Party ShipTo { get; set; }
        public string customerIP { get; set; }
        public TransactionSettings transactionSettings { get; set; }
        public UserFields userFields { get; set; }
    }

    public class CreateTransactionRequest
    {
        public MerchantAuthentication merchantAuthentication { get; set; }
        public string refId { get; set; }
        public TransactionRequest transactionRequest { get; set; }
    }

    public class AuthorizeNetTransactionRequest
    {
        public CreateTransactionRequest createTransactionRequest { get; set; }
    }
}
