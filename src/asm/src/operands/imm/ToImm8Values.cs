//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    
    public static partial class XTend
    {
        [Op]
        public static Index<Imm8R> ToImm8Values(this byte[] src, ImmRefinementKind kind)
            => src.Map(x => new Imm8R(x));
    }
}