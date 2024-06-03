module Commands

open Encoders


let sanitazeValue (value: Domain.Value) : string=
    match value with
    | Domain.StringValue(value) -> value
    | _ -> invalidArg "value" "is not StringValue"


let ping () = utf8 "*1\r\n$4\r\nPING\r\n"


let echo (value: Domain.Value) =
    let value = sanitazeValue value
    utf8 $"*2\r\n$4\r\nECHO\r\n${value.Length}\r\n{value}\r\n"


let get (key:Domain.Key) = utf8 $"*2\r\n$3\r\nGET\r\n${key.Length}\r\n{key}\r\n"

let configGet (key:Domain.Key) = utf8 $"*3\r\n$6\r\nCONFIG\r\n$3\r\nGET\r\n${key.Length}\r\n{key}\r\n"


let set (key:Domain.Key) (value:Domain.Value) lifetime =
    let value = sanitazeValue value
    
    match lifetime with
    | Some time ->
        utf8 (
            "*5\r\n" +
            "$3\r\nSET\r\n" +
            $"${key.Length}\r\n{key}\r\n" +
            $"${value.Length}\r\n{value}\r\n" +
            "$2\r\nPX\r\n" +
            $"${((string time).Split()[1]).Length}\r\n{((string time).Split()[1])}\r\n"
        )
    
    | None ->
        utf8 (
            "*3\r\n" +
            "$3\r\nSET\r\n" +
            $"${key.Length}\r\n{key}\r\n" +
            $"${value.Length}\r\n{value}\r\n" 
        )


let waitReplicas (replicasCount:int) (timeout:Domain.Timeout) =
    utf8 (
        "*3\r\n" +
        "$4\r\nWAIT\r\n" +
        $"${replicasCount.ToString().Length}\r\n{replicasCount}\r\n" +
        $"${((string timeout).Split()[1]).Length}\r\n{((string timeout).Split()[1])}\r\n"
    )
