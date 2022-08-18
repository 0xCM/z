//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using static core;

    [Free]
    public interface IIndexedView<T> : INullity, IMeasured, ITextual
    {
        T[] Storage {get;}

        ReadOnlySpan<T> View
            => Storage;

        ref readonly T this[long index]
            => ref skip(View, index);

        ref readonly T this[ulong index]
            => ref skip(View, index);

        int IMeasured.Length
            => View.Length;

        bool INullity.IsEmpty
            => Length == 0;

        bool INullity.IsNonEmpty
            => Length != 0;
    }

    /// <summary>
    /// Characterizes a <typeparamref name='I'/> indexed sequence of readonly <typeparamref name='T'/> terms
    /// </summary>
    /// <typeparam name="I">The index type</typeparam>
    /// <typeparam name="T">The element type</typeparam>
    [Free]
    public interface IIndexedView<I,T> : IIndexedView<T>, IMeasured<I>
        where I : unmanaged
    {
        ref readonly T this[I index]
            => ref skip(View, @as<I,uint>(index));

        int IMeasured.Length
            => View.Length;

        I IMeasured<I>.Length
            => @as<uint,I>((uint)View.Length);

        I ICounted<I>.Count
            => @as<uint,I>((uint)View.Length);
    }

    [Free]
    public interface IIndexedView<H,I,T> : IIndexedView<I,T>
        where I : unmanaged
        where H : IIndexedView<H,I,T>, new()
    {

    }
}