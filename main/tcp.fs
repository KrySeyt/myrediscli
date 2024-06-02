module MockedMain

open System.Net.Sockets



[<EntryPoint>]
let main(args) =
    use conn = new TcpClient()
    let sender = TCPClient.send "localhost" 6379
    let receiver = TCPClient.recv
    let presenter = CLIPresenter.show
    
    CommandProcessor.processCommand
    <| (Interactors.ping
        <| (TCPRedis.ping
            <| conn
            <| sender
            <| receiver)
        <| presenter)

    <| (Interactors.echo
        <| (TCPRedis.echo
            <| conn
            <| sender
            <| receiver)
        <| presenter)
    
    <| (Interactors.get
        <| (TCPRedis.get
            <| conn
            <| sender
            <| receiver)
        <| presenter)
    
    <| (Interactors.set
        <| (TCPRedis.set
            <| conn
            <| sender
            <| receiver)
        <| presenter)
    
    <| (Interactors.waitReplicas
        <| (TCPRedis.waitReplicas
            <| conn
            <| sender
            <| receiver)
        <| presenter)
    
    <| args

    0
