//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using XF = ExprPatterns;

    partial class LogicOps
    {
        readonly struct OpFormatters
        {
            [Formatter]
            public static string format(Sum src)
            {
                var terms = src.Members;
                var count = terms.Length;
                var dst = text.buffer();

                dst.Append(Chars.LBracket);
                for(var i=0; i<count; i++)
                {
                    if(i != 0)
                        dst.Append(Chars.Space);

                    dst.AppendFormat(RpOps.Slot0, skip(terms,i));

                    if(i != count - 1)
                    {
                        dst.Append(Chars.Space);
                        dst.Append(Chars.Pipe);
                    }
                }
                dst.Append(Chars.RBracket);

                return dst.Emit();
            }

            [Formatter]
            public static string format(Product src)
            {
                const char Delimiter = Chars.Comma;
                var dst = text.buffer();
                var count = src.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var expr = ref src[i];
                    dst.Append(expr.Format());
                    if(i != count - 1)
                        dst.Append(Delimiter);

                }
                return dst.Emit();
            }

            public static string format<T>(Product<T> src)
                where T : IExpr
            {
                const char Delimiter = Chars.Comma;
                var dst = text.buffer();
                dst.Append(Chars.LParen);
                var count = src.Count;
                for(var i=0; i<count; i++)
                {
                    dst.Append(src[i].Format());
                    if(i != count - 1)
                        dst.Append(Delimiter);

                }
                dst.Append(Chars.RParen);
                return dst.Emit();
            }

            public static string format<T>(Xor<T> src)
                where T : IExpr
                => string.Format(XF.BinaryChoice, src.Left, src.Right);

            public static string format<T>(Sop<T> src)
                where T : IExpr
            {
                const char Delimiter = Chars.Pipe;
                var dst = text.buffer();
                var count = src.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var product = ref src[i];

                    dst.Append(product.Format());

                    if(i != count - 1)
                        dst.Append(Delimiter);
                }

                return dst.Emit();
            }

            [Formatter]
            public static string format(Except src)
            {
                var terms = src.Terms.Array();
                var count = terms.Length;
                var dst = text.buffer();

                dst.Append(Chars.Tilde);
                dst.Append(XF.ListClose);
                for(var i=0; i<count; i++)
                {
                    if(i != 0)
                        dst.Append(Chars.Space);

                    dst.AppendFormat(RpOps.Slot0, skip(terms,i));

                    if(i != count - 1)
                    {
                        dst.Append(Chars.Space);
                        dst.Append(XF.Choice);
                    }
                }
                dst.Append(XF.ListClose);
                return dst.Emit();
            }
        }
    }
}