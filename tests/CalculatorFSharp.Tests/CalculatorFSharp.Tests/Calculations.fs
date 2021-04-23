module Calculations

open Main
open Interpretator
open Expecto

let pr1 =
    """
    x = 228
    y = 1337
    z = y / x * 5
    print x
    print y
    print z
    """
Interpretator.run (parse pr1)
printfn "Expected \n228\n1337\n25"

[<Tests>]
let parsingString =
    testList "check all operations"
        [
            testCase "test (+) parsing"
            <| fun _ ->                
                let subject =
                    parse
                        ("x = " + "12 + 3 - 5 + 12 - 25 * (25 + 3) / 14 - 14 * 6 + 7 / 12 - 12 / 2 / 2")
                let expectedAns = -115
                let ans = calculate subject                
                Expect.equal ans expectedAns "needs to be equal"

            testCase "test1"
            <| fun _ ->                
                let subject = parse ("x = " + "2 + 3 + 4 - 2 - 2 - 2 - 3 * (2 - 3 - 3 + 4) + 12 / 2 / 2")
                let expectedAns = 6
                let ans = calculate subject 
                Expect.equal ans expectedAns "needs to be equal"

            testCase "test2"
            <| fun _ ->                
                let subject = parse ("x = " + "228 - 1337 * 666 + 69")
                let expectedAns = -890145
                let ans = calculate subject              
                Expect.equal ans expectedAns "needs to be equal"

            testCase "unar - test"
            <| fun _ ->                
                let subject = parse ("x = " + "-2")
                let expectedAns = -2
                let ans = calculate subject               
                Expect.equal ans expectedAns "needs to be equal"

            testCase "test3"
            <| fun _ ->                
                let subject = parse ("x = " + "(2 + 3) - (2 + 3)")
                let expectedAns = 0
                let ans = calculate subject              
                Expect.equal ans expectedAns "needs to be equal"

            testCase "test4"
            <| fun _ ->                
                let subject = parse ("x = " + "2 - 3 - 3")
                let expectedAns = -4
                let ans = calculate subject             
                Expect.equal ans expectedAns "needs to be equal"

            testCase "priorities"
            <| fun _ ->                
                let subject = parse ("x = " + "1 + 2 * 3 - 7 / (2 + 5)")
                let expectedAns = 6
                let ans = calculate subject             
                Expect.equal ans expectedAns "needs to be equal"

            testCase "prioritiesModule"
            <| fun _ ->                
                let subject = parse ("x = " + "{-2 - 2 * 3} + 7")
                let expectedAns = 15
                let ans = calculate subject             
                Expect.equal ans expectedAns "needs to be equal"

            testCase "binary"
            <| fun _ ->                
                let subject = parse ("x = " + "# 12 + 4 - 12 / 12 + 1")
                let expectedAns = 10000
                let ans = calculate subject             
                Expect.equal ans expectedAns "needs to be equal"

            testCase "pow priority"
            <| fun _ ->                
                let subject = parse ("x = " + "2 / 2 ^ 3")
                let expectedAns = 0
                let ans = calculate subject             
                Expect.equal ans expectedAns "needs to be equal"

            testCase "div rem"
            <| fun _ ->                
                let subject = parse ("x = " + "143 % 10 + 2")
                let expectedAns = 5
                let ans = calculate subject             
                Expect.equal ans expectedAns "needs to be equal"

        ]
[<Tests>]
let exceptions =
    testList "exceptions"
        [
            testCase "specify numbers"
            <| fun _ ->                
                let x = "x = 0001 "            
                Expect.throws (fun _ -> calculate (Main.parse x)|> ignore) "exception"
            testCase "div by zero"
            <| fun _ ->                
                let x = "x = 12 / 0 "            
                Expect.throws (fun _ -> calculate (Main.parse x) |> ignore) "exception"
        ]
