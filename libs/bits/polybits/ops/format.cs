//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PolyBits
    {
        public static string format(ReadOnlySpan<BfInterval> src)
        {
            var dst = text.buffer();
            var count = src.Length;
            for(var i=count-1; i>= 0; i--)
            {
                if(i != count-1)
                {
                    dst.Append(Chars.Space);
                    dst.Append(Chars.Pipe);
                    dst.Append(Chars.Space);
                }

                dst.Append(skip(src,i));

            }
            return dst.Emit();
        }

        public static string format<F>(ReadOnlySpan<BfInterval<F>> src)
            where F : unmanaged
        {
            var dst = text.buffer();
            var count = src.Length;
            for(var i=count-1; i>= 0; i--)
            {
                if(i != count-1)
                {
                    dst.Append(Chars.Space);
                    dst.Append(Chars.Pipe);
                    dst.Append(Chars.Space);
                }

                dst.Append(skip(src,i));

            }
            return dst.Emit();
        }

        public static string format(in BfModel src)
        {
            static string typename(in BfModel src)
                => src.IsBitvector ? "bitvector" : "bitfield";

            static string decl(in BfModel src)
                => string.Format("{0} : {1}<{2}> " , src.Name, typename(src), src.Size.Packed);

            var dst = text.buffer();
            dst.AppendLine(decl(src) + Chars.LBrace);
            var indent = 2u;
            for(var i=0; i<src.SegCount; i++)
            {
                if(i != src.SegCount - 1)
                    dst.IndentLineFormat(indent, "{0},", expr(skip(src.Segments,i)));
                else
                    dst.IndentLineFormat(indent, "{0}", expr(skip(src.Segments,i)));
            }
            indent -= 2;
            dst.IndentLine(indent,Chars.RBrace);
            return dst.Emit();
        }
    }
}