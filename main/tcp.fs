module MockedMain

open System.Net.Sockets



[<EntryPoint>]
let main(args) =
    use conn = new TcpClient()
    let sender = TCPClient.send "localhost" 6379
    let receiver = TCPClient.recv

    
    CommandProcessor.processCommand
    <| (Interactors.ping
        <| (TCPRedis.ping
            <| conn
            <| sender
            <| receiver))

    <| (Interactors.get
        <| (TCPRedis.get
            <| conn
            <| sender
            <| receiver))
    
    <| (Interactors.set
        <| (TCPRedis.set
            <| conn
            <| sender
            <| receiver))
    
    <| (Interactors.waitReplicas
        <| (TCPRedis.waitReplicas
            <| conn
            <| sender
            <| receiver))

    <| args

    0
