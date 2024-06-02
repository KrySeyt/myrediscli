module ResponseParser

open Domain
open Decoders

let parse (response: byte array) :Value =
    match fromUtf8 response with
    | str when str.StartsWith("+") -> str[1..].ReplaceLineEndings("") |> StringValue
    | integer when integer.StartsWith(":") -> integer[1..].ReplaceLineEndings("") |> int |> IntValue
    | any -> any.ReplaceLineEndings("") |> StringValue
