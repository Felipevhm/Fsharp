let twoFer (input: string option): string = 
        let message = 
        
                if input = None then
                                "One for you, one for me."
                else 
                                let value = input.Value
                                $"One for {value}, one for me."
        message
let personName = Some "Ronaldo"

let ans = twoFer  personName

printfn "%s" ans 