module Domain

type Key = string
type Value =
    | StringValue of string
    | IntValue of int

type Milliseconds = Milliseconds of int

type Lifetime = Milliseconds
type Timeout = Milliseconds
