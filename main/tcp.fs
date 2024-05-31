open MyRedisCLI.external
open MyRedisCLI.application

module main =
    let value = Interactors.get MockRedis.get "Test"
    printfn "%s" value