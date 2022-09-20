namespace MailCore
module fsMessages =
    open Microsoft.Office.Interop
    open SpamModel.spamModel
    open TextCleaner
    
    let checkIsSpam (mail:Outlook.MailItem, outlookNamespace:Outlook.NameSpace, predictionEngine:Microsoft.ML.PredictionEngine<EmailData, EmailResult>) =
        //This is a match expression effectively checking if the MailItem/COM object that has been passed to this method is an email or not, Emails have a .MessageClass value of IPM.Note
        //MessageClass Types API: https://docs.microsoft.com/en-us/office/vba/outlook/concepts/forms/item-types-and-message-classes
        //MailItem.MessageClass API: https://docs.microsoft.com/en-us/office/vba/api/outlook.mailitem.messageclass
        match mail.MessageClass with
        | "IPM.Note" ->
            //Calls Wills Textcleaner with the value mail.Body and then mail.subject which is string
            //The cleaned strings are then piped into the isSpam method which will return a true or false value determining whether or not an email is spam
            //let subject = mail.Subject
            match textCleaner.fullParse mail.Body, 
                    textCleaner.fullParse mail.Subject  with
            |Some body, Some subject ->
                if  body |> (subject |> (predictionEngine|> isSpam))
                then 
                    //Moves a Mailitem object (an email) to the default junk folder
                    mail.Move(outlookNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderJunk)) |> ignore
                    ()
                else 
                    ()
            |_ ->
                ()
        | _ ->
            ()