using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
// Gives access to the MailCore project and methods
using MailCore;

namespace OutlookPlugin
{
    public partial class ThisAddIn
    {
        // Instantiation
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);

            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
        }

        private void items_ItemAdd(object Item)
        {
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            //CallToForeignLibrary
        }
    }
}
