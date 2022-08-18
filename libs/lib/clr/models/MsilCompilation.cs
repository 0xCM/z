//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct MsilCompilation
    {
        public readonly MsilCode Msil;

        public readonly MemoryAddress EntryPoint;

        [MethodImpl(Inline)]
        public MsilCompilation(MsilCode msil, MemoryAddress entry)
        {
            Msil = msil;
            EntryPoint = entry;
        }
    }
}