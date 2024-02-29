
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
    |> List.fold (fun acc {Name = igreja; CommunityMembers = members} -> (igreja, (List.ofArray members)) :: acc) []
    |> List.map (fun (igreja,nomes) -> [ nomes ; [igreja] ] )
    
    |> List.collect (fun item -> 
        let first = List.head item
        let second = List.head (List.tail item)
        [for x in first do yield [x,second]])

printfn "%A" (personChurches churchesData)