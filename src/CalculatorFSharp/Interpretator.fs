module Interpretator

open Listik
open BigAriphmetics
open System.Collections.Generic

let rec processExpr (vDict: Dictionary<_,_>) expr =
    match expr with
    | Exp.Num t -> t
    | Exp.NVar t ->
        let data =
            try
                vDict.[t]
            with
            | _ -> failwithf "Variable %A is not declared" t
        data
    | Exp.Sum (x, y) -> sum (processExpr vDict x) (processExpr vDict y)
    | Exp.Sub (x, y) -> sub (processExpr vDict x) (processExpr vDict y)
    | Exp.Mul (x, y) -> multiply (processExpr vDict x) (processExpr vDict y)
    | Exp.Div (x, y) -> division (processExpr vDict x) (processExpr vDict y)
    | Exp.Abs x -> absolute (processExpr vDict x) 
    | Exp.Bin x -> toBinary (processExpr vDict x) 
    | Exp.Pow (x, y) -> power (processExpr vDict x) (processExpr vDict y)
    | Exp.DivRem (x, y) -> remDiv (processExpr vDict x) (processExpr vDict y)

let processStmt (vDict: Dictionary<_,_>) stmt =
    match stmt with
    | Exp.Print t ->
        let (data: BigInt) =
            try
                vDict.[t]
            with
            | _ -> failwithf "Variable %A is not declared" t      
        printfn "%A" (toInt data)
    | Exp.VDecl (x, y) ->
        if vDict.ContainsKey x
        then vDict.[x] <- processExpr vDict y
        else vDict.Add (x, processExpr vDict y)
    vDict

let calculate (ast: Exp.Program) =
    toInt <|
    match ast.[0] with
    | Exp.VDecl (_, e) -> processExpr (Dictionary<_,_>()) e
    | _ -> failwith "unexpected statement"

let run ast =
    let vDict = new Dictionary<_,_>()
    List.fold processStmt vDict ast |> ignore
