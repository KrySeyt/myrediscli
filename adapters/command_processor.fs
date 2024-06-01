module CommandProcessor

let processCommand
    (pingInteractor: unit->unit)
    (getInteractor)
    (cmd: string array)
    :unit
    =
        match cmd with
        | [|"get"; key|] -> getInteractor key
        | [|"ping"|] -> pingInteractor ()
        | _ -> printfn "Unknown command"
