//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAlgebraicField<S> : ICommutativeRing<S>, IDivisionRing<S>
            where S : IAlgebraicField<S>, new()
    {

    }
}