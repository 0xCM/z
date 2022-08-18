//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitLogix
    {
        [MethodImpl(Inline), Op]
        public static bit not(bit a)
            => !a;

        [MethodImpl(Inline), Op]
        public static bit identity(bit a)
            => a;

        [MethodImpl(Inline), Op]
        public static bit @false(bit a)
            => bit.Off;

        [MethodImpl(Inline), Op]
        public static bit @true(bit a)
            => bit.On;
    }
}