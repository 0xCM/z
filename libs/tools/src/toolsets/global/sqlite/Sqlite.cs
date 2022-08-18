//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    partial class Tools
    {
        public sealed partial class Sqlite : Tool<Sqlite>
        {
            public Sqlite()
                : base(N.sqlite)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }
    }
}