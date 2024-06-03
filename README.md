# MyRedisCLI
CLI interface for [myredis](https://github.com/KrySeyt/myredis). Compatible with origin Redis

# Setup
Later =)

# Supported commands

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


