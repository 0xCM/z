//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct CmdFlow
    {
        public const string TableId = "cmd.flow";

        public const byte FieldCount = 5;

        [Render(24)]
        public Tool Tool;

        [Render(60)]
        public @string SourceName;

        [Render(60)]
        public @string TargetName;

        [Render(80)]
        public FS.FilePath SourcePath;

        [Render(1)]
        public FS.FilePath TargetPath;

        [MethodImpl(Inline)]
        public CmdFlow(Tool tool, FS.FilePath src, FS.FilePath dst)
        {
            Tool = tool;
            SourceName = src.FileName.Format();
            TargetName = dst.FileName.Format();
            SourcePath = src;
            TargetPath = dst;
        }

        public string Format()
            => string.Format("{0}:{1} -> {2}", Tool, SourceName, TargetName);

        public override string ToString()
            => Format();

        public static CmdFlow Empty
        {
            [MethodImpl(Inline)]
            get => new CmdFlow(Tool.Empty, FS.FilePath.Empty, FS.FilePath.Empty);
        }
    }
}