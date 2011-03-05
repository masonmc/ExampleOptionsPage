using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.Samples.VisualStudio.IDE.OptionsPage
{
    public class DevStudioColorSetter
    {
        public DevStudioColorSetter(object storage)
        {
            m_pStorage = (IVsFontAndColorStorage)storage;
        }
        IVsFontAndColorStorage m_pStorage = null;

        public void ApplyColorSet(ThemeAsset colorSet)
        {
            // these guids are like windows, a lot of different windows have plain text
            // this one is the main category, other categories may be printers etc
            m_pStorage.OpenCategory(new Guid("{A27B4E24-A735-4D1D-B8E7-9716E1E3D8E0}"), (uint)__FCSTORAGEFLAGS.FCSF_PROPAGATECHANGES);
            {
                SetForegroundColor("Plain Text", colorSet.GetColor(eThemeColor.PlainText_FG));
                SetBackgroundColor("Plain Text", colorSet.GetColor(eThemeColor.PlainText_BG));

                SetForegroundColor("Selected Text", colorSet.GetColor(eThemeColor.SelectedText_FG));
                SetBackgroundColor("Selected Text", colorSet.GetColor(eThemeColor.SelectedText_BG));

                SetForegroundColor("Inactive Selected Text", colorSet.GetColor(eThemeColor.InactiveSelectedText_FG));
                SetBackgroundColor("Inactive Selected Text", colorSet.GetColor(eThemeColor.InactiveSelectedText_BG));


            }
            m_pStorage.CloseCategory();

            // {358463D0-D084-400F-997E-A34FC570BC72}
            // changed text, selected text, text

            // {8259ACED-490A-41B3-A0FB-64C842CCDC80}
            // changed text, selected text, text

            // {A7EE6BEE-D0AA-4B2F-AD9D-748276A725F6}
            // changed text, selected text, text

            // {40660F54-80FA-4375-89A3-8D06AA954EBA}
            // these change when "all text tool windows" changes
            // inactive selected text, plain text, selected text

            // {9E632E6E-D786-4F9A-8D3E-B9398836C784}
            // inactive selected text, plain text, selected text

            // {6BB65C5A-2F31-4BDE-9F48-8A38DC0C63E7}
            // inactive selected text, plain text, selected text

            // {CE2ECED5-C21C-464C-9B45-15E10E9F9EF9}
            // inactive selected text, plain text, selected text

            // {EE1BE240-4E81-4BEB-8EEA-54322B6B1BF5}
            // inactive selected text, plain text, selected text

            // {5C48B2CB-0366-4FBF-9786-0BB37E945687}
            // "all text tool windows"
            // inactive selected text, plain text, selected text, current list location

            // {9973EFDF-317D-431C-8BC1-5E88CBFD4F7F}
            // inactive selected text, plain text, selected text, current list location




            // what is this
            m_pStorage.OpenCategory(new Guid("{CE2ECED5-C21C-464C-9B45-15E10E9F9EF9}"), (uint)__FCSTORAGEFLAGS.FCSF_PROPAGATECHANGES);
            {
                SetForegroundColor("Plain Text", colorSet.GetColor(eThemeColor.PlainText_FG));
                SetBackgroundColor("Plain Text", colorSet.GetColor(eThemeColor.PlainText_BG));

                SetForegroundColor("Selected Text", colorSet.GetColor(eThemeColor.SelectedText_FG));
                SetBackgroundColor("Selected Text", colorSet.GetColor(eThemeColor.SelectedText_BG));

                SetForegroundColor("Inactive Selected Text", colorSet.GetColor(eThemeColor.InactiveSelectedText_FG));
                SetBackgroundColor("Inactive Selected Text", colorSet.GetColor(eThemeColor.InactiveSelectedText_BG));

            }
            m_pStorage.CloseCategory();
        }

        void SetBackgroundColor(string item, ThemeColor color)
        {
            SetColor(item, color.m_color, false);
        }

        void SetForegroundColor(string item, ThemeColor color)
        {
            SetColor(item, color.m_color, true);
        }

        void SetColor(string item, Color color, bool isForeground)
        {
            var cii = new ColorableItemInfo[1];
            uint wincolor = (uint)(color.B << 16) + (uint)(color.R) + (uint)(color.G << 8);
            if (isForeground)
            {
                cii[0].bForegroundValid = 1;
                cii[0].crForeground = (uint)wincolor;
            }
            else
            {
                cii[0].bBackgroundValid = 1;
                cii[0].crBackground = (uint)wincolor;
            }
            m_pStorage.SetItem(item, cii);
        }
    }
}
