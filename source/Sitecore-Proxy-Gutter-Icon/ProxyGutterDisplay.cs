using System;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Applications.ContentEditor.Gutters;

namespace SharedSource
{
    public class ProxyGutterDisplay : GutterRenderer
    {
        protected override GutterIconDescriptor GetIconDescriptor(Item item)
        {
            if (item.RuntimeSettings.IsVirtual)
            {
                var gid = new GutterIconDescriptor {Icon = "Applications/32x32/documents.png"};
                if (item.RuntimeSettings.IsExternal)
                {
                    gid.Tooltip = String.Format("Proxy of item in {0} database.",
                                                item.RuntimeSettings.OwnerDatabase.Name);
                }
                else
                {
                    gid.Tooltip = "Proxy item. Click to see source.";
                    gid.Click = GetLinkToSource(item);
                }
                return gid;
            }
            return null;
        }

        private string GetLinkToSource(Item item)
        {
            ID sourceId = item.InnerData.Definition.ID;
            string linkString = String.Format("item:load(id={0})", sourceId);
            return linkString;
        }
    }
}