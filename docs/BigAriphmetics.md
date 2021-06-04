# BigAriphmetics 

BigAriphmetic is an attempt to create long arithmetic on F#.

## Type

An instanse of BigInt consists of `signOfNumber of <Sign>` and `digits of <MyList<int>>`.
`Sign` type has only two values - `Positive` and `Negative`.
`MyList<int>` consists of integers from 0 to 9.

## Methods BigInt

* `convertStringToNegative (y: string)` - returns negative BigInt
* `BigInt.toString` - converts BigInt to string

## Functions

* `toInt (data: BigInt)` - returns integer from BigInt
* `initPosInt (x: MyList<int>)` - creates absolute BigInt
* `createBigInt (length: int)` - creates BigInt by length 
* `addZeroEnd (x: MyList<int>) (k: int)` - adds zeroes at end of BigInt
* `compareNumbers (x: MyList<int>) (y: MyList<int>)` - compares two numbers
* `deleteZeroes (x: MyList<int>)` - deletes insignificant zeroes from list
* `equalizeLength (x: BigInt) (y: BigInt)` - equalizes length of two numbers 
* `transferDigits (x: MyList<int>)` - transfers remainders from position to next position
* `sum (x:BigInt) (y:BigInt)` - returns sum of two numbers
* `sub (x:BigInt) (y:BigInt)` - returns a result of subtraction of two numbers
* `multiply (x:BigInt) (y:BigInt)` - returns a result of multiplication of two numbers
* `divAndRem (x:BigInt) (y:BigInt)` - returns a pair of remainder and whole part of division in `BigInt` type
* `division (x:BigInt) (y:BigInt)` - returns a whole part of division
* `remDiv (x:BigInt) (y:BigInt)` - returns a remainder from division
* `power (x:BigInt) (y:BigInt)` - returns a result of exponentiation 
* `toBinary (x:BigInt)` - converts a number to it's binary representation 
* `absolute (x:BigInt)` - return an absolute value of a number  