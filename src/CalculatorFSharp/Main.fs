module Main
open Argu
open FSharp.Text.Lexing

type CLIArguments =
    | InputFile of string
    | InputString of string
    | ToDot of string
    | Compute 
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | InputFile _ -> "reads file"
            | InputString _ -> "reads string"
            | ToDot _ -> "prints to dot"
            | Compute _ -> "computes expression"

let parse (text: string) =
    let lexbuf = LexBuffer<char>.FromString text
    let parsed = CalcParser.start Lexer.tokenStream lexbuf   
    parsed

[<EntryPoint>]
let main (argv: string array) =
    let parser = ArgumentParser.Create<CLIArguments>(programName = "Arithmetics interpreter")
    let results = parser.Parse(argv)
    let p = parser.ParseCommandLine argv
    if argv.Length = 0 || results.IsUsageRequested then parser.PrintUsage() |> printfn "%s"
    else
        let input =
            if p.Contains(InputFile) then (System.IO.File.ReadAllText (results.GetResult InputFile))
            elif p.Contains(InputString) then results.GetResult InputString
            else failwith "code do not contains key word"
        let ast = parse input
        if p.Contains(Compute) then Interpretator.run ast
        if p.Contains(ToDot) then ToDot.drawParseTree ast (results.GetResult ToDot)
    0
