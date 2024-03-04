//  a) função que soma dois números

module Sum

let sum (x:float) (y:float) = x + y

let n1 = 3
let n2 = 4

let result = sum n1 n2

//
printfn $"A soma de {n1} e {n2} é {result} "