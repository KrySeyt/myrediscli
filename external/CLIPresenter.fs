module CLIPresenter

open Domain


let showConfigParams (configParams:Map<string, string>) =
    let lineNumber = ref 1
    for record in configParams do
        printfn "%i) \"%s\"" lineNumber.Value record.Key
        lineNumber.Value <- lineNumber.Value + 1
        printfn "%i) \"%s\"" lineNumber.Value record.Value
        lineNumber.Value <- lineNumber.Value + 1


let show (value:Value) :unit =
    match value with
    | StringValue(value) -> printfn "%s" value
    | BulkStringValue(value) -> printfn "\"%s\"" value
    | IntValue(value) -> printfn "%i" value
    | ConfigParams(value) -> showConfigParams value
    | None -> printfn "(nil)"
