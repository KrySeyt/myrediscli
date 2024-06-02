module Interactors

open Domain


let ping
    (redisPing: unit -> Value)
    (presenter: Value -> unit)
    ()
    =
        redisPing() |> presenter
   
let get
    (redisGet: Key -> Value)
    (presenter: Value -> unit)
    (key: Key)
    :unit
    =
        redisGet key |> presenter

let set
    (redisSet: Key -> string -> Lifetime option -> Value)
    (presenter: Value -> unit)
    (key: Key)
    (value: string)
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
