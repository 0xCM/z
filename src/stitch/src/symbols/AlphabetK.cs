//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a set of symbols over which strings may be formed
    /// </summary>
    /// <typeparam name="K">The symbol value kind</typeparam>
    public class Alphabet<K> : IDisposable
        where K : unmanaged
    {
        /// <summary>
        /// The name of the alphabet
        /// </summary>
        public readonly Label Name;

        readonly NativeBuffer<K> Buffer;

        readonly Index<K> _Chars;

        public void Dispose()
        {
            Buffer.Dispose();
        }

        [MethodImpl(Inline)]
        internal Alphabet(Label name, K[] src)
        {
            Name = name;
            var count = (uint)src.Length;
            Buffer = NativeBuffers.alloc<K>(count);
            _Chars = src;
            for(var i=0u; i<src.Length; i++)
            {
                ref readonly var atom = ref skip(src,i);
                Buffer[i] = atom;
                _Chars[i] = atom;
            }
        }

        [MethodImpl(Inline)]
        public ref readonly K Char(uint key)
            => ref _Chars[key];

        [MethodImpl(Inline)]
        public ReadOnlySpan<K> Letters(uint offset, uint count)
            => core.cover(Buffer[offset],count);

        public ref K this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Buffer[index];
        }

        public ref K this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Buffer[index];
        }

        public ReadOnlySpan<K> this[uint offset, uint count]
        {
            [MethodImpl(Inline)]
            get => Letters(offset,count);
        }

        /// <summary>
        /// The symbols that comprise the alpabet
        /// </summary>
        public ReadOnlySpan<K> Members
        {
            [MethodImpl(Inline)]
            get => Buffer.View;
        }

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => (uint)Buffer.Count;
        }

        public string Format()
            => Alphabets.format(this);

        public override string ToString()
            => Format();
    }
}