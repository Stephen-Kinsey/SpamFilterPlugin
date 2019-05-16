namespace SpamModelTest
module SpamModelTest =
    open NUnit.Framework
    open Microsoft.ML
    open SpamModel.spamModel
    open FsCheck

    [<SetUp>]
    let mlContext = MLContext()
    let pathToModel = "../../../../OutlookPlugin/spamModel"
    let pathToMissingModel = "spamModel"
    let predictionEngine = pathToModel |> loadModelAndGetPredictor

    [<Test>]
    let ``LoadSchemaAndGetPredictor model exists`` () =
        let input = pathToModel
        let result = input |> loadModelAndGetPredictor
        result |> Assert.IsInstanceOf<PredictionEngine<SpamModel.spamModel.EmailData, SpamModel.spamModel.EmailResult>>
    
    [<Test>]
    let ``LoadSchemaAndGetPredictor model missing`` () =
        let input = pathToMissingModel
        try
            input |> loadModelAndGetPredictor |> ignore
            Assert.Fail ()
        with
            | :? System.IO.FileNotFoundException -> Assert.Pass ()

    [<Test>]
    let ``IsSpam check return type`` () =
        let inputA = "Hello"
        let inputB = "World"
        let result = inputB |> (inputA |> (isSpam predictionEngine))
        result |> Assert.IsInstanceOf<bool>