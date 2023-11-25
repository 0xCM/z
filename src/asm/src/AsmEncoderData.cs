//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public class AsmEncoderData
{
    const byte ConditionCount = 16;

    const byte Jcc8Base = 0x70;

    const byte Jcc32Base = 0x80;

    [MethodImpl(Inline)]
    public static AsmEncoderData get()
        => Instance;

    [MethodImpl(Inline)]
    public ReadOnlySpan<Jcc8Code> Jcc8Codes()
        => _Jcc8Codes;

    [MethodImpl(Inline)]
    public ReadOnlySpan<Jcc32Code> Jcc32Codes()
        => _Jcc32Codes;

    [MethodImpl(Inline), Op]
    public JccInfo Describe(Jcc8Code code)
        => new (code, Name(code));

    [MethodImpl(Inline), Op]
    public JccInfo Describe(Jcc32Code code)
        => new (code,Name(code));

    [MethodImpl(Inline)]
    public ref readonly asci8 Name(Jcc8Code src)
        => ref _Jcc8Names[(byte)(src - Jcc8Base)];

    [MethodImpl(Inline)]
    public ref readonly asci8 Name(Jcc32Code src)
        => ref _Jcc32Names[(byte)(src - Jcc32Base)];

    [MethodImpl(Inline), Op, Closures(UnsignedInts)]
    static void expressions<T>(Symbols<T> src, Span<asci8> dst)
        where T : unmanaged
    {
        var count = min(src.Length,dst.Length);
        var view = src.View;
        for(var i=0u; i<count; i++)
            seek(dst,i) = src[i].Expr.Format();
    }

    Index<Jcc8Code> _Jcc8Codes;

    Index<Jcc32Code> _Jcc32Codes;

    Index<asci8> _Jcc8Names;

    Index<asci8> _Jcc32Names;

    AsmEncoderData()
    {
        Load();
    }

    void Load()
    {
        var jcc8a = Symbols.index<Jcc8Code>();
        Require.equal(jcc8a.Count, ConditionCount);

        _Jcc8Names = alloc<asci8>(ConditionCount);
        expressions(jcc8a, _Jcc8Names.Edit);

        _Jcc8Codes = alloc<Jcc8Code>(ConditionCount);
        Symbols.kinds(jcc8a, _Jcc8Codes.Edit);

        var jcc32a = Symbols.index<Jcc32Code>();
        Require.equal(jcc32a.Count, ConditionCount);

        _Jcc32Names = alloc<asci8>(ConditionCount);
        expressions(jcc32a, _Jcc32Names.Edit);

        _Jcc32Codes = alloc<Jcc32Code>(ConditionCount);
        Symbols.kinds(jcc32a, _Jcc32Codes.Edit);

    }

    static AsmEncoderData Instance = new();
}
