//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IMethodBodyEmitter
    {
        ILGenerator Emit(DynamicMethod dst);
    }
}