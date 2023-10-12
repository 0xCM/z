//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1,Size=(int)Size)]
    public struct InstLayoutBlock
    {
        public const uint Size = 256;

        Span<LayoutCell> Data
        {
            [MethodImpl(Inline), UnscopedRef]
            get => sys.recover<LayoutCell>(sys.bytes(this));
        }

        public ref LayoutCell this[int i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Data,i);
        }

        public ref LayoutCell this[uint i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Data,i);
        }
    }
}
