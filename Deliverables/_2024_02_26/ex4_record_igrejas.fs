
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

let peopleSearch (churchesData:(Church * ChurchStatus) list): string list  =
    churchesData
    |> List.collect (fun (church, status) -> Array.toList church.CommunityMembers)
    |> Set.ofList
    |> Set.toList

let allPeople = (peopleSearch churchesData)

let personChurches (person: string) (churchesData:(Church * ChurchStatus) list)  =
    List.map (fun (church, _ ) -> (church.Name, (Array.toList church.CommunityMembers))) churchesData
    |> List.groupBy (fun (_, members) -> members |> List.contains person)
    |> List.filter (fun (trueTuple, _) -> trueTuple)
    |> List.map snd
    |> List.collect (List.map fst) 

// for person in returnMembers do
for someone in allPeople do
  let memberOf = (personChurches  someone churchesData)
  let personAndChurches =  (someone,memberOf )
  printfn "%A\n" personAndChurches



