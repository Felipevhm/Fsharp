module Bob


//let response (input: string): string =

let input = "            a         ?"

let isQuestion (text:string):bool =
                let output = text.EndsWith("?")
                output

let isCapital (text:string):bool = 
                let output = (text = text.ToUpper()) && (text <>"")
                output

let isBlank (s: string option):bool =
                if s = None then
                        false
                else
                let value = s.Value
                let output = System.String.IsNullOrWhiteSpace value
                output 

let returnFcn = isBlank None
printfn "%b" returnFcn



// let isBlankSpace =
