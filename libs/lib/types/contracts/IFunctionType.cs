//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFunctionType : IType
    {
        Index<TypeRef> Operands {get;}

        TypeRef Return {get;}
    }
}