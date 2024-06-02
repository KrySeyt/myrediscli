module Interactors

open System
open Domain


let ping
    (redisPing: unit -> Value)
    ()
    =
        redisPing() |> ignore
   
let get
    (redisGet: Key -> Value)
    (key: Key)
    :unit
    =
        redisGet key |> ignore

let set
    (redisSet: Key -> string -> Lifetime option -> Value)
    (key: Key)
    (value: Value)
    (alive: Lifetime option)
    :unit
    =
        redisSet key value alive |> ignore
    
let waitReplicas
    (redisWait: int -> Timeout -> Value)
    (replicasCount: int)
    (timeout: Timeout)
    =
        redisWait replicasCount timeout |> ignore
