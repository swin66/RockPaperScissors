Feature: Moves
	As a player of the game
	To avoid making invalid moves
	I want to check the valid moves

Scenario Outline: Move names that are allowed
	Given I have a move name of <movename>
	When I get the list of available move names
	Then the move name should be allowed

	Examples:
	| movename | 
	| rock     | 
	| paper    | 
	| scissors | 

Scenario Outline: Some move names that are not allowed
	Given I have a move name of <movename>
	When I get the list of available move names
	Then the move name should not be allowed

	Examples:
	| movename | 
	| cucumber | 
	| planet   | 
	| hand     | 

