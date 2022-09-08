//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResDocInfo
    {
        public readonly Label Name;

        [MethodImpl(Inline)]
        public ResDocInfo(Label name)
        {
            Name = name;
        }

        public string Format()
            => Name.Format();
    }
}