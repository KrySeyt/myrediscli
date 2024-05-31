namespace MyRedisCLI.application

module Interactors = 
    let ping
        (redisPing: unit->string) =

       redisPing()
