//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMemoryFile : IDisposable, ISized, IAddressable
    {
        MemoryAddress BaseAddress {get;}

        MemoryAddress IAddressable.Address
            => BaseAddress;

        ReadOnlySpan<byte> View(ulong offset, ByteSize size);

        ReadOnlySpan<byte> View();

        ReadOnlySpan<T> View<T>();

        ref readonly T Skip<T>(uint cells);

        ref readonly T First<T>()
            => ref Skip<T>(0);

        string IExpr.Format()
            => BaseAddress.Format();
    }

    public interface IMemoryFile<F> : IMemoryFile, IComparable<F>
        where F : IMemoryFile<F>
    {

    }
}