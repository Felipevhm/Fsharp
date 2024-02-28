
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
   
   // Output até aqui: 

   (*
      [[["Maria"; "Erica"]; ["Igreja da Trindade"]];
      [["Juarez"; "Erica"; "Daniel"]; ["Moteiro Santo Ivo"]];
      [["Daniel"; "Maria"]; ["Catedral Metropolitana de Florianópolis"]]]
   *)
   
   
   
    // |> List.map (fun  (f::[[s]])-> for x in f do ( [x;s]) )
    // |> List.collect(fun first  :: second ->)
    //  |> List.collect (fun )
                    



// let personChurches (churchesData:(Church * ChurchStatus) list)  =
//     churchesData
//     |> List.map fst
//     |> List.fold  (fun {Name = igreja; CommunityMembers = members} -> (Nome,(List.ofArray members)) )
     // |> List.collect (fun {Name = church; CommunityMembers = members} -> 
    //       (List.ofArray members) |> List.map (fun name -> (church, name)
    //       )
    //                 )

    // |> List.groupBy (fun (church, name) -> name)
    // |> List.iter (fun (name, churches) ->
    //               printfn "%s" name
    //               List.iter (fun (church, _) -> printfn "\t%s" church) churches)

printfn "%A" (personChurches churchesData)
