module Interactors

open System
open Domain


let ping
    (redisPing: unit -> byte array)
    ()
    =
        redisPing() |> ignore
   
let get
    (redisGet: Key -> byte array)
    (key: Key)
    :unit
    =
        redisGet key |> ignore

let set
    (redisSet: Key -> Value -> Lifetime option -> byte array)
    (key: Key)
    (value: Value)
    (alive: Lifetime option)
    :unit
    =
        redisSet key value alive |> ignore
    
let waitReplicas
    (redisWait: int -> Timeout -> byte array)
    (replicasCount: int)
    (timeout: Timeout)
    =
        redisWait replicasCount timeout |> ignore
