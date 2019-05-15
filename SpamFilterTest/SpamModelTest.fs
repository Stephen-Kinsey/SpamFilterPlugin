namespace SpamModelTest
module SpamModelTest =
    open NUnit.Framework
    open Microsoft.ML
    open Microsoft.ML.Data
    open SpamModel
    open FsCheck

    [<SetUp>]
    let mlContext = MLContext()

    [<Test>]
    let ``I have a descriptive test name`` () =
        Assert.Pass()
