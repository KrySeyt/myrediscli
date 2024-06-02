module CLIPresenter

open Domain

let show (value:Value) :unit =
    printf $"Response: {value}"
