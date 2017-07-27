using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models
{
    public class CreditCard
    {

        //String strPost = "x_login=8Puf8aTtN9KS&x_tran_key=7TY9py375U9Jk2qy&x_method=CC&x_type=AUTH_ONLY&x_duplicate_window=0&x_amount=" + deposit + "&x_first_name=" + billingname1 + "&x_delim_data=TRUE&x_delim_char=*&x_relay_response=FALSE&x_card_num=" + billingnumber1 + "&x_exp_date=" + billingexp1 + "&x_card_code=" + cardcode1 + "&x_address=" + billingaddress1 + "&x_zip=" + billingzip1 + "&x_test_request=FALSE&x_version=3.1";
        public string Name { get; set; }
        public string Number { get; set; }
        public string Expiration { get; set; }
        public string SecretCode { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
    }
}
