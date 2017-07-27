using ScrapeCDTest.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest
{
    public class AuthorizeNet
    {

        //POST
        //Sandbox URL: https://apitest.authorize.net/xml/v1/request.api

       // Production URL: https://api.authorize.net/xml/v1/request.api


        //request:
//        {
//    "createTransactionRequest": {
//        "merchantAuthentication": {
//            "name": "API_LOGIN_ID",
//            "transactionKey": "API_TRANSACTION_KEY"
//        },
//        "refId": "123456",
//        "transactionRequest": {
//            "transactionType": "authOnlyTransaction",
//            "amount": "5",
//            "payment": {
//                "creditCard": {
//                    "cardNumber": "5424000000000015",
//                    "expirationDate": "1220",
//                    "cardCode": "999"
//                }
//            },
//            "lineItems": {
//                "lineItem": {
//                    "itemId": "1",
//                    "name": "vase",
//                    "description": "Cannes logo",
//                    "quantity": "18",
//                    "unitPrice": "45.00"
//                }
//            },
//            "tax": {
//                "amount": "4.26",
//                "name": "level2 tax name",
//                "description": "level2 tax"
//            },
//            "duty": {
//                "amount": "8.55",
//                "name": "duty name",
//                "description": "duty description"
//            },
//            "shipping": {
//                "amount": "4.26",
//                "name": "level2 tax name",
//                "description": "level2 tax"
//            },
//            "poNumber": "456654",
//            "customer": {
//                "id": "99999456654"
//            },
//            "billTo": {
//                "firstName": "Ellen",
//                "lastName": "Johnson",
//                "company": "Souveniropolis",
//                "address": "14 Main Street",
//                "city": "Pecan Springs",
//                "state": "TX",
//                "zip": "44628",
//                "country": "USA"
//            },
//            "shipTo": {
//                "firstName": "China",
//                "lastName": "Bayles",
//                "company": "Thyme for Tea",
//                "address": "12 Main Street",
//                "city": "Pecan Springs",
//                "state": "TX",
//                "zip": "44628",
//                "country": "USA"
//            },
//            "customerIP": "192.168.1.1",
//            "transactionSettings": {
//                "setting": {
//                    "settingName": "testRequest",
//                    "settingValue": "false"
//                }
//            },
//            "userFields": {
//                "userField": [
//                    {
//                        "name": "MerchantDefinedFieldName1",
//                        "value": "MerchantDefinedFieldValue1"
//                    },
//                    {
//                        "name": "favorite_color",
//                        "value": "blue"
//                    }
//                ]
//            }
//        }
//    }
//}

      //  RESPONSE:

    //        {
    //"transactionResponse": {
    //    "responseCode": "1",
    //    "authCode": "HH5414",
    //    "avsResultCode": "Y",
    //    "cvvResultCode": "S",
    //    "cavvResultCode": "6",
    //    "transId": "2149186848",
    //    "refTransID": "",
    //    "transHash": "FE3CE11E9F7670D3ECD606E455B7C222",
    //    "testRequest": "0",
    //    "accountNumber": "XXXX0015",
    //    "accountType": "MasterCard",
    //    "messages": [
    //        {
    //            "code": "1",
    //            "description": "This transaction has been approved."
    //        }
    //    ],
    //    "userFields": [
    //        {
    //            "name": "MerchantDefinedFieldName1",
    //            "value": "MerchantDefinedFieldValue1"
    //        },
    //        {
    //            "name": "favorite_color",
    //            "value": "blue"
    //        }
    //    ]
    //},
    //"refId": "123456",
    //"messages": {
    //    "resultCode": "Ok",
    //    "message": [
    //        {
    //            "code": "I00001",
    //            "text": "Successful."
    //        }
    //    ]
    //}
}


        //public static ProcessCard(double chargeAmount, CreditCard creditCardData)
        //{
        //    string deposit = deposit1.Remove(0, 1);
        //    // string old_transaction_key = "9759QnYW5Pa66a7z";
        //    String result = "";
        //    //String strPost = "x_login=7J8mszy2TT4c&x_tran_key=78TczG294sLw47b4&x_method=CC&x_type=AUTH_ONLY&x_duplicate_window=0&x_amount="+deposit+"&x_first_name=" + billingname1 + "&x_delim_data=TRUE&x_delim_char=*&x_relay_response=FALSE&x_card_num=" + billingnumber1 + "&x_exp_date=" + billingexp1 + "&x_card_code=" + cardcode1 + "&x_address=" + billingaddress1 + "&x_zip=" + billingzip1 + "&x_test_request=FALSE&x_version=3.1";
        //    String strPost = "x_login=8Puf8aTtN9KS&x_tran_key=7TY9py375U9Jk2qy&x_method=CC&x_type=AUTH_ONLY&x_duplicate_window=0&x_amount=" + deposit + "&x_first_name=" + billingname1 + "&x_delim_data=TRUE&x_delim_char=*&x_relay_response=FALSE&x_card_num=" + billingnumber1 + "&x_exp_date=" + billingexp1 + "&x_card_code=" + cardcode1 + "&x_address=" + billingaddress1 + "&x_zip=" + billingzip1 + "&x_test_request=FALSE&x_version=3.1";
        //    StreamWriter myWriter = null;
        //    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
        //    objRequest.Method = "POST";
        //    objRequest.ContentLength = strPost.Length;
        //    objRequest.ContentType = "application/x-www-form-urlencoded";
        //    try
        //    {

        //        myWriter = new StreamWriter(objRequest.GetRequestStream());
        //        myWriter.Write(strPost);
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //    finally
        //    {
        //        myWriter.Close();
        //    }
        //    HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //    using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        //    {
        //        result = sr.ReadToEnd();
        //        sr.Close();
        //    }
        //    return result.Replace(",", " ");
        //}
    }

