// exemplo de fold que produz duas listas na saída, uma para cada resto possível na divisão por dois.

let oneList = [1 .. 10] 

let oneFcn (oneList) =
    oneList
    |> List.fold (
        fun (acc: Map<int, int list>) cur ->
            let key = cur % 2
            // printfn "\ncur is: %A" (cur)
            // printfn "acc is: %A" (acc)

            if Map.containsKey key acc then
                let currentList = acc.[key]
                Map.add key (cur :: currentList) acc
                // printfn "key é: %A" (key
                // printfn "currentList é: %A" (currentList)
            else
                Map.add key [cur] acc
                // printfn "else | key:%A cur:%A acc:%A\n" key cur acc
                
                           
        )
        (Map [])

printfn "%A" (oneFcn oneList)




// cur is: 1
// acc is: map []
// else | key:1 cur:1 acc:map []


// cur is: 2
// acc is: map [(1, [1])]
// else | key:0 cur:2 acc:map [(1, [1])]


// cur is: 3
// acc is: map [(0, [2]); (1, [1])]
// key é: 1
// currentList é: [1]

// cur is: 4
// acc is: map [(0, [2]); (1, [3; 1])]
// key é: 0
// currentList é: [2]

// cur is: 5
// acc is: map [(0, [4; 2]); (1, [3; 1])]
// key é: 1
// currentList é: [3; 1]

// cur is: 6
// acc is: map [(0, [4; 2]); (1, [5; 3; 1])]
// key é: 0
// currentList é: [4; 2]

// cur is: 7
// acc is: map [(0, [6; 4; 2]); (1, [5; 3; 1])]
// key é: 1
// currentList é: [5; 3; 1]

// cur is: 8
// acc is: map [(0, [6; 4; 2]); (1, [7; 5; 3; 1
// key é: 0
// currentList é: [6; 4; 2]

// cur is: 9
// acc is: map [(0, [8; 6; 4; 2]); (1, [7; 5; 3
// key é: 1
// currentList é: [7; 5; 3; 1]

// cur is: 10
// acc is: map [(0, [8; 6; 4; 2]); (1, [9; 7; 5
// key é: 0
// currentList é: [8; 6; 4; 2]
// map [(0, [10; 8; 6; 4; 2]); (1, [9; 7; 5; 3;
