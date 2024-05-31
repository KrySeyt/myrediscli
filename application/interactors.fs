module Interactors

open System
open Domain


let ping
    (redisPing: unit->byte array)
    ()
    =
        redisPing()
   
let get
    redisGet
    (key: Key)
    :string
    =
        redisGet key

let set
    redisSet
    (key: Key)
    (value: Value)
    (alive: Lifetime option)
    :unit
    =
        redisSet key value alive
    
let waitReplicas
    redisWait
    (replicasCount: int)
    (timeout: Timeout)
    =
        ()
