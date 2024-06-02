module Interactors

open Domain


let ping
    (redisPing: unit -> Value)
    (presenter: Value -> unit)
    ()
    =
        redisPing() |> presenter
        
let echo
    (redisEcho: Value -> Value)
    (presenter: Value -> unit)
    (data: Value)
    :unit
    =
        redisEcho data |> presenter
   
let get
    (redisGet: Key -> Value)
    (presenter: Value -> unit)
    (key: Key)
    :unit
    =
        redisGet key |> presenter

let set
    (redisSet: Key -> Value -> Lifetime option -> Value)
    (presenter: Value -> unit)
    (key: Key)
    (value: Value)
    (alive: Lifetime option)
    :unit
    =
        redisSet key value alive |> presenter
    
let waitReplicas
    (redisWait: int -> Timeout -> Value)
    (presenter: Value -> unit)
    (replicasCount: int)
    (timeout: Timeout)
    =
        redisWait replicasCount timeout |> presenter
