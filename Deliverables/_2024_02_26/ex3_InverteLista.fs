let rec inverteLista lista =
    match lista with
    | [] -> []
    | cabeca :: cauda -> (inverteLista cauda) @ [cabeca]

// Exemplo de uso
let listaOriginal = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11]
let listaInvertida = inverteLista listaOriginal

printfn "Lista Original: %A" listaOriginal
printfn "Lista Invertida: %A" listaInvertida