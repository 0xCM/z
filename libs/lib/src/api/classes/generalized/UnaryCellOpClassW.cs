//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct UnaryCellClass<W> : IApiCellOpClass<UnaryCellClass<W>,W,ApiOperatorKind>
        where W : unmanaged, ITypeWidth
    {
        public ApiOperatorKind Kind
            => ApiOperatorKind.UnaryOp;

        public NativeTypeWidth Width
            => Widths.type<W>();

        public OperatorClass<W> Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass<W>(Kind);
        }

        public UnaryCellFunctionClass Untyped
        {
            [MethodImpl(Inline)]
            get => new UnaryCellFunctionClass(Width);
        }

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass<W>(UnaryCellClass<W> src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator UnaryOperatorClass(UnaryCellClass<W> src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator UnaryCellFunctionClass(UnaryCellClass<W> src)
            => src.Untyped;
    }
}