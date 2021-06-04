# Interpreter

Interpreter can be used both for developers and users

## Developers

To interpretate your code, at first you need to create an abstract sytax tree by using the following function
`Main.parse <string>`

Then you can run the `Interpreter.run <ast>` function that returns three dictionaries. The first contains values of all variables in `Exp.Expression` format,the second contains variables in `string` format, the third has only one key - `"print"` with string of result of interpretation.
You can also get a dot file which contains a syntax tree by using `DrawTree.drawTree <ast> <output file path>`

### Another functions

* `processExpr (vDict: Dictionary<AST.VName,AST.Expression>) (expr: Exp.Expression)` - return a result of a given expression in `BigInt` format
* `processStmt (vDict: Dictionary<AST.VName,AST.Expression>) (stmt: Exp.Stmt) (pDict: Dictionary<string,string>)` - gets an expression from a statement and sets it's value to a dictionaries with variable as a key
* `calculate (ast: Exp.Stmt list)` - assisting function to compute a result of code with a single statement

### Example on F#:
#
	let x = "x = 228 print x"
	let ast = parse x
	let _, _, pDict = Interpreter.run ast
	printfn "%s" pDict.["print"]
Given code prints "228" into console

## Users

There are only four console commands in CalculatorFSharp

* `--inputfile <file path>` - enter a file with code
* `--inputstring <string>` - enter a string with code
* `--compute` - return the result of interpretation of the code
* `--todot <file path>` - return dot code of syntax tree to the given file

Just run "CalculatorFSharp.exe" from console with given commands