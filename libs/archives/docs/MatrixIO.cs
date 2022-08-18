//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    public readonly struct MatrixIO
    {
        /// <summary>
        /// Defines the canonical filename for a matrix data file
        /// </summary>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The column count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static FS.FileName filename<M,N,T>(int? index = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dim = $"{TypeNats.value<M>()}x{TypeNats.value<N>()}";
            var kind = typeof(T).NumericKind().Format();
            var @base = $"mat_{kind}[{dim}]";
            var suffix  = index.MapValueOrDefault(i => Chars.Dot + index.ToString().PadLeft(3,'0'), EmptyString);
            return FS.file($"{@base}{suffix}", FS.Csv);
        }

        /// <summary>
        /// Reads a matrix from a delimited file
        /// </summary>
        /// <param name="src">The source file</param>
        /// <param name="fmt">The file format</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The column count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static Matrix256<M,N,T> blockread<M,N,T>(FS.FilePath src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var doc = TextGrids.parse(src).Require();
            var m = (int)nat64u<M>();
            var n = (int)nat64u<N>();

            if(m != doc.RowCount)
                return default;

            if(n != doc.Rows[0].CellCount)
                return default;

            var parser = Numeric.parser<T>();
            var dst =  Matrix.blockload<M,N,T>(SpanBlocks.alloc<T>(n256, nat64u<M>(), nat64u<N>()));
            for(var i = 0; i<doc.Rows.Length; i++)
            {
                ref readonly var row = ref doc[i];
                for(var j = 0; j<row.CellCount; j++)
                {
                    var result = default(T);
                    parser.Parse(row[j].Format(), out result);
                    dst[i,j] = result;
                }
            }

            return dst;
        }


        /// <summary>
        /// Writes a matrix to a delimited file
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dst">The target file</param>
        /// <typeparam name="M">The natural row count type</typeparam>
        /// <typeparam name="N">The natural column count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static void write<M,N,T>(Matrix256<M,N,T> src, StreamWriter dst, bool overwrite = true, TextDocFormat? fmt = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var options = fmt ?? TextDocFormat.Structured();
            var width = fmt?.ColWidth ?? (uint)src.ColFormatWidth();
            var sep = options.Delimiter;
            var rows = (int)nat64u<M>();
            var cols = (int)nat64u<N>();
            dst.WriteLine($"{options.CommentPrefix} {typeof(T).Name}[{rows}x{cols}]");
            if(options.HasHeader)
            {
                for(var i = 0; i<cols; i++)
                {
                    if(i != 0)
                        dst.Write(Chars.Space);

                    dst.Write($"Col{i}".PadRight((int)width, Chars.Space));

                    if(i != cols - 1)
                        dst.Write(sep);
                }
                dst.WriteLine();
            }

            dst.Write(src.Format((int)width, sep));
            dst.Flush();
        }

        public static Matrix256<M,N,T> read<M,N,T>(FS.FilePath src, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dst = blockread<M,N,T>(src);
            if(NumericKinds.fractional<T>())
                dst.Apply(x => gfp.round<T>(x,4));
            return dst;
        }

        public static Matrix256<M,N,T> write<M,N,T>(in Matrix256<M,N,T> src, FS.FilePath dst, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            using var writer = dst.Writer();
            if(NumericKinds.fractional<T>())
                src.Apply(x => gfp.round<T>(x,4));
            write(src, writer);
            return src;
        }
    }
}