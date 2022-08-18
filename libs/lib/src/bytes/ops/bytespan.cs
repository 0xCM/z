//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    unsafe partial class Bytes
    {
        /// <summary>
        /// Renders a sequence of <typeparamref name='T'/> values as a bytespan
        /// </summary>
        /// <param name="min">The first source value</param>
        /// <param name="max">The last source value</param>
        /// <param name="indent">The line indentation</param>
        /// <param name="dst">The emission target</param>
        /// <param name="bpl">The number of bytes per line</param>
        /// <typeparam name="T">The source value type</typeparam>
        public static void bytespan<T>(T min, T max, uint indent, ITextEmitter dst, byte bpl = 16)
            where T : unmanaged
        {
            var count = gcalc.count(min, max);
            var name = string.Format("B{0}x{1}u", count,  width<T>());
            bytespan<T>(name, min, max, indent, dst, bpl);
            dst.AppendLine();
        }

        /// <summary>
        /// Renders a sequence of <typeparamref name='T'/> values as a bytespan
        /// </summary>
        /// <param name="name">The bytespan name</param>
        /// <param name="i0">The first source value</param>
        /// <param name="i1">The last source value</param>
        /// <param name="indent">The line indentation</param>
        /// <param name="dst">The emission target</param>
        /// <param name="bpl">The number of bytes per line</param>
        /// <typeparam name="T">The source value type</typeparam>
        public static void bytespan<T>(string name, T i0, T i1, uint indent, ITextEmitter dst, byte bpl = 16)
            where T : unmanaged
        {
            const string Sep = ", ";
            var bpc = size<T>();
            var count = gcalc.count(i0,i1);
            var min = (long)bw64(i0);
            var cells = count*bpc;
            var counter = 0u;
            dst.IndentLineFormat(indent, "public static ReadOnlySpan<byte> {0} => new byte[{1}] {{", name, cells);
            indent += 4;
            for(var i=min; i<count; i++)
            {
                if(i==0)
                    dst.Indent(indent, Chars.Space);

                if(i != 0)
                    dst.Append(Sep);

                if(counter != 0 && counter % bpl == 0)
                {
                    dst.Append(Eol);
                    dst.Indent(indent, Chars.Space);
                }

                counter += render(@as<long,T>(i),dst);
            }

            dst.Append(Eol);
            indent -= 4;
            dst.IndentLine(indent, "};");
        }
    }
}