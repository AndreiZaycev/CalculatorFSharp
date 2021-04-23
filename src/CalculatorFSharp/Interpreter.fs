namespace CalculatorFSharp

module Interpreter = 

    open Listik
    open BigAriphmetics
    open System.Collections.Generic

    let rec processExpr (vDict:Dictionary<Exp.VName,Exp.Expression>) expr =
        match expr with
        | Exp.Num t -> t
        | Exp.NVar t ->
            let data =
                try
                    vDict.[t]
                with
                | _ -> failwithf "Variable %A is not declared" t
            processExpr vDict data
        | Exp.Sum (x, y) -> sum (processExpr vDict x) (processExpr vDict y)
        | Exp.Sub (x, y) -> sub (processExpr vDict x) (processExpr vDict y)
        | Exp.Mul (x, y) -> multiply (processExpr vDict x) (processExpr vDict y)
        | Exp.Div (x, y) -> division (processExpr vDict x) (processExpr vDict y)
        | Exp.Abs x -> absolute (processExpr vDict x) 
        | Exp.Bin x -> toBinary (processExpr vDict x) 
        | Exp.Pow (x, y) -> power (processExpr vDict x) (processExpr vDict y)
        | Exp.DivRem (x, y) -> remDiv (processExpr vDict x) (processExpr vDict y)

    let processStmt (vDict:Dictionary<Exp.VName,Exp.Expression>) stmt (pDict:Dictionary<string,string>) =
        match stmt with
        | Exp.Print t ->
            let data =
                try
                    vDict.[t]
                with
                | _ -> failwithf "Variable %A is not declared" t      
            match data with
            | Exp.Num n ->
                let num = n.ToString()
                pDict.["print"] <- (pDict.["print"] + (if num.[0] = '+' then num.[1..] else num) + "\n")
            | _ -> failwith "Num expected" 
        | Exp.VDecl (x, y) ->
            if vDict.ContainsKey x
            then vDict.[x] <- Exp.Num (processExpr vDict y)
            else vDict.Add(x, Exp.Num(processExpr vDict y))
        vDict, pDict

    let calculate (ast: Exp.Program) =
        toInt <|
        match ast.[0] with
        | Exp.VDecl (_, e) -> processExpr (Dictionary<_,_>()) e
        | _ -> failwith "unexpected statement"

    let run ast =
        let vDict = Dictionary<_,_>()
        let pDict = Dictionary<_,_>()
        pDict.Add("print", "")
        List.fold (fun (d1, d2) stmt -> processStmt d1 stmt d2) (vDict, pDict) ast
     
