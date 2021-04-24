# CalculatorFSharp

CalculatorFsharp is a library and executable file for F # that can do some regular expression tasks.

# Executable file 

Install the latest release then run the executable file.

	 * --inputstring <input> - The command that reads the entered line
	 * --inputfile <input> - The command that read the entered file 
	 * --compute - The command that compute input expression
	 * --todot <input> - The command that compute expression and prints syntax tree in file 
	 * --help - The command for more information

Syntax and the other features you can read [here](https://github.com/AndreiZaycev/CalculatorFSharp/blob/master/docs/index.md).

# Library 


The CalculatorFSharp provides several functions that can be used in your code:
	
```
	parse - Parses the regular expression and build program instructions
	run - Runs the program instructions and return Queue that contains commands to be printed
	drawParseTree - Runs the program instructions and print syntax tree to a file
```

To download paket use this commands:
```
$ paket config add-token "https://nuget.pkg.github.com/AndreiZaycev/index.json" YOUR_GITHUB_PAT
# If you dont have paket dependencies, use $ paket init
$ dotnet add PROJECT package CalculatorFSharp --version 1.0.0
```
