module TCPRedis

open System
open System.Net.Sockets
open System.Text
open Domain


let ping
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    ()
    :string
    =
        sender connection <| Commands.ping()
        receiver connection |> Encoding.UTF8.GetString
    
let get
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (key:Key)
    :string
    =
        sender connection <| Commands.get key
        receiver connection |> Encoding.UTF8.GetString

let set
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (key:Key)
    (value:string)
    (alive:Lifetime option)
    :string
    =
        (connection, Commands.set key value alive) ||> sender
        receiver connection |> Encoding.UTF8.GetString
        
let waitReplicas
    (connection: TcpClient)
    (sender: TcpClient -> byte array -> unit)
    (receiver: TcpClient -> byte array)
    (replicasCount:int)
    (timeout:Timeout)
    :string
    =
        (connection, Commands.waitReplicas replicasCount timeout) ||> sender |> ignore
        receiver connection |> Encoding.UTF8.GetString
