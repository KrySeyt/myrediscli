module TCPClient

open System
open System.Net.Sockets
open Decoders

let send
    (host:string)
    (port:int)
    (client:TcpClient)
    (bytes: byte array)
    =
        (host, port) |> client.Connect
        (bytes, 0, bytes.Length) |> client.GetStream().Write
        printf "Sent: \n%s\n" (fromUtf8 bytes)  // Refactor decoding
        
        
let recv (client: TcpClient) =
        let bytes = Span(Array.zeroCreate<byte> 4096)
        client.GetStream().Read(bytes) |> ignore
        client.Close()
        bytes.ToArray()
        
