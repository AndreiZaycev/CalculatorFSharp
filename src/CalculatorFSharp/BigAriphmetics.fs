module BigAriphmetics

open System

open Listik

type Sign =
    | Positive 
    | Negative 

let private detect x = if x = 1 then Positive elif x = -1 then Negative else failwith "wrong sign"

type BigInt =
    val signOfNumber: Sign
    val digits: MyList<int>
    new ((k: int), p) = {signOfNumber = (detect k); digits = p}
    member this.sign = if this.signOfNumber = Positive then 1 else -1
    static member convertString (str: string) =
        let y = str.Trim()
        if y.Length = 0
        then failwith "input not empty data!"
        else
            let sgn, x =  
                match y.Contains '-' with
                | true -> -1, y.[1..(y.Length - 1)]
                | false -> 1, y
            let rec _go acc (x: string) =
                match x.Length with
                | 0 -> acc 
                | _ -> _go (Cons((string x.[0]) |> int |> abs, acc)) x.[1..(x.Length - 1)]
            BigInt(sgn, (rev (_go (One 0) x)) |> tail)
    static member convertStringToNegative (y: string) =
        BigInt(-1, (BigInt.convertString y).digits)
    member this.toString =
        let r = this.digits |> fold (fun acc x -> acc + string x) ""
        if this.sign = -1 then "-" + r else r

let toInt (data: BigInt) =
    let x = fold (fun acc elem -> acc + string elem) "" data.digits |> int
    if data.sign = 1
    then x
    else -x
        
let initPosInt x = BigInt (1, x) 

let createBigInt length =
    let randomSign = System.Random().Next(0,2) 
    let out = generator length
    if randomSign = 0
    then BigInt (-1, out)
    else BigInt (1, out)

// добавляет 0 впереди числа
let rec private addZeroBeginning acc k = if k = 1 then acc else addZeroBeginning (Cons (0, acc)) (k - 1)

// добавляет 0 в конце числа 
let private addZeroEnd x k = rev (addZeroBeginning (rev x) k)

// возвращает true если x >= y иначе false для листов (проще говоря сравнивает числа по модулю)
let compareNumbers x y =
    if length x = length y
    then
        let rec _go x y =
            match x, y with
            | One t, One k -> t >= k
            | Cons (hd, tl), Cons (hd1, tl1) -> if hd = hd1 then _go tl tl1 else hd > hd1
            | _, _ -> failwith "cant be in this case"
        _go x y 
    else length x >= length y

let private deleteZeroes x = // удаляет нули незначащие
    let rec _go x =
        match x with
        | One k -> One k 
        | Cons (0, tl) -> _go tl
        | Cons (hd, tl) -> Cons (hd, tl)
    _go x

let private equalizeLength (x: BigInt) (y: BigInt) =
    if length x.digits > length y.digits
    then x, BigInt (y.sign, addZeroBeginning y.digits (length x.digits - length y.digits + 1))
    elif length x.digits < length y.digits
    then BigInt (x.sign, addZeroBeginning x.digits (length y.digits - length x.digits + 1)), y
    else x, y

let transferDigits x =
    let output = 
        fold
            (fun (remainder, acc) elem ->
                let current = elem + remainder
                if current >= 0
                then (current / 10, Cons (current % 10, acc))
                else (-1, Cons ((10 + (current % 10)) % 10, acc)))
            (0, One 0)
            (rev x)
    if fst output <> 0
    then Cons (fst output, rev (tailOrZero (rev (snd output)))) |> deleteZeroes 
    else rev (tailOrZero (rev (snd output))) |> deleteZeroes
 
let sum (x: BigInt) (y: BigInt) =
    // если знаки равны просто складываем, если нет то находим большее по модулю и однозначно знаем откуда вычитать
    let fList, sList = equalizeLength x y 
    if fList.sign = sList.sign
    then BigInt (fList.sign, transferDigits (map2 (+) fList.digits sList.digits))
    elif compareNumbers fList.digits sList.digits  
    then BigInt (fList.sign, transferDigits (map2 (-) fList.digits sList.digits))
    else BigInt (sList.sign, transferDigits (map2 (-) sList.digits fList.digits))

