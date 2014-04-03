Feature: Game
	As a frequent games player
	I'd like to play rock, paper, scissors
	Using the computer

Scenario Outline: Games that are valid
	Given I have player1 who is a "<player1type>" and plays "<player1move>" move
	And player2 who is a "<player2type>" and plays "<player2move>" move
	When I play the game
	Then the winning player should be <winningplayernumber>

	Examples:
	| player1type | player1move | player2type | player2move | winningplayernumber |
	| human       | rock        | computer    | paper       | 2                   |
	| human       | rock        | computer    | scissors    | 1                   |
	| human       | rock        | computer    | rock        | 0                   |
	| human       | paper       | computer    | paper       | 0                   |
	| human       | paper       | computer    | scissors    | 2                   |
	| human       | paper       | computer    | rock        | 1                   |
	| human       | scissors    | computer    | paper       | 1                   |
	| human       | scissors    | computer    | scissors    | 0                   |
	| human       | scissors    | computer    | rock        | 2                   |
	| computer    | rock        | computer    | paper       | 2                   |
	| computer    | rock        | computer    | scissors    | 1                   |
	| computer    | rock        | computer    | rock        | 0                   |
	| computer    | paper       | computer    | paper       | 0                   |
	| computer    | paper       | computer    | scissors    | 2                   |
	| computer    | paper       | computer    | rock        | 1                   |
	| computer    | scissors    | computer    | paper       | 1                   |
	| computer    | scissors    | computer    | scissors    | 0                   |
	| computer    | scissors    | computer    | rock        | 2                   |
	| computer    | rock        | human       | paper       | 2                   |
	| computer    | rock        | human       | scissors    | 1                   |
	| computer    | rock        | human       | rock        | 0                   |
	| computer    | paper       | human       | paper       | 0                   |
	| computer    | paper       | human       | scissors    | 2                   |
	| computer    | paper       | human       | rock        | 1                   |
	| computer    | scissors    | human       | paper       | 1                   |
	| computer    | scissors    | human       | scissors    | 0                   |
	| computer    | scissors    | human       | rock        | 2                   |


Scenario Outline: Some games that are not valid
	Given I have player1 who is a "<player1type>" and plays "<player1move>" move
	And player2 who is a "<player2type>" and plays "<player2move>" move
	When I play the game
	Then the response should be a bad request

	Examples:
	| player1type | player1move | player2type | player2move | 
	| human       | rock        | human       | paper       | 
	| human       | frog        | computer    | scissors    | 
	| human       | rock        | martian     | rock        | 
	| human       | rock        | computer    | spam        | 
    | human       |             | computer    | spam        | 
	|             | paper       | computer    | rock        | 
	| human       | paper       |             | paper       | 
	|             |             |             |             | 