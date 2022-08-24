//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct Swaps
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Renders the tranposition as text in canonical form
        /// </summary>
        [MethodImpl(Inline), Op]
        public static string format(Swap src)
            => $"({src.i} {src.j})";

        /// <summary>
        /// The canonical swap function defined over readonly parametric references
        /// </summary>
        /// <param name="lhs">The left value</param>
        /// <param name="rhs">The right value</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void violation<T>(in T lhs, in T rhs)
        {
            var temp = lhs;
            edit(lhs) = rhs;
            edit(rhs) = temp;
        }

        /// <summary>
        /// The canonical swap function defines over parametric references
        /// </summary>
        /// <param name="lhs">The left value</param>
        /// <param name="rhs">The right value</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void swap<T>(ref T lhs, ref T rhs)
        {
            var temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        /// <summary>
        /// Exchanges operand targets
        /// </summary>
        /// <param name="pLhs"></param>
        /// <param name="pRhs"></param>
        /// <typeparam name="T"></typeparam>
        /// <remarks>
        /// T:uint32: mov eax,[rdx] => mov [rcx],eax => mov eax,[rcx] => mov [rdx],eax
        /// T:uint32: *rdx -> eax => eax -> *rcx => *rcx -> eax -> eax -> *rdx
        /// T:uint64: mov rax,[rdx] => mov [rcx],rax => mov rax,[rcx] => mov [rdx],rax
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void swap<T>(T* pLhs, T* pRhs)
            where T : unmanaged
        {
            var pTmp = pLhs;
            *pLhs = *pRhs;
            *pRhs = *pTmp;
        }

        /// <summary>
        /// Interchanges span elements i and j
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="i">An index of a span element</param>
        /// <param name="j">An index of a span element</param>
        /// <typeparam name="T">The span element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void swap<T>(Span<T> src, uint i, uint j)
            where T : unmanaged
        {
            if(i==j)
                return;

            ref var data = ref first(src);
            var a = seek(data, i);
            seek(data, i) = skip(data, j);
            seek(data, j) = a;
        }

        /// <summary>
        /// Effects (i j) -> ((i + 1) (j+ 1))
        /// </summary>
        [MethodImpl(Inline), Op]
        public static ref Swap inc(ref Swap src)
        {
            ++src.i;
            ++src.j;
            return ref src;
        }

        /// <summary>
        /// Effects (i j) -> ((i - 1) (j - 1)) where decremented indices are clamped to 0
        /// </summary>
        [MethodImpl(Inline), Op]
        public static ref Swap dec(ref Swap src)
        {
            if(src.i != 0)
                src.i--;
            if(src.j != 0)
                --src.j;
            return ref src;
        }

        /// <summary>
        /// Creates a sequence of transpositions
        /// </summary>
        /// <param name="s0">The leading transposition</param>
        /// <param name="len">The length of the chain</param>
        [MethodImpl(Inline), Op]
        public static Swap[] chain(Swap s0, int len)
        {
            var buffer = alloc<Swap>(len);
            ref var dst = ref first(buffer);
            seek(dst,0)  = s0;
            for(var k = 1; k<len; k++)
                seek(dst,k) = ++s0;
            return buffer;
        }

        /// <summary>
        /// Parses a transposition in canonical form (i j), if possible; otherwise
        /// returns the empty transposition
        /// </summary>
        /// <param name="src">The source text</param>
        public static Swap parse(string src)
        {
            var indices = src.RemoveAny(Chars.LParen, Chars.RParen).Trim().Split(Chars.Space);
            if(indices.Length != 2)
                return Swap.Empty;

            var result = Option.Try(() => (Int32.Parse(indices[0]), Int32.Parse(indices[1])));
            if(result.IsSome())
                return result.Value();
            else
                return Swap.Empty;
        }
    }
}