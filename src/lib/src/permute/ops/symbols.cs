//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Perm
    {
        [MethodImpl(Inline), Op]
        public static bool symbols(Perm4L src, Span<SymVal<Perm4L>> dst)
        {
            const byte Count = 4;
            for(byte i=0; i<Count; i++)
                if(!symbol(src, i, out seek(dst, i)))
                    return false;
            return true;
        }

        /// <summary>
        /// Extracts the ordered sequence of symbolic literals that define an 8-symbol permutation to a caller-supplied target
        /// </summary>
        /// <param name="src">The canonical literal representation</param>
        /// <param name="dst">The literal receiver</param>
        [MethodImpl(Inline), Op]
        public static bool symbols(Perm8L src, Span<SymVal<Perm8L>> dst)
        {
            const byte Count = 8;
            for(byte i=0; i<Count; i++)
                if(!symbol(src, i, out seek(dst, i)))
                    return false;
            return true;
        }

        /// <summary>
        /// Extracts the ordered sequence of symbolic literals that define a 16-symbol permutation to a caller-supplied target
        /// </summary>
        /// <param name="src">The canonical literal representation</param>
        /// <param name="dst">The literal receiver</param>
        [MethodImpl(Inline), Op]
        public static bool symbols(Perm16L src, Span<SymVal<Perm16L>> dst)
        {
            const byte Count = 16;
            for(byte i=0; i<Count; i++)
                if(!symbol(src, i, out seek(dst,i)))
                    return false;
            return true;
        }

        /// <summary>
        /// Extracts the ordered sequence of symbolic literals that define a 16-symbol permutation to a caller-supplied target
        /// </summary>
        /// <param name="src">The canonical literal representation</param>
        public static Span<SymVal<Perm16L>> symbols(Perm16L src)
        {
            const byte Count = 16;
            var dst = new SymVal<Perm16L>[Count];
            if(!symbols(src,dst))
                return Span<SymVal<Perm16L>>.Empty;
            return dst;
        }

        /// <summary>
        /// Extracts the ordered sequence of symbolic literals that define a 4-symbol permutation
        /// </summary>
        /// <param name="src">The canonical literal representation</param>
        public static Span<SymVal<Perm4L>> symbols(Perm4L src)
        {
            const byte Count = 4;
            var dst = new SymVal<Perm4L>[Count];
            if(!symbols(src, dst))
                return Span<SymVal<Perm4L>>.Empty;
            return dst;
        }

        /// <summary>
        /// Extracts the ordered sequence of symbolic literals that define an 8-symbol permutation
        /// </summary>
        /// <param name="src">The canonical literal representation</param>
        public static Span<SymVal<Perm8L>> symbols(Perm8L src)
        {
            const byte Length = 8;
            var dst = new SymVal<Perm8L>[Length];
            if(!symbols(src, dst))
                return Span<SymVal<Perm8L>>.Empty;
            return dst;
        }
    }
}