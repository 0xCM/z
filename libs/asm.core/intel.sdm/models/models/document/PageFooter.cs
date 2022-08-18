//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack =1)]
        public readonly struct PageFooter
        {
            public CharBlock16 Left0 {get;}

            public CharBlock16 Left1 {get;}

            public CharBlock16 Right0 {get;}

            public CharBlock16 Right1 {get;}

            [MethodImpl(Inline)]
            public PageFooter(CharBlock16 l0, CharBlock16 l1, CharBlock16 r0, CharBlock16 r1)
            {
                Left0 = l0;
                Left1 = l1;
                Right0 = r0;
                Right1 = r1;
            }

            public string Format()
                => string.Format("{0} {1} {2} {3}", Left0, Left1, Right0, Right1);

            public override string ToString()
                => Format();
        }
    }
}