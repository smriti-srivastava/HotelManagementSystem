Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>' and '<name>' for hotel 
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |


@GetHotelById
Scenario Outline: User get the details of Hotel by providing a valid Hotel Id
	Given User provided valid Id '<id>' and '<name>' for hotel 
	And User has added required details for hotel
	And User has called AddHotel api 
	And User has provided a valid hotel Id '<id>' to be retrieved
	When User calls GetHotelById api
	Then Reponse should have the details of hotel with id '<id>'

Examples:
| id | name   |
| 4  | hotel4 |


@GetAllHotelDetails
Scenario: User get the details of all the hotels
	Given User provided valid Id '5' and 'hotel5' for hotel 
	And User has added required details for hotel
	And User has called AddHotel api	
	And User provided valid Id '6' and 'hotel6' for hotel  
	And User has added required details for hotel
	And User has called AddHotel api
	And User provided valid Id '7' and 'hotel7' for hotel 
	And User has added required details for hotel
	And User has called AddHotel api
	When User calls GetAllHotels api
	Then Reponse should have the details of all the hotels added