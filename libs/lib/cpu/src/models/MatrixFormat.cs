//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    using static Root;
    using static core;

    public static class MatrixFormat
    {
        public static Matrix<M,N,T> ToMatrix<M,N,T>(this Matrix256<M,N,T> src)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T : unmanaged
                => Matrix.load<M,N,T>(src.Unblocked);

        [MethodImpl(Inline)]
        static int ColWidth<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
                return 8;
            else if(typeof(T) == typeof(short) || typeof(T) == typeof(ushort))
                return 10;
            else if(typeof(T) == typeof(int) || typeof(T) == typeof(uint))
                return 12;
            else
                return 22;
        }

        [MethodImpl(Inline)]
        public static int ColFormatWidth<M,N,T>(this Matrix256<M,N,T> src)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T : unmanaged
                => ColWidth<T>();

        [MethodImpl(Inline)]
        public static int ColFormatWidth<M,N,T>(this Matrix<M,N,T> src)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T : unmanaged
                => ColWidth<T>();

        public static string Format<M,N,T>(this Matrix256<M,N,T> src, int? cellwidth = null, char? cellsep = null, Func<T,string> render = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var width = cellwidth ?? src.ColFormatWidth();
            var sep = cellsep ?? '|';
            var rows = (int)Typed.nat64u<M>();
            var cols = (int)Typed.nat64u<N>();
            var sb = new StringBuilder();
            for(var row = 0; row < rows; row++)
            {
                for(var col = 0; col<cols; col++)
                {
                    var cellval = src[row,col];
                    var cellfmt = text.concat(
                        col == 0 ? string.Empty : " ",
                        $"{render?.Invoke(cellval) ?? cellval.ToString()}".PadRight(width)
                        );

                    sb.Append(cellfmt);
                    if(col != cols - 1)
                        sb.Append(sep);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string Format<M,N,T>(this Matrix<M,N,T> src, int? cellwidth = null, char? cellsep = null, Func<T,string> render = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T : unmanaged
        {
            var width = cellwidth ?? src.ColFormatWidth();
            var sep = cellsep ?? '|';
            var rows = (int)Typed.nat64u<M>();
            var cols = (int)Typed.nat64u<N>();
            var sb = new StringBuilder();
            for(var row = 0; row < rows; row++)
            {
                for(var col = 0; col<cols; col++)
                {
                    var cellval = src[row,col];
                    var cellfmt = text.concat(
                        col == 0 ? string.Empty : " ",
                        $"{render?.Invoke(cellval) ?? cellval.ToString()}".PadRight(width)
                        );
                    sb.Append(cellfmt);
                    if(col != cols - 1)
                        sb.Append(sep);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string Format<N,T>(this Matrix256<N,T> src, int? cellwidth = null, char? cellsep = null, Func<T,string> render = null)
            where N: unmanaged, ITypeNat
            where T : unmanaged
                => src.ToRectangular().Format(cellwidth, cellsep,render);

        public static string Format<N,T>(this Matrix<N,T> src, int? cellwidth = null, char? cellsep = null, Func<T,string> render = null)
            where N: unmanaged, ITypeNat
            where T : unmanaged
                => src.ToRectangular().Format(cellwidth, cellsep,render);

        /// <summary>
        /// Renders the source vector as text
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="N">The natural type</typeparam>
        /// <typeparam name="T">The component type</typeparam>
        public static string Fomat<N,T>(this Block256<N,T> src)
            where T : unmanaged
            where N: unmanaged, ITypeNat
                => src.Unsized.FormatList();
    }
}