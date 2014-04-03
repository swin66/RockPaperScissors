Feature: Generated move
	As a computer player
	I can't think for myself
	So I want a move generated for me

Scenario: Get a generated name
	When I get a generated move
	Then The move is one of the following valid move names
		| movename | 
		| rock     | 
		| paper    | 
		| scissors | 