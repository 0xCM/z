//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = Bitfields;

[StructLayout(LayoutKind.Sequential)]
public struct Bitfield<T>
    where T : unmanaged
{
    readonly BfModel Model;

    public T State;

    [MethodImpl(Inline)]
    public Bitfield(BfModel model, T state)
    {
        State = state;
        Model = model;
    }

    public ReadOnlySpan<BfSegModel> SegSpecs
    {
        [MethodImpl(Inline)]
        get => Model.Segments;
    }

    [MethodImpl(Inline)]
    public T Extract(byte field)
        => api.seg(this, field);

    [MethodImpl(Inline)]
    public Bitfield<T> Store(byte field, T src)
    {
        api.store(src, field, ref this);
        return this;
    }

    [MethodImpl(Inline)]
    internal void Overwrite(T src)
        => State = src;
}
