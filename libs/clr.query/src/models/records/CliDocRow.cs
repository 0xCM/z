//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CliDocRow
    {
        const string TableId = "documents";

        [Render(12)]
        public CliBlobIndex Name;

        [Render(12)]
        public GuidIndex HashAlgorithm;

        [Render(12)]
        public CliBlobIndex Hash;

        [Render(12)]
        public GuidIndex Language;
    }
}