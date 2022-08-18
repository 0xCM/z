//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiGroup
    {
        public string Name {get;}

        [MethodImpl(Inline)]
        public ApiGroup(string name)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("group<{0}>",Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiGroup(string name)
            => new ApiGroup(name);
    }
}