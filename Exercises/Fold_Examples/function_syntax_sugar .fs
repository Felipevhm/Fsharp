let oneList = [1 .. 5] 

let oneFcn oneList =
    oneList
    |> List.fold 
        (fun (acc: Map<int, int list>) cur ->
            let key = cur % 2
            Map.change key 
                (   function
                            | Some currentList -> (Some (cur :: currentList))
                            | None -> Some [cur]
                 )
                acc) 
        (Map.empty)

printfn "\n%A" (oneFcn oneList)


(*
cur: 1
key: 1
elementsOfKey: None

cur: 2
key: 0
elementsOfKey: None

cur: 3
key: 1
elementsOfKey: Some [1]
currentlist: [1]
cur :: currentList: [3; 1]

cur: 4
key: 0
elementsOfKey: Some [2]
currentlist: [2]
cur :: currentList: [4; 2]

cur: 5
key: 1
elementsOfKey: Some [3; 1]
currentlist: [3; 1]
cur :: currentList: [5; 3; 1]

map [(0, [4; 2]); (1, [5; 3; 1])]
*)
