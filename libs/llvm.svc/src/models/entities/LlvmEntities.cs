//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmEntities
    {
        public static bits<byte> bits<N>(string src, W8 w, N n = default)
            where N : unmanaged, ITypeNat
                => BitNumber.parse(text.remove(Fenced.unfence(src, Fenced.Embraced),Chars.Comma, Chars.Space), w, n);

        public static bit bit(string src)
            => Z0.bit.parse(src);
    }
}