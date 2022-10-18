//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    public sealed class VisualStudio : Tool<VisualStudio>
    {
        public VisualStudio()
            : base(N.msvs)
        {

        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }   
}