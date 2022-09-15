//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class Zsh : Tool<Zsh>
    {
        public Zsh()
            : base("zsh")
        {

        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }
}