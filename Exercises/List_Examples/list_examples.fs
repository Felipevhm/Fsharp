// with Strings


let fruits = ["banana"; "morango"; "uva"; "coco"; "tomate"]
let basket = [["banana";"morango"];["uva";"coco"];["tomate";"kiwi"]]

//1) List.map
let out_map_s = List.map (fun x-> x + "MAP") fruits

printfn "\n1B) List.map fruits:\n %A\n" out_map_s

//2) List.collect
let out_col_s = List.collect (id) basket

printfn "2B) List.collect basket:\n %A\n" out_col_s

//3) List.fold
let out_fold_s = List.fold (fun acc x->acc + x+ "&&") "" fruits

printfn "3B) List.fold fruits:\n %A\n"  out_fold_s

//4) List.groupBy
let out_groupBy_s = List.groupBy (fun x->x+"__") fruits

printfn "4B) List.groupBy fruits:\n %A\n" out_groupBy_s






// ----------------------------------------------------------------

//
//With Numbers

let numbers = [1; 2; 3; 4; 5]
let nested = [[1;2];[3;4];[5;6]]

//1) List.map
let out_map = List.map (fun x->x*x) numbers

printfn "\n1A) List.map numbers:\n %A\n" out_map

//2) List.collect
let out_col = List.collect (id) nested

printfn "2A) List.collect nested:\n %A\n" out_col

//3) List.fold
let out_fold = List.fold (fun acc x->acc + x) 0 numbers

printfn "3A) List.fold numbers:\n %A\n"  out_fold

//3) List.groupBy
let out_groupBy = List.groupBy (fun x->x%2) numbers

printfn "4A) List.groupBy numbers:\n %A\n" out_groupBy


