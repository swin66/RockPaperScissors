Feature: Game Types
	As a frequent games player
	I'd like to play rock, paper, scissors on a computer
	But I don't know what game types it allows

Scenario Outline: Game types that are allowed
	Given I have player1 who is a "<player1type>"
	And player2 who is a "<player2type>"
	When I get the list of available game types
	Then the game type should be allowed

	Examples:
	| player1type | player2type |
	| human       | computer    |
	| computer    | human       |
	| computer    | computer    |


Scenario Outline: Some games types that are not allowed
	Given I have player1 who is a "<player1type>"
	And player2 who is a "<player2type>"
	When I get the list of available game types
	Then the game type should not be allowed

	Examples:
	| player1type | player2type |
	| human       | human       |
	| martian     | human       |
	| martian     | martian     |