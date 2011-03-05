using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Microsoft.Samples.VisualStudio.IDE.OptionsPage
{
    public enum eThemeColor
    {
        PlainText_FG,
        PlainText_BG,
        SelectedText_FG,
        SelectedText_BG,
        InactiveSelectedText_FG,
        InactiveSelectedText_BG,
        IndicatorMargin,
        LineNumbers_FG,
        LineNumbers_BG,
        VisibleWhiteSpace,
        Bookmark,
        BraceMatchingHighlight,
        BraceMatchingRectangle,
        BreakpointDisabled,
        BreakpointEnabled_FG,
        BreakpointEnabled_BG,
        BreakpointError_FG,
        BreakpointError_BG,
        BreakpointWarning_FG,
        BreakpointWarning_BG,
        BreakpointAdvancedDisabled,
        BreakpointAdvancedEnabled_FG,
        BreakpointAdvancedEnabled_BG,
        BreakpointAdvancedError_FG,
        BreakpointAdvancedError_BG,
        BreakpointAdvancedWarning_FG,
        BreakpointAdvancedWarning_BG,
        BreakpointMappedDisabled,
        BreakpointMappedEnabled_FG,
        BreakpointMappedEnabled_BG,
        BreakpointMappedError_FG,
        BreakpointMappedError_BG,
        BreakpointMappedWarning_FG,
        BreakpointMappedWarning_BG,
        BreakpointSelected,
        CUserKeywords_FG,
        CUserKeywords_BG,
        CallReturn_FG,
        CallReturn_BG,
        CallReturnIntellisense_FG,
        CallReturnIntellisense_BG,
        CurrentStatementHistorical_FG,
        CurrentStatementHistorical_BG,
        CodeSnippetDepField,
        CodeSnippetField,
        CollapsibleText,
        CollapseHintAdornment_FG,
        CollapseHintAdornment_BG,
        Comment_FG,
        Comment_BG,




    };

    public class ThemeColor
    {
        public ThemeColor(int r, int g, int b)
        {
            m_color = Color.FromArgb(r, g, b);
        }
        public Color m_color;

        // MJM_TODO: option to make this color use a named base color
        // with certain hue, sat, or brightness modifiers.
    }
    public class ThemeAsset
    {
        public ThemeAsset()
        {
        }

        Dictionary<eThemeColor, ThemeColor> m_colors = new Dictionary<eThemeColor,ThemeColor>(32);

        Dictionary<string, ThemeColor> m_baseColors = new Dictionary<string, ThemeColor>(32);
        public ThemeColor GetColor(eThemeColor tc)
        {
            ThemeColor result = null;
            if (!m_colors.TryGetValue(tc, out result))
            {
                result = new ThemeColor(0, 0, 0); // MJM_TODO: maybe default?
                m_colors.Add(tc, result);
            }
            return result;
        }

        public void SetColor(eThemeColor tc, ThemeColor color)
        {
            if (m_colors.ContainsKey(tc))
            {
                m_colors[tc] = color;
            }
            else
            {
                m_colors.Add(tc, color);
            }
        }

    }
}
