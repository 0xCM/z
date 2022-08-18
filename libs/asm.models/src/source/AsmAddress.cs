//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    /// <summary>
    /// Represents an operand expression of the form BaseReg + IndexReg*Scale + Displacement
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct AsmAddress
    {
        public static string format(in AsmAddress src)
        {
            Span<char> dst = stackalloc char[64];
            var i=0u;
            var count = render(src, ref i, dst);
            return text.format(dst, count);
        }

        [Op]
        public static uint render(in AsmAddress src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var @base = src.Base.Format();
            var index = src.Index.Format();
            text.copy(@base, ref i, dst);
            var scale = src.Scale.Format();
            if(src.Scale.IsNonZero)
            {
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = Chars.Plus;
                seek(dst,i++) = Chars.Space;
                if(src.Scale.IsNonUnital)
                {
                    text.copy(scale,ref i, dst);
                    seek(dst,i++) = Chars.Star;
                }
                text.copy(index, ref i, dst);
            }

            if(src.Disp.Value != 0)
            {
                seek(dst,i++) = Chars.Space;
                text.copy(Disp.format(src.Disp,true), ref i, dst);
            }

            return i - i0;
        }

        public readonly RegOp Base;

        public readonly RegOp Index;

        public readonly MemoryScale Scale;

        public readonly Disp Disp;

        [MethodImpl(Inline)]
        public AsmAddress(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Base = @base;
            Index = index;
            Scale = scale;
            Disp = disp;
        }

        public bool HasIndex
        {
            [MethodImpl(Inline)]
            get => Index.IsNonEmpty;
        }

        public bool HasScale
        {
            [MethodImpl(Inline)]
            get => Scale.IsNonEmpty;
        }

        public bool HasDisp
        {
            [MethodImpl(Inline)]
            get => Disp.IsNonZero;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}