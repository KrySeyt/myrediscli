namespace MyRedisCLI.main

open MyRedisCLI.external
open MyRedisCLI.application

module MockedMain =
    let value = Interactors.get MockRedis.get "Test"
    printfn "%s" value
