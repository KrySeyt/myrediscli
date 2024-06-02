module Decoders

open System.Text


let fromUtf8 (bytes: byte array) :string =
    Encoding.UTF8.GetString bytes
