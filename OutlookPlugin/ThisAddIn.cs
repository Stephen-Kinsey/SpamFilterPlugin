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
        // Instantiation of OutlookNamespace, inbox, items and Prediction engine
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;
        Microsoft.ML.PredictionEngine<spamModel.EmailData, spamModel.EmailResult> predictionEngine;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // OutlookNamespace is a reference to the instance of outlook the add-in is running in, this is acquired through GetNameSpcae("MAPI")
            outlookNameSpace = this.Application.GetNamespace("MAPI");

            //API doc : https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.interop.outlook.oldefaultfolders?view=outlook-pia
            //inbox is a reference to the default folder which is acquired using an enumeration of OlDefaultFolders
            //API doc for outlookNameSpace.getDefaultFolder : https://docs.microsoft.com/en-us/office/vba/api/outlook.namespace.getdefaultfolder
            inbox = outlookNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);

            //predictionEngine is an instance of the prediction engine that is being used in SpamModel by being passedto MailCore and then to SpamModel
            predictionEngine = spamModel.loadModelAndGetPredictor("spamModel");

            //gets a collection of items from specified folder, in this case the default folder we previously found
            items = inbox.Items;
            //When Items are added to the inbox that was previously "got" a new item event occurs and the event handler calls the method Items_ItemAdd
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(Items_ItemAdd);


            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        private void Items_ItemAdd(object Item)
        {
            //This sets the type of the parameter that has been passed to an outlook mail item which means the properties of a mail item can be used on it.
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            //This is a call to the MailCore library with the following parameters being passed; The MailItem object, the Outlook namespace and the spam model we previously created.
            //This is so there does need to be anything else programmed in C# and all of the email moving and predictions can be done in F#
            fsMessages.checkIsSpam(mail, outlookNameSpace, predictionEngine);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
