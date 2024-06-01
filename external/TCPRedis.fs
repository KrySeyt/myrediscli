module TCPRedis

open System
open System.Net.Sockets
open Domain


let ping
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    ()
    =
        let a = Commands.ping()
        sender connection a
        receiver connection
    
let get
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (key:Key)
    =
        (connection, Commands.get key) ||> sender
        receiver connection

let set
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (key:Key)
    (value:Value)
    (alive:Lifetime option)
    =
        (connection, Commands.set key value alive) ||> sender
        receiver connection
        
let waitReplicas
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (replicasCount:int)
    (timeout:Timeout)
    =
        (connection, Commands.waitReplicas replicasCount timeout) ||> sender |> ignore
        receiver connection
