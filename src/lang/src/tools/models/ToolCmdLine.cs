//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ToolCmdLine : CmdLine, IComparable<ToolCmdLine>
    {
        public FilePath Tool => FS.path(this[0]);

        [MethodImpl(Inline)]
        public ToolCmdLine(FilePath tool, params string[] args)
            : base(Cmd.args(tool.Format()).Concat(Cmd.args(args)))
        {

        }

        public ToolCmdLine()
            : base(sys.empty<string>())
        {
        }

        public int CompareTo(ToolCmdLine src)
            => Tool.CompareTo(src.Tool);

        public new static ToolCmdLine Empty => new();
    }
}