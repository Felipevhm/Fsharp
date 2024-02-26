// b) função que calcula o número de fibonacci para um número dado 
// (utilize um algortimo recursivo)

let rec fibonacci (n:int) =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ ->  ( (n-1) |> fibonacci ) + ( (n-2) |> fibonacci ) 

  
let result = fibonacci 10

printfn "%i" result

// output: 55