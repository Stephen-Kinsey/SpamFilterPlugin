namespace MailCore
module fsMessages =
    open Microsoft.Office.Interop
    open SpamModel.spamModel
    open SpamModel
    
    open Microsoft.ML
    open Microsoft.ML.Data
    open Microsoft.ML.Transforms
    open Microsoft.ML.Trainers

    let checkIsSpam (mail:Outlook.MailItem, outlookNamespace:Outlook.NameSpace, predictionEngine:Microsoft.ML.PredictionEngine<EmailData, EmailResult>) =
        match mail.MessageClass with
        | "IPM.Note" ->
            if mail.Body |> (mail.Subject |> (predictionEngine|> isSpam))
            then 
                mail.Move(outlookNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderJunk)) |> ignore
                ()
            else 
                ()
        | _ ->
            ()