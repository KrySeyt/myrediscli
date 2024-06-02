module CLIPresenter

open Domain

let show (value:Value) :unit =
    match value with
    | StringValue(value) -> printfn "%s" value
    | IntValue(value) -> printfn "%i" value
    | None -> printfn "(nil)"
