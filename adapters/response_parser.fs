module ResponseParser

open Domain
open Decoders

let parse (response: byte array) :Value =
    match fromUtf8 response with
    | str when str.StartsWith("+") -> str[1..].Trim("\r\n".ToCharArray())
    | any -> any
