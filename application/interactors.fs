module Interactors

open System
open Domain


let ping
    (redisPing: unit->byte array)
    ()
    =
        redisPing() |> ignore
   
let get
    redisGet
    (key: Key)
    :unit
    =
        redisGet key |> ignore

let set
    redisSet
    (key: Key)
    (value: Value)
    (alive: Lifetime option)
    :unit
    =
        redisSet key value alive |> ignore
    
let waitReplicas
    redisWait
    (replicasCount: int)
    (timeout: Timeout)
    =
        ()
