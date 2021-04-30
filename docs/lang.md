# Language guide

## Usage

Each arithmetic expression is defined as variable which can be used in other expressions. Result of each expression can be printed in console
Code consists of statements with expressions and variable's names associated with them.
Each arithmetic expression is defined as variable which can be used in other expressions. Value of a variable can be printed in console

There are only two statements supported in this language: 

	var = expr # Variable declaration, var is name of variable which consists of 'a' - 'z', 'A' - 'Z' symbols, expr is number or expression
	print var # To print something you need use key "print" and specify variable you want to output


## Operations

* `+` - Sums two expressions
* `-` - Subtracts the second expression from the first expression
* `-variable | -digit` - Unary minus helps the calculator understand the sign of the variable or digit
* `*` - Multiplies two expressions
* `/` - Divides the first expression into the second expression
* `^` - Result of raising to the power of the first expression to the second expression 
* `{ expr }` - Brackets to absolute expression
* `%` - Remainder of dividing the first expression by the second expression
* `#` - Converts expression to binary system
* `=` - Binds a variable name to a value or expression
* `( expr )` - Brackets to set the order of operations

## Expressions 

*	`Num of <BigInt>`
*	`NVar of <VName>`
*	`Sum of <Expression * Expression>`
*	`Sub of <Expression * Expression>`
*	`Mul of <Expression * Expression>`
*	`Div of <Expression * Expression>`
*	`Rem of <Expression * Expression>`
*	`Pow of <Expression * Expression>`
*       `DivRem of <Expression * Expression>`
*	`Bin of <Expression>`
*	`Abs of <Expression>`

## Templates


	x = 5 
	x = x + 10 # x = 15


	x = 5
	y = 6
	z = 5 
	x = (x + y) / z 
	print x # output : 2 


	x = 12 + 6 / 3 - 7
	print x # output : 7