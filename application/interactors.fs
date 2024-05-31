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
