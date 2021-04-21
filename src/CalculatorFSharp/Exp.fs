module Exp
open System.Collections.Generic
open BigAriphmetics

type VName = Var of string

type Expression =
    | Num of BigInt
    | NVar of VName
    | Sum of Expression * Expression
    | Sub of Expression * Expression
    | Div of Expression * Expression
    | Mul of Expression * Expression
    | Pow of Expression * Expression
    | DivRem of Expression * Expression
    | Bin of Expression
    | Abs of Expression

type Stmt =
    | Print of VName
    | VDecl of VName * Expression

type Program = list<Stmt>
