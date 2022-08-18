//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct XmlIndex<T> : IIndex<T>
        where T : IXmlModel
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public XmlIndex(Index<T> src)
        {
            Data = src;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public uint Count
        {
            get => Data.Count;
        }
        [MethodImpl(Inline)]
        public static implicit operator XmlIndex<T>(T[] src)
            => new XmlIndex<T>(src);
    }

}