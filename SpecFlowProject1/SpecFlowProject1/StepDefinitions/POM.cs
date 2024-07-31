using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions 
{
    public class POM
    {
        public Dictionary<string, string> LoginPage = new Dictionary<string, string>
        {
            { "login_username", "id=username" },
            { "login_password", "id=password" },
            { "login_submit", "id=login" }
        };
        public Dictionary<string, string> ReservationPage = new Dictionary<string, string>
        {
            { "location_dropdown", "id=location" },
            { "hotels_dropdown", "id=hotels"},
            { "room_types_dropdown", "id=room_type" },
            { "room_no_dropdown", "id=room_nos" },
            { "adult_room_dropdown", "id=adult_room" },
            { "child_room_dropdown", "id=child_room" },
            { "search_submit", "id=Submit" },
            { "seach_result_radio_button", "id=radiobutton_0" },
            { "continue_button", "id=continue" },
            { "first_name", "id=first_name" },
            { "last_name", "id=last_name" },
            { "address", "id=address" },
            { "card_no", "id=cc_num" },
            { "card_type", "id=cc_type" },
            { "card_expire_month", "id=cc_exp_month" },
            { "card_expire_year", "id=cc_exp_year" },
            { "card_cvv", "id=cc_cvv" },
            { "book_now_button", "id=book_now" },
            { "confirm_message", "classname=login_title" }
        };
        public Dictionary<string, string> LogoutPage = new Dictionary<string, string>
        {
            { "logout_button", "id=logout" },
            { "logout_message", "classname=reg_success" },
            { "login_again", "xpath=//td[@class=\"reg_success\"]/a" },
            { "login_register", "classname=login_register" },
            
        };
    }
}
