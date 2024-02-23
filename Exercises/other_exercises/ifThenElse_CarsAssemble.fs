module CarsAssemble

let successRate (speed: int): float =
    let output = 
            if speed = 0 then 
                    0.0
            elif (speed >= 1) && (speed <= 4) then
                    1.0
            elif (speed >= 5) && (speed <= 8) then
                    0.9
            elif speed = 9 then
                    0.8
            else 
                0.77
    output      

let productionRatePerHour (speed: int): float =
    //failwith "Please implement the 'productionRatePerHour' function"
    let floatSpeed = float speed
    let output = floatSpeed*221.0*(successRate speed)
    output

let workingItemsPerMinute (speed: int): int =
    let floatRatePerHour = floor ((productionRatePerHour speed)/60.0)
    int floatRatePerHour

let w = workingItemsPerMinute 6
printfn "%i" w