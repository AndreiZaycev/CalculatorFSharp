# CalculatorFSharp

CalculatorFsharp is a library and executable file for F # that can do some regular expression tasks. This project was created as one of the homework, the Calculator was created using auxiliary tools: FsLexYacc(https://github.com/fsprojects/FsLexYacc), MiniScaffold(https://github.com/TheAngryByrd/MiniScaffold). 

## Builds

GitHub Actions |
:---: |
[![GitHub Actions](https://github.com/AndreiZaycev/CalculatorFSharp/workflows/Build%20master/badge.svg)](https://github.com/AndreiZaycev/CalculatorFSharp/actions?query=branch%3Amaster) |
[![Build History](https://buildstats.info/github/chart/AndreiZaycev/CalculatorFSharp)](https://github.com/AndreiZaycev/CalculatorFSharp/actions?query=branch%3Amaster) |

## Getting Started

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

## Usage

CalcFSharp contains a console application with interpreter for arithmetic expressions and BigAriphmetics -- library contains implementation of long arithmetic using language
F# and auxiliary library Listik

## Documentation

The [docs](https://AndreiZaycev.github.io/CalculatorFSharp/) contains an overview of the tool and how to use it

## Requirements 

.NET >= 5.0
