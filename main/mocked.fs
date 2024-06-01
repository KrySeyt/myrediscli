module MockedMain

open System.Net.Sockets



[<EntryPoint>]
let main(args) =
    CommandProcessor.processCommand
    <| (Interactors.ping
        <| (TCPRedis.ping
            <| new TcpClient()
            <| (TCPClient.send
                <|| ("localhost", 6379))
            
            <| TCPClient.recv))

    <| (Interactors.get
        <| (TCPRedis.get
            <| new TcpClient()
            <| (TCPClient.send
                <|| ("localhost", 6379))
            
            <| TCPClient.recv))

    <| args

    0
