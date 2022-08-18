//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using api = DataLayouts;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DataLayout<T> : IDataLayout<DataLayout<T>,LayoutPart<T>,T>
        where T : unmanaged
    {
        public LayoutIdentity<T> Id {get;}

        readonly Index<LayoutPart<T>> Data;

        [MethodImpl(Inline)]
        public DataLayout(LayoutIdentity<T> id, LayoutPart<T>[] parts)
        {
            Id = id;
            Data = parts;
        }

        public uint Index
        {
            [MethodImpl(Inline)]
            get => Id.Index;
        }

        public uint PartitionCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public LayoutPart<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReadOnlySpan<LayoutPart<T>> Partitions
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref LayoutPart<T> FirstPartition
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref LayoutPart<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => api.width(Partitions);
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DataLayout(DataLayout<T> src)
            => api.untyped(src);
    }
}