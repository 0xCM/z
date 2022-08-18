//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IImmResover : IFunc
    {
        NumericKind ImmKind
            => NumericKind.None;

        NativeTypeWidth OperandWidth
            => NativeTypeWidth.None;
    }

    [Free, SFx]
    public interface IImmResolver<T> : IImmResover
        where T : unmanaged
    {
        NumericKind IImmResover.ImmKind
            => NumericKinds.kind<T>();
    }

    [Free, SFx]
    public interface IImm8Resolver<V> : IImmResolver<byte>
        where V : struct
    {

    }

    [Free, SFx]
    public interface IImm8UnaryResolver<W,V> : IImm8Resolver<V>
        where V : struct
        where W : unmanaged, ITypeWidth
    {
        DynamicDelegate<UnaryOp<V>>  @delegate(byte imm8);

        NativeTypeWidth IImmResover.OperandWidth
            => Widths.type<W>();
    }

    [Free, SFx]
    public interface IImm8BinaryResolver<W,V> : IImm8Resolver<V>
        where V : struct
        where W : unmanaged, ITypeWidth
    {
        DynamicDelegate<BinaryOp<V>> @delegate(byte imm8);

        NativeTypeWidth IImmResover.OperandWidth
            => Widths.type<W>();
    }

    [Free, SFx]
    public interface IImm8UnaryResolver128<T> : IImm8UnaryResolver<W128,Vector128<T>>
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IImm8UnaryResolver256<T> : IImm8UnaryResolver<W256,Vector256<T>>
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IImm8BinaryResolver128<T> : IImm8BinaryResolver<W128,Vector128<T>>
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IImm8BinaryResolver256<T>  : IImm8BinaryResolver<W256,Vector256<T>>
        where T : unmanaged
    {

    }
}