let inverteLista lista =
    let rec auxiliar acc lista =
        match lista with
        | [] -> acc
        | cabeca :: cauda -> auxiliar (cabeca :: acc) cauda
    auxiliar [] lista

// Exemplo de uso
let listaOriginal = [1; 2; 3; 4; 5]
let listaInvertida = inverteLista listaOriginal

printfn "Lista Original: %A" listaOriginal
printfn "Lista Invertida: %A" listaInvertida
