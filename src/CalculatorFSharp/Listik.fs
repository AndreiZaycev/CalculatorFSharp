module Listik

type MyList<'t> =
    | One of 't
    | Cons of 't * MyList<'t>

type MyString = MyList<char>

let rec fold f acc x =
    match x with
    | One t -> f acc t  
    | Cons (hd, tl) -> fold f (f acc hd) tl
    
let length x =
    fold (fun acc elem -> acc +  1) 0 x

let toMyList x = 
    if List.length x < 1
    then failwith "use correct list"
    else
        let y = List.rev x
        List.fold (fun acc elem -> if List.isEmpty x then acc else Cons (elem, acc)) (One y.[0]) (y.Tail)

let toSystemList x =        
    List.rev (fold (fun acc elem -> elem :: acc) [] x)

let generator t =
    if t < 1
    then failwith "MyList cannot be created because input values uncorrect"
    else (toMyList (List.init t (fun _ -> System.Random().Next(0,10))))

let rec concat x y =
    match x with
    | One t -> Cons (t, y)
    | Cons (i, o) -> Cons (i, concat o y)

let sort x = 
    let rec _go x =
        match x with
        | One t -> x
        | Cons (head, Cons (head2, tl)) when head > head2 -> (Cons (head2, _go (Cons (head, tl))))
        | Cons (head, Cons (head2, tl)) -> (Cons (head, _go (Cons (head2, tl))))
        | Cons (head, One t) when head < t -> Cons (head, One t)
        | Cons (head, One t) -> Cons (t, One head)  
    let rec _go1 x k =
        match k with
        | k when (k = length x) -> x
        | _ -> _go1 (_go x) (k + 1)
    _go1 (_go x) 0
           
let rec iter f x =
    match x with
    | One t -> f t
    | Cons (i, o) ->
        f i
        iter f o

let rec map f x =
    match x with
    | One t -> One (f t)
    | Cons (i, o) -> Cons (f i, map f o)

let concatMyString (x: MyString) (y: MyString) =
    (concat x y): MyString 

let toMyString (str: string) =
    let k = [for i in str -> i]
    toMyList k:MyString

let toString (x: MyString) =
    fold (fun acc elem -> acc + string elem) "" x
  
let indexElem x i = // индекс i листа x
    if i < 1 then failwith "wrong index"
    else 
        let mutable firstElem =
            match x with
            | One t ->  t
            | Cons (hd, tl) -> hd
        let mutable k = 1
        iter (fun elem -> if k = i then firstElem <- elem; k <- k + 1 else k <- k + 1) x
        firstElem

let tail x = 
    match x with
    | One t -> failwith "list length is not suitable"
    | Cons (hd, tl) -> tl

let tailOrZero x = // хитрый хвост листа, который для последнего элемента возвращает One 0  
    match x with
    | One t -> One 0
    | Cons (hd, tl) -> tl

let head x = indexElem x 1

let rev x = 
    if length x > 1
    then fold (fun acc elem -> Cons (elem, acc)) (One (head x)) (tail x)
    else x

let map2 f x y = 
    let rec _go f acc x y =
        match x, y with
        | One t, One k -> Cons (f t k, acc)
        | Cons (hd, tl), Cons(hd1, tl1) -> _go f (Cons (f hd hd1, acc)) tl tl1
        | _, _ -> failwith "cannot be in this case"
    if length x <> length y
    then failwith "lengths are not equal"
    else
        match x, y with
        | One t, One k -> One (f t k)
        | Cons (hd, tl), Cons (hd1, tl1) -> _go f (One (f hd hd1)) tl tl1 |> rev
        | _, _ -> failwith "cannot be in this case"
