module CommandProcessor

open System


let processCommand
    (pingInteractor: unit->unit)
    (getInteractor)
    (setInteractor: Domain.Key -> Domain.Value -> Domain.Lifetime option -> unit)
    (cmd: string array)
    :unit
    =
        match
            Array.map (fun (x: string) -> x.ToLower()) cmd
        with
        | [|"ping"|] -> pingInteractor ()
        | [|"get"; key|] -> getInteractor key
        | [|"set"; key; value; |] -> setInteractor key value None
        | [|"set"; key; value; "px"; lifetime |] when lifetime |> String.forall Char.IsDigit ->
            setInteractor key value <| (Some (int lifetime))
            
        | _ -> printfn "Unknown command"
