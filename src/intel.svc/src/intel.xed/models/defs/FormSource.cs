//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    /// <summary>
    /// Defines a structure that reflects the content of the xed "idata.txt" file
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct FormSource
    {
        public const string TableId = "xed.idata";

        [Render(16)]
        public string Class;

        [Render(16)]
        public string Extension;

        [Render(24)]
        public string Category;

        [Render(80)]
        public string Form;

        [Render(24)]
        public string IsaSet;

        [Render(1)]
        public string Attributes;
    }
}
