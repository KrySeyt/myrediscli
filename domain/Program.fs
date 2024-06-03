module Domain

type Key = string

type Value =
    | StringValue of string
    | BulkStringValue of string
    | IntValue of int
    | ConfigParams of Map<string, string>
    | None

type Milliseconds = Milliseconds of int

type Lifetime = Milliseconds
type Timeout = Milliseconds
