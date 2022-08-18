//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEndianKind
    {
        EndianKind Id {get;}
    }
    
    public interface IEndianKind<T> : IEndianKind
        where T : struct, IEndianKind<T>
    {

    }
}