//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    public partial class Tools
    {
        public sealed class Xed : Tool<Xed>
        {
            public Xed()
                : base(N.xed)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }
    }
}