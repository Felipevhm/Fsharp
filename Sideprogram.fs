// d - crie um exemplo onde você representa dados sobre algumas igrejas 
// de Florianópolis utilizando os tipos algébricos do F#. 

// Utilize tanto records como discriminated unions. 

// Escreva uma função que processa uma lista que contém instâncias dos 
// tipos algébricos que você definiu.

// Definição dos tipos algébricos

// Record para representar os detalhes de uma igreja
type Church =
    { Name : string
      Denomination : string
      Address : string
      Capacity : int 
      CommunityMembers : string []
      }

// Discriminated union para representar o status de uma igreja
type ChurchStatus =
    | Open
    | Closed

type Person =
    { Name : string 
      MemberOf : string []
      }

// Exemplo de dados sobre algumas igrejas de Florianópolis
let churchesData =
    [ { Name = "Catedral Metropolitana de Florianópolis"
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

      { Name = "Igreja das Irmãs da Divina Providência"
        Denomination = "Católica"
        Address = "Av. Me. Benvenuta, Trindade"
        Capacity = 500 
        CommunityMembers = [|"Maria";"Juarez"|]
        }
        ,
      Open;

      { Name = "Igreja Presbiteriana Independente"
        Denomination = "Presbiteriana"
        Address = "Rua Esteves Júnior, Centro"
        Capacity = 300 
        CommunityMembers = [||]
        }
        ,
      Open;

      { Name = "Igreja Mundial do Poder de Deus"
        Denomination = "Neopentecostal"
        Address = "Rua Almirante Lamego, Estreito"
        Capacity = 200 
        CommunityMembers = [||]
        },
        
      Closed
    ]

// Imprimir as informações usando %A

let peopleSearch (churchesData:(Church * ChurchStatus) list): string list  =
    churchesData
    |> List.collect (fun (church, status) -> Array.toList church.CommunityMembers)
    |> Set.ofList
    |> Set.toList

let returnMembers = (peopleSearch churchesData)

printfn "%A\n" returnMembers

// let findChurchesForAllMembers (members: string list ) (churchesData:(Church * ChurchStatus) list): Person list =
//     members
//     |> List.map (fun member -> 
//         { Name = member; 
//           GoesTo = churchesData
//                     |> List.filter (fun (church, status) -> Array.contains member church.CommunityMembers)
//                     |> List.map (fun (church, _) -> church.Name)
//         })

let findChurches (member:string) (churchesData:(Church * ChurchStatus) list) =
    let mutable result = []
    for (church, status) in churchesData do
        if Array.contains member church.CommunityMembers then
            result :: church.Name 
    result

// let findChurchesForAllMembers members churchesData =
//     let mutable result = []
//     for member in members do
//         let churches = findChurches member churchesData
//         result <- { Name = member; GoesTo = churches } :: result
//     result


let peopleAndChurches = findChurchesForAllMembers returnMembers churchesData

printfn "%A\n" peopleAndChurches
