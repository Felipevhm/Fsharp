// solução para o problema das igrejas com fold


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


let personChurches (churchesData:(Church * ChurchStatus) list)  =
    churchesData
    |> List.map fst
    |> List.map (fun {Name = church; CommunityMembers = members} -> (church, List.ofArray members))
    |> List.collect (fun (church, members) ->
             List.map (fun personName -> (church, personName)) members)
    |> List.fold (fun (acc: Map<string, string list>) ((igreja, pessoa)) -> 
            Map.change pessoa (function
                | Some currentList -> Some (igreja :: currentList)
                | None -> Some [igreja])
                acc
                )
        (Map([]))
        // |> Map.iter (fun name churches ->
        //         printfn "%s" name
        //         List.iter (fun church -> printfn "\t%s" church) churches)

printfn "%A" (personChurches churchesData)

