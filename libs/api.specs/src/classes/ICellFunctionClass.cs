//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICellFunctionClass : IOperationClass
    {
        NativeTypeWidth Width {get;}
    }

    [Free]
    public interface ICellFunctionClass<F,E> : IOperationClass<E>, IOperationClass
        where F : struct, ICellFunctionClass<F,E>
        where E : unmanaged, Enum
    {

    }
}