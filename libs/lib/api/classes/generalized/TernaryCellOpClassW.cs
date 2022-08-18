//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TernaryCellOpClass<W> : IApiCellOpClass<TernaryCellOpClass<W>,W,ApiOperatorKind>
        where W : unmanaged, ITypeWidth
    {
        public ApiOperatorKind Kind
            => ApiOperatorKind.TernaryOp;

        public NativeTypeWidth Width
            => Widths.type<W>();

        public OperatorClass<W> Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass<W>(Kind);
        }

        public TernaryCellFunctionClass Untyped
        {
            [MethodImpl(Inline)]
            get => new TernaryCellFunctionClass(Width);
        }

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass<W>(TernaryCellOpClass<W> src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator TernaryOperatorClass(TernaryCellOpClass<W> src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator TernaryCellFunctionClass(TernaryCellOpClass<W> src)
            => src.Untyped;
    }
}