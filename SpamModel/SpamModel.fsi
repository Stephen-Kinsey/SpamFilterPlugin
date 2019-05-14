namespace SpamModel
module SpamModel =
    open Microsoft.ML
    open Microsoft.ML.Data

    [<CLIMutable>]
    type EmailData = {
        [<LoadColumn(0)>]
        HamOrSpam : bool
        [<LoadColumn(1)>]
        Subject : string
        [<LoadColumn(2)>]
        BodyText : string
    }

    // Type for data returned by the predictor
    [<CLIMutable>]
    type EmailResult = {
        PredictedLabel : bool
        Probability : double
    }

    val isSpam : PredictionEngine<EmailData, EmailResult> -> string -> string -> bool
    val loadModelAndGetPredictor : string -> PredictionEngine<EmailData, EmailResult>