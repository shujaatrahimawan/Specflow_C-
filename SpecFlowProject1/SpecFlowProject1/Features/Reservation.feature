Feature: B) Reserve the rooms from the hotel you searched

@sanity @DataSource:../data/searchhotel.xlsx
Scenario: A1) Search hotel with different location and type
	Given Select "<location>" from "location_dropdown"
	When Select "<hotels>" from "hotels_dropdown"
	When Select "<room_type>" from "room_types_dropdown"
	When Select "<number_of_rooms>" from "room_no_dropdown"
	When Select "<adults_per_room>" from "adult_room_dropdown"
	When Select "<childern_per_room>" from "child_room_dropdown"
	Then click on "search_submit"
	Then check mark "seach_result_radio_button"
	Then click on "continue_button"

@sanity @DataSource:../data/reservation.xlsx
Scenario: B2) Fillout the booking form
	Given enter first name "<first_name>" on "first_name"
	When enter last name "<last_name>" on "last_name"
	When enter billing address "<address>" on "address"
	When enter credit card no "<cc_no>" on "card_no"
	When Select "<cc_type>" from "card_type"
	When Select "<expire_month>" from "card_expire_month"
	When Select "<expire_year>" from "card_expire_year"
	When enter CVV "<cvv>" on "card_cvv"
	Then click on "book_now_button"

@sanity 
Scenario: C3) Verify the booking confirmation
	Given wait for 5 seconds
	Given verify the booking confirmation "Booking Confirmation" from "confirm_message"