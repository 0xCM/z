//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDataWidth : IBitWidth, IExpr
    {
        DataWidth DataWidth {get;}

        bool INullity.IsEmpty
            => DataWidth == 0;

        bool INullity.IsNonEmpty
            => DataWidth != 0;

        TypeSignKind TypeSign
            => TypeSignKind.Unsigned;

        uint IBitWidth.BitWidth
            => (uint)DataWidth;

        string IExpr.Format()
            => DataWidth.FormatValue();
    }

    public interface IDataWidth<W> : IDataWidth, IEquatable<W>
        where W : struct, IDataWidth<W>
    {

    }
}