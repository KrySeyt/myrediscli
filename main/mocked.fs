namespace MyRedisCLI.main

open MyRedisCLI.external
open MyRedisCLI.application

module MockedMain =
    let value = Interactors.set MockRedis.set "Key" "value" 1000
    
