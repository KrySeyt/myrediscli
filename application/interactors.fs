namespace MyRedisCLI.application

module Interactors = 
    let ping
        (redisPing: unit->string)
        =

       redisPing()
       
    let get
        redisGet
        (key: string)
        :string
        =
        
        redisGet key
    
    let set
        redisSet
        (key: string)
        (value: string)
        (alive: int)
        :unit
        =
        
        redisSet key value alive
