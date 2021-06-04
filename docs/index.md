# CalculatorFSharp

CalculatorFSharp is a library which mainly designed to compute arithmetic expressions.
CalculatorFSharp contains an interpreter for the simple programming language, long arithmetic and non-empty list libraries.

## Installing

You can install the package with dotnet by following this steps:

* Add a source in your NuGet.config file
#
	dotnet nuget add source "https://nuget.pkg.github.com/AndreiZaycev/index.json"
* Authorize with your github token
#
	paket config add-token "https://nuget.pkg.github.com/AndreiZaycev/index.json" <token>
* Install the package
#
	dotnet add PROJECT package CalculatorFSharp --version <version>