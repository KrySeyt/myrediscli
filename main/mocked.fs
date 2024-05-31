module MockedMain


open System
open System.Net.Sockets
open System.Text

let main =
    let conn = new TcpClient()
    
    let sender = TCPClient.send "localhost" 6379
    let receiver = TCPClient.recv
    
    let a = TCPRedis.ping conn sender receiver
    let interactor = Interactors.ping a
    
    interactor()

main |> ignore
