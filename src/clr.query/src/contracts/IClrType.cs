//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IClrType : INullity, IExpr
    {
        Identifier Name {get;}

        ulong Kind => 0;

        bool INullity.IsEmpty 
            => Name.IsEmpty;

        bool INullity.IsNonEmpty 
            => !IsEmpty;

        string IExpr.Format()
            => Name;

    }

    public interface IClrType<K> : IClrType
        where K : unmanaged
    {
        new K Kind {get;}

    }
    public interface IClrEnumType : IClrType<PrimalKind>
    {
        ClrEnumKind EnumKind {get;}

        PrimalKind ScalarKind
            => (PrimalKind)EnumKind;

        BitWidth ContentWidth
            => PrimalBits.width(EnumKind);

        BitWidth StorageWidth
            => PrimalBits.width(EnumKind);

        PrimalKind IClrType<PrimalKind>.Kind
            => ScalarKind;

        ulong IClrType.Kind
            => (ulong)PrimalBits.width(EnumKind);
    }
}