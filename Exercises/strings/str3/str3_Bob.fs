module Bob
// response "1, 2, 3" |> should equal "Whatever."
// response "4?" |> should equal "Sure."
//response ":) ?" |> should equal "Sure."
// response "Okay if like my  spacebar  quite a bit?   " |> should equal "Sure."
let response (input: string): string =

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

        let returnFcn (inputString: string):string = 
                let stringValue = Some inputString
                if (isQuestion inputString) && (not (isCapital inputString)) && (not (isBlank stringValue)) then
                        "Sure."
                elif (not (isQuestion inputString)) &&  (isCapital inputString) && (not (isBlank stringValue)) then
                        "Whoa, chill out!"
                elif (isQuestion inputString) &&  (isCapital inputString) && (not (isBlank stringValue)) then
                        "Calm down, I know what I'm doing!"
                elif (isBlank stringValue) then
                        "Fine. Be that way!"
                else 
                        "Whatever."
        returnFcn input

let inputString = "          "
printfn "%s" (response inputString )



// let isBlankSpace =
