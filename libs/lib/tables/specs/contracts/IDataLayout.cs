//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IDataLayout : ITextual
    {
        LayoutIdentity Id {get;}

        BitWidth Width {get;}

        uint Index
            => Id.Index;

        ulong Kind
            => Id.Kind;
    }

    public interface IDataLayout<H> : IDataLayout
        where H : struct, IDataLayout<H>
    {

    }

    public interface IDataLayout<H,S> : IDataLayout<H>
        where H : struct, IDataLayout<H,S>
        where S : struct
    {
        ReadOnlySpan<S> Partitions {get;}

        uint PartitionCount
            => (uint)Partitions.Length;
    }

    public interface IDataLayout<H,S,T> : IDataLayout<H,S>
        where H : struct, IDataLayout<H,S,T>
        where S : struct
        where T : unmanaged
    {
        new LayoutIdentity<T> Id {get;}

        LayoutIdentity IDataLayout.Id
            => Id;
    }
}