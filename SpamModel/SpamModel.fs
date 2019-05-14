namespace SpamModel
module spamModel =
    open System.IO
    open Microsoft.ML
    open Microsoft.ML.Data

    // Please note, this module does not use the "Result" type as it interfaces with another module.
    // The interface was designed to be very simple and only uses strings and booleans.
    // This could be extended to use the Result type, which would make this more resilient to errors.

    // .NET likes things to be mutable. Don't blame me, blame the documentation.
    // This defines the context of the email data. Our email data is now type checked, how cool is that!
    // No data is loaded at this stage, but it is still required to load the trained model from a file.
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

    // Load model from text file
    let loadModelAndSchema modelLocation (mlContext:MLContext) =
        // todo check the filepath is sensible
        use fsRead = new FileStream(modelLocation, FileMode.Open, FileAccess.Read, FileShare.Read)
        let modelReloaded = mlContext.Model.Load(fsRead)
        fsRead.Dispose() |> ignore
        match modelReloaded with
            |model,_ -> model

    // Get predictor from model
    let getPredictor (mlContext:MLContext) model = 
        mlContext.Model.CreatePredictionEngine<EmailData, EmailResult>(model);

    // Load model and get back a predictor
    let loadModelAndGetPredictor modelLocation =

            // Set up the MLContext .NET stuff
            let mlContext = MLContext()
            // Get back a predictor
            (mlContext |> (modelLocation |> loadModelAndSchema)) |> (mlContext |> getPredictor)
    
    // Check if email is spam. Returns simple boolean
    // subject and bodyText should be free of quotation marks and other characters that could escape the string.
    let isSpam (predictor:PredictionEngine<EmailData, EmailResult>) subject bodyText = 
        let prediction = predictor.Predict({HamOrSpam = false; Subject = subject; BodyText = bodyText})
        // Debug data
        #if DEBUG
        subject |> printfn "DEBUG: Subject: %s"
        bodyText |> printfn "DEBUG: Body Text: %s"
        prediction.Probability |> printfn "DEBUG: Probability: %%%A -- WIP"
        #endif
        prediction.PredictedLabel = true