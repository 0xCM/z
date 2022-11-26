//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct XedScriptSpec
    {
        public const string TableId = "xed.scripts";

        public string Name;

        public FilePath InputPath;

        public FilePath SummaryPath;

        public FilePath DetailPath;
    }
}