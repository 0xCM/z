//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // public readonly struct CmdTypeInfo<T> : ICmdTypeInfo<CmdTypeInfo<T>,T>
    //     where T : struct, ICmd<T>
    // {
    //     public CmdId CmdId => CmdTypes.name<T>();

    //     public Type Source => typeof(T);

    //     public string Format()
    //         => CmdId.Format();

    //     public override string ToString()
    //         => Format();

    //     public Index<FieldInfo> Fields
    //     {
    //         [MethodImpl(Inline)]
    //         get => Source.DeclaredInstanceFields();
    //     }

    //     [MethodImpl(Inline)]
    //     public static implicit operator CmdTypeInfo(CmdTypeInfo<T> src)
    //         => new CmdTypeInfo(src.CmdId,src.Source, src.Fields);
    // }
}