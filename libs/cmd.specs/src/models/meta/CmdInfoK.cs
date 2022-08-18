//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdInfo<K>
        where K : unmanaged
    {
        public readonly K Id;

        public readonly CharBlock16 Name;

        public readonly CharBlock32 Description;

        [MethodImpl(Inline)]
        public CmdInfo(K id, in CharBlock16 name, in CharBlock32 desc)
        {
            Id = id;
            Name = name;
            Description = desc;
        }
    }
}