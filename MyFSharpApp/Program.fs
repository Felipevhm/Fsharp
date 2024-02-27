type Church =
    { Name : string
      Denomination : string
      Address : string
      Capacity : int 
      CommunityMembers : string []
      }

type ChurchStatus =
    | Open
    | Closed

let churchesData =
    [ 
      { Name = "Catedral Metropolitana de Florianópolis"
        Denomination = "Católica"
        Address = "Praça XV de Novembro, Centro"
        Capacity = 500 
        CommunityMembers = [|"Daniel";"Maria"|]
        }
        ,
      Open;

      { Name = "Moteiro Santo Ivo"
        Denomination = "Católica"
        Address = "R. Delminda Silveira, Agronômica"
        Capacity = 80 
        CommunityMembers = [|"Juarez";"Erica";"Daniel"|]
        }
        ,
      Open;

      { Name = "Igreja da Trindade"
        Denomination = "Católica"
        Address = "Pça. Santos Dumont, Trindade"
        Capacity = 600 
        CommunityMembers = [|"Maria";"Erica"|]
        }
        ,
      Open;

    ]

let peopleSearch (person: string) (churchesData:(Church * ChurchStatus) list)  =
    List.map (fun (church, _ ) -> (church.Name, (Array.toList church.CommunityMembers))) churchesData
    |> List.groupBy (fun (_, members) -> members |> List.contains person)
    
    // |> Set.ofList
    // |> Set.toList

let returnMembers = (peopleSearch  "Maria" churchesData)

let testFilter = returnMembers|> List.filter (fun (trueTuple, _) -> trueTuple)
let testMap = testFilter |> List.map snd

let listParser = List.collect (List.map fst) testMap

printfn "After List.groupBy:\n\n %A\n" returnMembers
printfn "After List.filter:\n\n%A\n" testFilter
printfn "After List.Map:\n\n%A\n" testMap
printfn "After Parsing:\n\n%A\n" listParser