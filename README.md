CalculatorFSharp
&middot;
GitHub Actions |
:---: |
[![GitHub Actions](https://github.com/AndreiZaycev/CalculatorFSharp/workflows/Build%20master/badge.svg)](https://github.com/AndreiZaycev/CalculatorFSharp/actions?query=branch%3Amaster) |
[![Build History](https://buildstats.info/github/chart/AndreiZaycev/CalculatorFSharp)](https://github.com/AndreiZaycev/CalculatorFSharp/actions?query=branch%3Amaster) |


CalculatorFsharp is a library and executable file for F # that can do some regular expression tasks. This project was created as one of the homework, 
the Calculator was created with [FsLexYacc](https://github.com/fsprojects/FsLexYacc).

## Features
* Calculates **arithmetic expressions**.
* It can count large numbers.
* Supports simple math operations.
* Can print result in console.

## Contents
- [Features](#features)
- [Building](#building)
- [Using CalculatorFSharp in your project](#using-calculatorfsharp-in-your-project)
- [Usage and examples](#usage-and-examples)
- [Detailed documentation](#detailed-documentation)
- [Publication](#publication)
- [Requirements](#requirements)


## Building

You can install the package with dotnet by following this steps:

* Add a source in your NuGet.config file
#
	dotnet nuget add source "https://nuget.pkg.github.com/AndreiZaycev/index.json"
* Authorize with your github token
#
	paket config add-token "https://nuget.pkg.github.com/AndreiZaycev/index.json" <token>
* Install the package
#
	dotnet add PROJECT package CalcFSharp --version <version>

## Using CalculatorFSharp in your project
Here is a standard example of the Calculator in your project:

```cpp
open CalcFSharp

let _, out = Interpreter.run(Main.parse("x = 5 print x")
printfn "%A" pd.["print"] 
```

Running it should output `5`.


## Usage and examples
Each arithmetic expression is defined as variable which can be used in other expressions. Result of each expression can be printed in console Code consists of statements with expressions and variable's names associated with them. Each arithmetic expression is defined as variable which can be used in other expressions. Value of a variable can be printed in console.

There are only two statements supported in this language:

	var = expr # Variable declaration, var is name of variable which consists of 'a' - 'z', 'A' - 'Z' symbols, expr is number or expression
	print var # To print something you need use key "print" and specify variable you want to output

Examples:

	x = 5 
	x = x + 10 # x = 15


	x = 5
	y = 6
	z = 5 
	x = (x + y) / z 
	print x # output : 2


	x = 12 + 6 / 3 - 7
	print x # output : 7


## Detailed documentation

For complete documentation of CalculatorFSharp, visit [documentation](https://AndreiZaycev.github.io/CalculatorFSharp/).

## Publication

AndreiZaycev; CalculatorFSharp: Arithmetic expression interpreter.

## Requirements

.NET >= 5.0.
