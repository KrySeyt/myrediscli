module TCPClient

open System
open System.Text
open System.Net.Sockets

let send
    (host:string)
    (port:int)
    (client:TcpClient)
    (bytes: byte array)
    =
        (host, port) |> client.Connect
        (bytes, 0, bytes.Length) |> client.GetStream().Write
        
        
let recv (client: TcpClient) =
        let bytes = Span(Array.zeroCreate<byte> 4096)
        let bytesCount = client.GetStream().Read(bytes)
        bytes.ToArray()[..bytesCount - 1]
