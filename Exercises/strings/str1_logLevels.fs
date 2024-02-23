module LogLevels

let message (logLine: string): string = 
//failwith "Please implement the 'message' function"
        let stringArray = logLine.Split([|':'|])
        let m = stringArray.[1].Trim()
        m

let logLevel(logLine: string): string = 
//failwith "Please implement the 'logLevel' function"
        let stringArray = logLine.Split([|':'|])
        let m = stringArray.[0]
        m.Replace("[", "")
         .Replace("]","")
         .ToLower()

let reformat(logLine: string): string = 
//failwith "Please implement the 'reformat' function"
    let stringArray = logLine.Split([|':'|])
    let newLog = stringArray.[0].Replace("[", "(").Replace("]",")").ToLower()

    let newMessage = $"{stringArray.[1].Trim()} {newLog}"
    newMessage
    



let input = "[ERROR]: Invalid operation"
let level = reformat input

printfn "%s" level
