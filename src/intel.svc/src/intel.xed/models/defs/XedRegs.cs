//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedModels
    {
        public struct XedRegs
        {
            ByteBlock32 Storage;

            public ref readonly byte Count
            {
                [MethodImpl(Inline), UnscopedRef]
                get => ref Storage[31];
            }

            public ref readonly XedRegId this[byte index]
            {
                [MethodImpl(Inline), UnscopedRef]
                get => ref seek(recover<XedRegId>(Storage.Bytes),index);
            }

            public static XedRegs Empty => default;
        }
    }
}