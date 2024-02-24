module Bob


//let response (input: string): string =

let input = "            a         "

let isQuestion = input.EndsWith("?")
let isCapital = (input = input.ToUpper()) && (input <>"")

// A function that checks if a string is empty or has a non-blank character
let isBlank (s: string):bool =
                let out = System.String.IsNullOrWhiteSpace s
                out 

let returnFcn = isBlank input
printfn "%b" returnFcn



// let isBlankSpace =
