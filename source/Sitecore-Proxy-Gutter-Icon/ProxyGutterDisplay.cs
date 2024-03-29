﻿/*
Copyright (C) 2012 Dan Solovay

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */

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