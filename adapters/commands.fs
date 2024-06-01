module Commands

open Encoders
open Domain

let ping () = utf8 "*1\r\n$4\r\nPING\r\n"

let get (key:Key) = utf8 $"*2\r\n$3\r\nGET\r\n${key.Length}\r\n{key}\r\n"

let set (key:Key) (value:Value) (lifetime:Lifetime option) =
    match lifetime with
    | Some time ->
        utf8 $"*5\r\n
        $3\r\nSET\r\n
        ${key.Length}\r\n{key}\r\n
        ${value.Length}\r\n{value}\r\n
        $2\r\nPX\r\n
        ${lifetime.ToString().Length}\r\n{time}"
    
    | None ->
        utf8 $"*3\r\n
        $3\r\nSET\r\n
        ${key.Length}\r\n{key}\r\n
        ${value.Length}\r\n{value}\r\n"

let waitReplicas (replicasCount:int) (timeout:Timeout) =
    utf8 $"*3\r\n
    $4\r\nWAIT\r\n
    ${replicasCount.ToString().Length}\r\n{replicasCount}\r\n
    ${timeout.ToString().Length}\r\n{timeout}\r\n"
