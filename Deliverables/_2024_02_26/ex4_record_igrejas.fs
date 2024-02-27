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

let returnMembers = (peopleSearch churchesData)

printfn "%A\n" returnMembers


// ----
//1)
let isMember (name: string) (churchesData:(Church * ChurchStatus) list): bool list  =
    churchesData
    |> List.map (fun (church, status) -> Array.contains name church.CommunityMembers)

//2)
let getChurchNames (churchesData:(Church * ChurchStatus) list): string list  =
    churchesData
    |> List.map (fun (church, status) -> church.Name)


//3)
let filterChurchNames (churchNames: string list) (checkMember: bool list): string list =
    List.zip churchNames checkMember
    |> List.filter snd
    |> List.map fst


let personChurches (name: string) (churchesData:(Church * ChurchStatus) list) = 

    let checkMember = (isMember name churchesData)
    let churchNames = (getChurchNames churchesData)
    let filteredChurchNames = filterChurchNames churchNames checkMember
    filteredChurchNames
   

for name in returnMembers do
  printfn "%s:\n" name
  let testLastFunction = personChurches name churchesData

  printfn "%A\n" testLastFunction