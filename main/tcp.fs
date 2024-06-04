module MockedMain

open CommandLine
open System.Net.Sockets

type options = {
  [<Option('p', "port", Default = 6379, HelpText = "Redis server port")>] port : int;
  [<Option('h', "host", Default = "localhost", HelpText = "Redis server host")>] host : string;
}


[<EntryPoint>]
let main(args) =
    let parsedArgs = Parser.Default.ParseArguments<options>(args).Value
    
    use conn = new TcpClient()
    let sender = TCPClient.send parsedArgs.host parsedArgs.port 
    let receiver = TCPClient.recv
    let presenter = CLIPresenter.show
    
    let exclude = ref Set.empty
    exclude.Value <- Set.add "--port" exclude.Value
    exclude.Value <- Set.add "-p" exclude.Value
    exclude.Value <- Set.add "--host" exclude.Value
    exclude.Value <- Set.add "-h" exclude.Value
    exclude.Value <- Set.add (string parsedArgs.port) exclude.Value
    exclude.Value <- Set.add parsedArgs.host exclude.Value
    
    let command = args |> Array.filter (fun x ->
        let contains = exclude.Value |> Set.contains x
        if contains then
            exclude.Value <- Set.remove x exclude.Value
        not contains
        )

    
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
    
    <| (Interactors.getConfig
        <| (TCPRedis.getConfig
            <| conn
            <| sender
            <| receiver)
        <| presenter)
    
    <| command
    
    0
