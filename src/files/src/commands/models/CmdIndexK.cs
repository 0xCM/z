//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdIndex<K>
        where K : unmanaged
    {
        readonly Index<K,CmdInfo<K>> Data;

        [MethodImpl(Inline)]
        public CmdIndex(CmdInfo<K>[] src)
        {
            Data = src;
        }

        public ref CmdInfo<K> this[K id]
        {
            [MethodImpl(Inline)]
            get => ref Data[id];
        }

        public ref CmdInfo<K> First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<CmdInfo<K>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<CmdInfo<K>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdIndex<K>(CmdInfo<K>[] src)
            => new CmdIndex<K>(src);
    }
}