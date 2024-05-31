namespace MyRedisCLI.application

open MyRedisCLI.domain

module Interactors = 
    let ping
        (redisPing: unit->string)
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
        (alive: Lifetime)
        :unit
        =
        
        redisSet key value alive
