namespace MailCore
module fsMessages =
    open Microsoft.Office.Interop
    open SpamModel.spamModel

    //let predictionEngine = loadModelAndGetPredictor <| "spamModel"
    let checkIsSpam (mail:Outlook.MailItem, outlookNamespace:Outlook.NameSpace, predictionEngine:Microsoft.ML.PredictionEngine<EmailData, EmailResult>) =
        match mail.MessageClass with
        | "IPM.Note" ->
            if mail.Body |> (mail.Subject |> (predictionEngine|> isSpam))
            then mail.Move(outlookNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderJunk)) |> ignore
                 ()
            else ()
        | _ ->
            ()

    let test (mail:Outlook.MailItem) = 
        match mail.MessageClass with
        | "IPM.Note" ->
            if mail.Body |> (mail.Subject |> ((loadModelAndGetPredictor <| "spamModel")|> isSpam))
            then 
                //mail.Move(nameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderJunk)) |> ignore
                ignore
            else ignore
        | _ -> ignore
