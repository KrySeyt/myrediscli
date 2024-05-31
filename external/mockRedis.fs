namespace MyRedisCLI.external

open MyRedisCLI.domain

module MockRedis = 
    let ping () = "PONG"
        
    let get
        (key:Key)
        =
        
        sprintf "%s" key
    
    let set
        (key:Key)
        (value:Value)
        (alive:Lifetime)
        =
        
        ()
