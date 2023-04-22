//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TernaryCellFunctionClass : ICellFunctionClass<TernaryCellFunctionClass,ApiOperatorKind>
    {
        public NativeTypeWidth Width {get;}

        public ApiOperatorKind Kind
            => ApiOperatorKind.TernaryOp;

        public OperatorClass Classifier
        {
            [MethodImpl(Inline)]
            get => new OperatorClass(Kind);
        }

        [MethodImpl(Inline)]
        public TernaryCellFunctionClass(NativeTypeWidth width)
            => Width = width;

        [MethodImpl(Inline)]
        public static implicit operator OperatorClass(TernaryCellFunctionClass src)
            => new OperatorClass(src.Kind);
    }
}