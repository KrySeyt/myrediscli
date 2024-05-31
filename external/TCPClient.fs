module TCPClient

open System
open System.Net.Sockets

let send
    (host:string)
    (port:int)
    (client:TcpClient)
    (bytes:array<byte>)
    =
        // (host, port) |> client.Connect
        client.Connect(host, port)
        printfn $"{client.Connected}"
        (bytes, 0, bytes.Length) |> client.GetStream().Write
        
        
let recv
    (client: TcpClient)
    =
        let bytes = Span(Array.zeroCreate<byte> 4096)
        client.GetStream().Read(bytes) |> ignore
        client.Close()
        bytes.ToArray()
        
