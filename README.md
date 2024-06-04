# MyRedisCLI
CLI interface for [myredis](https://github.com/KrySeyt/myredis). Compatible with original Redis

# Setup
- Clone repo
```shell
git clone git@github.com:KrySeyt/myrediscli.git && cd myrediscli
```

- Build app
```shell
dotnet build --configuration Release
```

- Start app
```shell
./main/bin/Release/net8.0/main ping
```

# Supported commands
Flags:
- `-p` `--port` - port of Redis server. Default `6379`
- `-h` `--host` - host of Redis server. Default `localhost`

```shell
./main get foo
```

```shell
./main set foo bar
```

```shell
./main set foo bar px 1000
```

```shell
./main wait 3 1000
```

```shell
./main ping
```

```shell

./main echo "Hello, World\!"

```

```shell
./main wait 3 1000
```

```shell

./main config get <param-name> // e.g. port or dbfilename

```

# Supported data types
- String
- BulkString (server responses only)
- Array of BulkStrings (server responses only)
- Integer (server responses only)
- Null (server responses only)


