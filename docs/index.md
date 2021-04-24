# CalculatorFSharp

This calculator was created to evaluate expressions using the F # language.

## Usage

All expressions in the calculator must be variables or prints.
You can see language features below:
	
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

## Templates

An important note, calculator is dynamically typed, so we can overwrite a value in a variable:

	x = 5 
	x = x + 10 # x = 15

	
	x = 5
	y = 6
	z = 5 
	x = (x + y) / z 
	print x # output : 2 

	
	x = 12 + 6 / 3 - 7
	print x # output : 7