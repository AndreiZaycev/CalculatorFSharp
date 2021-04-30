# Listik

MyList is a non-empty list library which is used in a BigAriphmetics module.

## Type

`MyList` is a discriminated union with `One of 't` or `Cons of 't * MyList<t>`. 

## Functions

* `head (x:MyList<'t>)` - returns a head of a list
* `tail (x:MyList<'t>)` - reurns a tail of a list
* `fold (f:'a -> 'b -> 'a) (acc:'a) (x:MyList<'b>)` - changes a sign of a number
* `length (x:MyList<'t>)` - returns a length of a list
* `concat (x:MyList<'t>) (y:MyList<'t>)` - deletes all zeroes from the begining of a list
* `map (f:'a -> 'b) (x:MyList<'a>)` - returns a list to whose elements the given function has been applied 
* `iter (f:'a -> unit) (x:MyList<'a'>)` - applies a given function to each element of a list
* `sort (x:MyList<'t>)` - returns a sorted list
* `toMyList (x:List<'t>)` - converts `List` to `MyList`
* `generator (t: int)` - generates MyList with length equal t
* `toSystemList (x:MyList<'t>)` - converts `MyList` to `List`
* `rev (x:BigInt)` - returns a list with elements in a reversed order
* `intToMyList (i:int)` - converts `int` to `MyList`
* `indexElem (x: MyList<'t>) (i: int)` - returns the elemnt on i position
* `map2 (f: 'a -> 'b -> 'a) (x: MyList<'a>) (y: MyList<'b>)` - //map2 (easter egg) returns two list to whose elements the given function has been applied 