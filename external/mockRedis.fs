namespace MyRedisCLI.external

module MockRedis = 
    let ping () = "PONG"
        
    let get
        (key:string)
        =
        
        sprintf "%s" key
    
    let set
        (key:string)
        (value:string)
        (alive:int)
        =
        
        ()
