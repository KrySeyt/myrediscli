open MyRedisCLI.external
open MyRedisCLI.application

module main =
    let value = Interactors.ping Redis.ping
    printfn "%s" value