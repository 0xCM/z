//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IOperand : INullity, ITextual
    {
        Identifier Name {get;}

        IType Type {get;}

        OpDirection Direction {get;}

        Facets Facets {get;}

        bool INullity.IsEmpty
            => false;
    }

    public interface IOperand<T> : IOperand
        where T : unmanaged, IType<T>
    {
        new T Type {get;}
    }
}