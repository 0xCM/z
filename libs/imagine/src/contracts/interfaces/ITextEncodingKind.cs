//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextEncodingKind
    {
        TextEncodingKind Kind {get;}
    }

    public interface ITextEncodingKind<T> : ITextEncodingKind
        where T : unmanaged, ITextEncodingKind<T>
    {

    }
}