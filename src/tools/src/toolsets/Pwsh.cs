//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    public sealed class Pwsh : Tool<Pwsh>
    {
        public Pwsh()
            : base(N.pwsh)
        {

        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }
}