module Encoders

open System.Text

 
let utf8 (str:string) =
    Encoding.UTF8.GetBytes str
