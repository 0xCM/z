//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeOpValue : IValued
    {
        NativeSize Size {get;}
        
    }

    [Free]
    public interface INativeOpValue<T> : INativeOpValue, IValued<T>
        where T : unmanaged
    {
        NativeSize INativeOpValue.Size
            => Sized.native(sys.width<T>());

    }
}