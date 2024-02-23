// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from Margheritta"


let printGreeting name = printfn $"{name}"

printGreeting "Barnabé"

let expectedMinutesInOven  = 40
printGreeting expectedMinutesInOven

let remainingMinutesInOven actualMinutesInOven =
     expectedMinutesInOven - actualMinutesInOven

let a = remainingMinutesInOven 30

printGreeting a

// layers

let preparationTimeInMinutes layers = layers*2

let b = preparationTimeInMinutes 3

printGreeting b

let elapsedTimeInMinutes layers actualMinutesInOven =
    2*layers + actualMinutesInOven

let c = elapsedTimeInMinutes 3 10

printGreeting c