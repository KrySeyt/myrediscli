module CommandProcessor

open System


let processCommand
    (pingInteractor: unit -> unit)
    (echoInteractor: Domain.Value -> unit)
    (getInteractor: Domain.Key -> unit)
    (setInteractor: Domain.Key -> Domain.Value -> Domain.Lifetime option -> unit)
    (waitInteractor: int -> Domain.Timeout -> unit)
    (getConfigInteractor: Domain.Key -> unit)
    (cmd: string array)
    :unit
    =
        match
            Array.map (fun (x: string) -> x.ToLower()) cmd
        with
        | [|"ping"|] -> pingInteractor ()
        | [|"echo"; value|] -> echoInteractor (Domain.StringValue value)
        | [|"get"; key|] -> getInteractor key
        | [|"config"; "get"; key|] -> getConfigInteractor key
        | [|"set"; key; value; |] -> setInteractor key (Domain.StringValue value) None
        | [|"set"; key; value; "px"; lifetime |] when lifetime |> String.forall Char.IsDigit ->
            setInteractor key (Domain.StringValue value) <| (Some (Domain.Milliseconds (int lifetime)))
            
        | [|"wait"; replicasCount; timeout;|] when
             replicasCount |> String.forall Char.IsDigit
             &&
             timeout |> String.forall Char.IsDigit
             -> waitInteractor (int replicasCount) (Domain.Milliseconds (int timeout))

        | _ -> printfn "Unknown command"
