module ResponseParser

open System
open Domain
open Decoders


let parseConfigParams (str:string) =
    let strParts = str.Split("\r\n")[1..]
    strParts
    |> Array.filter (fun (x:string) -> not <| x.StartsWith("$"))
    |> Array.filter (fun (x:string) -> x.Length > 0)
    |> Array.chunkBySize 2
    |> Array.map (fun xs -> (xs.[0], xs.[1]))
    |> Map.ofArray


let parse (response: byte array) :Value =
    match fromUtf8 response with
    | str when str.StartsWith("+") -> str[1..].TrimEnd[|'\r'; '\n'|] |> StringValue
    | str when str.StartsWith("$") -> str.Split("\r\n")[1] |> BulkStringValue
    | str when str.StartsWith("*") -> parseConfigParams str |> ConfigParams
    | integer when integer.StartsWith(":") -> integer[1..].TrimEnd[|'\r'; '\n'|] |> int |> IntValue
    | "$-1\r\n" -> None
    | any -> any.TrimEnd[|'\r'; '\n'|] |> StringValue
