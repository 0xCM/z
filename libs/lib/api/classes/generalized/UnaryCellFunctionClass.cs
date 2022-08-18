//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct UnaryCellFunctionClass : ICellFunctionClass<UnaryCellFunctionClass,ApiOperatorKind>
    {
        public NativeTypeWidth Width {get;}

        public ApiOperatorKind Kind
            => ApiOperatorKind.UnaryOp;

        public OperatorClass Untyped
        {
            [MethodImpl(Inline)]
            get => new OperatorClass(Kind);
        }

        [MethodImpl(Inline)]
        public UnaryCellFunctionClass(NativeTypeWidth width)
            => Width = width;

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass(UnaryCellFunctionClass src)
            => default;
    }
}