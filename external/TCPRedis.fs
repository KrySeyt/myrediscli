module TCPRedis

open System.Net.Sockets
open Domain


let ping
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    ()
    :Value
    =
        sender connection <| Commands.ping()
        receiver connection |> ResponseParser.parse

let echo
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (data:Value)
    :Value
    =
        sender connection <| Commands.echo data
        receiver connection |> ResponseParser.parse
    

let get
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (key:Key)
    :Value
    =
        sender connection <| Commands.get key
        receiver connection |> ResponseParser.parse

let set
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (key:Key)
    (value:Value)
    (alive:Lifetime option)
    :Value
    =
        (connection, Commands.set key value alive) ||> sender
        receiver connection |> ResponseParser.parse
        
let waitReplicas
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (replicasCount:int)
    (timeout:Timeout)
    :Value
    =
        (connection, Commands.waitReplicas replicasCount timeout) ||> sender |> ignore
        receiver connection |> ResponseParser.parse

let getConfig
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (key:Key)
    :Value
    =
        (connection, Commands.configGet key) ||> sender
        receiver connection |> ResponseParser.parse
