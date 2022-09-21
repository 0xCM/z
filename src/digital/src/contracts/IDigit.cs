//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDigit : IDataType
    {
        char Char {get;}

        string Format();

        bool INullity.IsNonEmpty
            => Char != 0;

        bool INullity.IsEmpty
            => Char == 0;
    }

    public interface IDigit<D,B,S,C,V> : IDigit, IDataType<D>
        where D : unmanaged, IDigit<D,B,S,C,V>
        where B : unmanaged, INumericBase<B>
        where S : unmanaged
        where V : unmanaged
        where C : unmanaged
    {
        S Symbol {get;}

        V Value {get;}

        C Code {get;}
    }
}