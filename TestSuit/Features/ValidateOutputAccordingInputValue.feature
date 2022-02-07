Feature: ValidateOutputAccordingInputValue
	Test the form with different inputs and validate the outputs.

@positive
Scenario Outline: Valid input values
	Given The Full Name is <Name>
	And The Email is <Email>
	And The Current Address is <CurrentAdr>
	And The Permanent Address is <PermanentAdr>
	When The Information are submitted
	Then The input values returned in the bottom part

	Examples:
		| Name       | Email                     | CurrentAdr                       | PermanentAdr                  |
		| test user  | test@blabla.com           | C. Dobla, 5, 28054 Madrid, Spain | Street X, 28013 Madrid, Spain |
		| John Smith | john.smith@mailinator.com | Street Smith 3, London, UK       | Street Smith 6, London, UK    |
		| 张军         | 123@123.123               | Wuhan, China                     | Shanghai, China               |
		| ÄÅÖ        | 123@test.com              | täby, Sweden                     | 哥德堡，瑞典                        |

@negative
Scenario Outline: Invalid input values
	Given The Full Name is <Name>
	And The Email is <Email>
	And The Current Address is <CurrentAdr>
	And The Permanent Address is <PermanentAdr>
	When The Information are submitted
	Then Error shows in page

	Examples:
		| Name | Email            | CurrentAdr | PermanentAdr |
		|      | *@.com           |            |              |
		|      | 123£@456.com     |            |              |
		|      | thisisnotanemail |            |              |