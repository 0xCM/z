//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdInfo<K>
        where K : unmanaged
    {
        public readonly K Id;

        public readonly @string Name;

        public readonly @string Description;

        [MethodImpl(Inline)]
        public CmdInfo(K id, @string name, @string desc)
        {
            Id = id;
            Name = name;
            Description = desc;
        }
    }
}