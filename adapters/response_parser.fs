module ResponseParser

open Domain
open Decoders

let parse (response: byte array) :Value =
    match fromUtf8 response with
    | str when str.StartsWith("+") -> str[1..].TrimEnd[|'\r'; '\n'|] |> StringValue
    | integer when integer.StartsWith(":") -> integer[1..].TrimEnd[|'\r'; '\n'|] |> int |> IntValue
    | "$-1\r\n" -> None
    | any -> any.TrimEnd[|'\r'; '\n'|] |> StringValue
