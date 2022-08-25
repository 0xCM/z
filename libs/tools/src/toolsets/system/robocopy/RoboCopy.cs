//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    partial class Tools
    {
        public static object robocopy(FolderPath src, FolderPath dst)
            => (src,dst);

        public sealed partial class RoboCopy : Tool<RoboCopy>
        {
            public RoboCopy()
                : base(N.robocopy)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }
    }
}