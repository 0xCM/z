//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.InteropServices;

    partial struct SdmModels
    {
        /// <summary>
        /// EG Vol. 1 iii
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct VolPart
        {
            public CharBlock8 Volume;

            public byte Part;
        }
    }
}