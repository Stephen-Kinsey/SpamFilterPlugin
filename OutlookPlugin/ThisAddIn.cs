using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using MailCore;
using SpamModel;
// Gives access to the MailCore project and methods

namespace OutlookPlugin
{
    public partial class ThisAddIn
    {
        // Instantiation
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;
        Microsoft.ML.PredictionEngine<spamModel.EmailData, spamModel.EmailResult> predictionEngine;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
            predictionEngine = spamModel.loadModelAndGetPredictor("spamModel");

            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(Items_ItemAdd);
        }

        private void Items_ItemAdd(object Item)
        {
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            fsMessages.checkIsSpam((Outlook.MailItem)Item, (Outlook.NameSpace)outlookNameSpace,(Microsoft.ML.PredictionEngine<spamModel.EmailData, spamModel.EmailResult>)predictionEngine);
        }
    }
}