let sub (x: BigInt) (y: BigInt) = sum x (BigInt (y.sign * -1, y.digits)) 

let multiply (x: BigInt) (y: BigInt) =
    // я придумал обходилку эксепшона с вызовом хвоста у единичного листа, везде юзаю special tail
    // и добавляю к изначальным листам по 1 нулю, и тогда, когда попадается лист длины 1, все работает исправно
    let fList, sList = addZeroBeginning x.digits 2, addZeroEnd (rev y.digits) 2
    let fIter = fold (fun acc elem -> Cons ((elem * head sList), acc)) (One (head fList * head sList)) (tailOrZero fList) |> rev
    let mutable k = 1
    let output = 
        fold
            (fun acc elem ->               
                k <- k + 1
                sum
                    (initPosInt ((addZeroBeginning
                                   (fold
                                       (fun acc1 elem1 -> Cons ((elem1 * elem), acc1))
                                       (One (head fList * elem))
                                       (tailOrZero fList)) k) |> rev))
                    acc)
            (initPosInt fIter)
            (tailOrZero sList)
    BigInt (x.sign * y.sign, deleteZeroes output.digits)

// умножалка по модулю
let private absMul x y = (multiply (BigInt (1, x)) (BigInt (1, y))).digits

let divAndRem (x: BigInt) (y: BigInt) =
    let divident, divisor = (deleteZeroes x.digits), (deleteZeroes y.digits)
    if divisor = One 0
    then failwith "cannot divide"              
    else
        let returnRemainder divident0 counter =
            let mutable counter1 = counter
            while compareNumbers divident0 (absMul (One counter1) divisor) do counter1 <- counter1 + 1
            (One (counter1 - 1)), (sub (initPosInt divident0) (initPosInt (absMul (One (counter1 - 1)) divisor))).digits        
        let first, second =
            fold
                (fun (acc, current) elem ->
                    let currentInstance = (deleteZeroes (concat current (One elem)))
                    if divisor = currentInstance
                    then ((concat acc (One 1)), One 0)                   
                    elif compareNumbers divisor currentInstance
                    then ((concat acc (One 0)), currentInstance)
                    else
                        let dividentValue, remainder = returnRemainder currentInstance 0
                        (deleteZeroes (concat acc dividentValue), remainder))
                (One 0, One 0)
                (divident)
        (deleteZeroes first, deleteZeroes second)

let absolute (x:BigInt) = BigInt(1, x.digits)

let division (x: BigInt) (y: BigInt) =
    BigInt (x.sign * y.sign, divAndRem x y |> fst)

let remDiv (x: BigInt) (y: BigInt) =
    let semiAns = BigInt (1, divAndRem x y |> snd)
    match x.sign, y.sign with
    | -1, 1 -> sub y semiAns
    | 1, -1 -> semiAns
    | -1, -1 -> sub (absolute y) semiAns
    | 1, 1 -> semiAns
    | _, _ -> failwith "cannot be in this case"

let power (x: BigInt) (pow: BigInt) =
    let rec _go r (p: BigInt) =
        match p.digits with
        | One 0 -> BigInt(1, One 1)
        | One 1 -> r
        | _ -> _go (multiply r x) (sub p (BigInt(1, One 1)))

    if pow.sign = -1 then failwith "Positive power expected"
    else _go x pow

let toBinary (x: BigInt) =
    let rec _go l r =
        match l with
        | One 0 -> r
        | _ ->
            let divd, rem = divAndRem (BigInt(1, l)) (BigInt(1, One 2))
            _go divd (Cons(head rem, r))

    let divd, rem = divAndRem (BigInt(1, x.digits)) (BigInt(1, One 2))

    BigInt(x.sign, _go divd rem)
