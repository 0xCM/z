//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolDeployment
    {
        public readonly Tool Tool;

        public readonly FileUri Path;

        [MethodImpl(Inline)]
        public ToolDeployment(Tool tool, FileUri path)
        {
            Tool = tool;
            Path = path;
        }

        public string Format()
            => string.Format("{0}:{1}", Tool.Format(), Path);

        public override string ToString()
            => Format();
    }
}