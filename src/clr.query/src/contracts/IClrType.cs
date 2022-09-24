//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IClrType : IType<PrimalKind>
    {

    }

    public interface IClrEnumType : IClrType
    {
        ClrEnumKind EnumKind {get;}

        PrimalKind ScalarKind
            => (PrimalKind)EnumKind;

        BitWidth ContentWidth
            => PrimalBits.width(EnumKind);

        BitWidth StorageWidth
            => PrimalBits.width(EnumKind);

        PrimalKind IType<PrimalKind>.Kind
            => ScalarKind;

        ulong IType.Kind
            => (ulong)PrimalBits.width(EnumKind);
    }
}