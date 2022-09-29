//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciCode src)
            => src;

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciLetterLoSym src)
            => (AsciCode)src;

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciLetterUpSym src)
            => (AsciCode)src;

        [MethodImpl(Inline), Op]
        public static ref readonly AsciSymbol symbol(in byte src)
            => ref sys.view<byte,AsciSymbol>(src);
    }
}
