module ToDot

open Exp
open System.Collections.Generic
open BigAriphmetics

let private toDotList = new Stack<_>()
let private opNumbers = new Stack<_>() // нужно нумеровать операции чтобы они не склеивались в доте
opNumbers.Push("op0[shape = ellipse, label = program]")
let mutable private counter = 0

let private giveSerialNumber stringNameOp =
    counter <- counter + 1
    let numOfOp = "op" + string counter
    opNumbers.Push(numOfOp + sprintf "[shape = ellipse, label = %A];" stringNameOp)
    numOfOp

let private recognizeTwoVar vDict x y stringNameOp preOperationString mainRec = // вынес код и переиспользую
    let opNum = giveSerialNumber stringNameOp
    toDotList.Push(preOperationString + " -> " + opNum)
    (mainRec vDict x opNum)
    (mainRec vDict y opNum) 

let private recognizeOneVar vDict x stringNameOp preOperationString mainRec =
    let opNum = giveSerialNumber stringNameOp
    toDotList.Push(preOperationString + " -> " + opNum) 
    (mainRec vDict x opNum)

let private recognizePrintVdeclNvar t toDotOp str =
    let name =
        string <|
        match t with
        | Var t -> t
    let nvar = giveSerialNumber str
    let nVarName = giveSerialNumber name
    toDotList.Push(toDotOp + " -> " + nvar)
    toDotList.Push(nvar + " -> " + nVarName)
    nvar
    
let private processExpr (vDict: Dictionary<_,_>) expr toDotOp =
    let rec _go (vDict: Dictionary<_,_>) expr toDotOp = 
        match expr with
        | Exp.Num t -> toDotList.Push(toDotOp + " -> " + string (giveSerialNumber (string (toInt t))))          
        | Exp.NVar t -> recognizePrintVdeclNvar t toDotOp "Exp.Nvar" |> ignore
        | Exp.Sum (x, y) -> recognizeTwoVar vDict x y " Exp.Sum " toDotOp _go 
        | Exp.Sub (x, y) -> recognizeTwoVar vDict x y " Exp.Sub " toDotOp _go   
        | Exp.Mul (x, y) -> recognizeTwoVar vDict x y " Exp.Mul " toDotOp _go   
        | Exp.Div (x, y) -> recognizeTwoVar vDict x y " Exp.Div " toDotOp _go
        | Exp.Abs x -> recognizeOneVar vDict x " Exp.Abs " toDotOp _go
        | Exp.Bin x -> recognizeOneVar vDict x " Exp.Bin " toDotOp _go
        | Exp.Pow (x, y) -> recognizeTwoVar vDict x y " Exp.Pow " toDotOp _go
        | Exp.DivRem (x, y) -> recognizeTwoVar vDict x y " Exp.DivRem " toDotOp _go        
    _go vDict expr toDotOp 

let drawParseTree ast path =   
    let processStmt (vDict: Dictionary<_,_>) stmt =
        match stmt with
        | Exp.Print t -> recognizePrintVdeclNvar t "op0" "Print" |> ignore         
        | Exp.VDecl (x, y) ->
            let vDecl = recognizePrintVdeclNvar x "op0" "VDecl"
            if vDict.ContainsKey x
            then vDict.[x] <- processExpr vDict y vDecl
            else vDict.Add (x, processExpr vDict y vDecl)
        vDict        
    let vDict = new Dictionary<_,_>()
    List.fold processStmt vDict ast |> ignore
    let secArr = Array.append [|"digraph ParseTree"; "{"; "rankdir = TB"|] (Array.rev (opNumbers.ToArray()))
    let firstArr = (toDotList.ToArray())
    let newArr = Array.append secArr firstArr 
    newArr.[newArr.Length - 1] <- newArr.[newArr.Length - 1] + "}"
    System.IO.File.WriteAllLines (path, List.ofArray newArr)
