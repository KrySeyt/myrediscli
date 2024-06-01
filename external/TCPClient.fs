module TCPClient

open System
open System.Net.Sockets
open System.Text

let send
    (host:string)
    (port:int)
    (client:TcpClient)
    (bytes:array<byte>)
    =
        (host, port) |> client.Connect
        (bytes, 0, bytes.Length) |> client.GetStream().Write
        printfn "%s" (Encoding.UTF8.GetString bytes)
        
        
let recv (client: TcpClient) =
        let bytes = Span(Array.zeroCreate<byte> 4096)
        client.GetStream().Read(bytes) |> ignore
        client.Close()
        bytes.ToArray()
        
