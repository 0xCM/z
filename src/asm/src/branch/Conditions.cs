//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static ConditionTokens;
using static ConditionTokens.ConditionFacets;

[ApiComplete]
public sealed class Conditions
{
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static JccInfo<K> jcc<K>(K kind, asci8 name, NativeSize size)
        where K : unmanaged
            => new JccInfo<K>(kind, name, size);

    public static Conditions create()
        => _Instance.Value;

    [Op]
    public static string format(in Jcc8Conditions src)
    {
        const string Pattern = "{0,-4} rel{1} [{2}:{3}b] => {4}";
        var dst = EmptyString;
        dst = string.Format(Pattern, src.Definition.Name, src.RelWidth, HexFormatter.asmhex(src.Encoding), text.format(src.Bitstring), src.Description);
        return dst;
    }

    [Op]
    public static string format(in Jcc32Conditions src)
    {
        const string Pattern = "{0,-4} rel{1} [{2}:{3}b] => {4}";
        var dst = EmptyString;
        dst = string.Format(Pattern, src.Definition.Name, src.RelWidth, HexFormatter.asmhex(src.Encoding), text.format(src.Bitstring), src.Description);
        return dst;
    }

    public static ReadOnlySpan<Jcc8Conditions> jcc8()
    {
        var conditions = create();
        var buffer = alloc<Jcc8Conditions>(32);
        var count = jcc8(conditions,buffer);
        var output = slice(span(buffer),0, count);
        return output;
    }

    [Op]
    public static uint jcc8(Conditions src, Span<Jcc8Conditions> dst)
    {
        var codes = src.JccCodes(w8, n0);
        var count = codes.Length;
        var counter = 0u;
        for(var i=0; i<count; i++)
        {
            ref readonly var code = ref skip(codes,i);
            ref readonly var name = ref src.Name(code);
            ref readonly var info = ref src.Describe(code);
            ref var target = ref seek(dst,counter++);
            target.Definition = jcc(code, name, NativeSizeCode.W8);
            target.Description = info.Text;
        }
        return (uint)count;
    }

    public static ReadOnlySpan<Jcc32Conditions> jcc32()
    {
        var conditions = create();
        var buffer = alloc<Jcc32Conditions>(32);
        var count = jcc32(conditions,buffer);
        var output = slice(span(buffer),0, count);
        return output;
    }

    [Op]
    public static uint jcc32(Conditions src, Span<Jcc32Conditions> dst)
    {
        var codes = src.JccCodes(w32, n0);
        var count = codes.Length;
        var counter = 0u;
        for(var i=0; i<count; i++)
        {
            ref readonly var code = ref skip(codes,i);
            ref readonly var name = ref src.Name(code);
            ref readonly var info = ref src.Describe(code);
            ref var target = ref seek(dst,counter++);
            target.Definition = jcc(code, name, NativeSizeCode.W32);
            target.Description = info.Text;
        }
        return (uint)count;
    }

    static Lazy<Conditions> _Instance;

    static Conditions()
    {
        _Instance = new Lazy<Conditions>(() => new Conditions());
    }

    Index<Condition> _CC;

    Index<Jcc8Code> _Jcc8Codes;

    Index<Jcc32Code> _Jcc32Codes;

    Index<asci8> _ConditionNames;

    Index<TextBlock> _ConditionInfo;

    Index<TextBlock> _Jcc8Info;

    Index<asci8> _Jcc8Names;

    Index<asci8> _Jcc32Names;

    Index<TextBlock> _Jcc32Info;


    Conditions()
    {
        Alloc();
        Load();
    }

    void Alloc()
    {
        _CC = alloc<Condition>(ConditionCount);

        _ConditionNames = alloc<asci8>(ConditionCount);
        _ConditionInfo = alloc<TextBlock>(ConditionCount);
        _Jcc8Codes = alloc<Jcc8Code>(ConditionCount);
        _Jcc32Codes = alloc<Jcc32Code>(ConditionCount);

        _Jcc8Names = alloc<asci8>(ConditionCount);
        _Jcc32Names = alloc<asci8>(ConditionCount);

        _Jcc8Info = alloc<TextBlock>(ConditionCount);
        _Jcc32Info = alloc<TextBlock>(ConditionCount);
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    static void expressions<T>(Symbols<T> src, Span<asci8> dst)
        where T : unmanaged
    {
        var count = min(src.Length,dst.Length);
        var view = src.View;
        for(var i=0u; i<count; i++)
            seek(dst,i) = src[i].Expr.Format();
    }
        
    void Load()
    {
        var ccA = Symbols.index<Condition>();
        Require.equal((uint)ccA.Length, ConditionCount);
        expressions(ccA, _ConditionNames.Edit);
        Symbols.descriptions(ccA, _ConditionInfo.Edit);
        Symbols.kinds(ccA, _CC.Edit);

        var jcc8a = Symbols.index<Jcc8Code>();
        Require.equal(jcc8a.Count, ConditionCount);
        expressions(jcc8a, _Jcc8Names.Edit);
        Symbols.descriptions(jcc8a, _Jcc8Info.Edit);
        Symbols.kinds(jcc8a, _Jcc8Codes.Edit);

        var jcc32a = Symbols.index<Jcc32Code>();
        Require.equal(jcc32a.Count, ConditionCount);
        expressions(jcc32a, _Jcc32Names.Edit);
        Symbols.descriptions(jcc32a, _Jcc32Info.Edit);
        Symbols.kinds(jcc32a, _Jcc32Codes.Edit);

    }

    [MethodImpl(Inline)]
    public ReadOnlySpan<Condition> ConditionCodes(N0 n)
        => _CC.View;

    [MethodImpl(Inline)]
    public ReadOnlySpan<Jcc8Code> JccCodes(W8 w, N0 n)
        => _Jcc8Codes.View;

    [MethodImpl(Inline)]
    public ReadOnlySpan<Jcc32Code> JccCodes(W32 w, N0 n)
        => _Jcc32Codes.View;

    [MethodImpl(Inline)]
    public ref readonly asci8 Name(Condition src)
        => ref _ConditionNames[(byte)src];

    [MethodImpl(Inline)]
    public ref readonly TextBlock Describe(Condition src)
        => ref _ConditionInfo[(byte)src];

    [MethodImpl(Inline)]
    public ref readonly asci8 Name(Jcc8Code src)
        => ref _Jcc8Names[(byte)(src - Jcc8Base)];

    [MethodImpl(Inline)]
    public ref readonly TextBlock Describe(Jcc8Code src)
        => ref _Jcc8Info[(byte)(src - Jcc8Base)];

    [MethodImpl(Inline)]
    public ref readonly asci8 Name(Jcc32Code src)
        => ref _Jcc32Names[(byte)(src - Jcc32Base)];

    [MethodImpl(Inline)]
    public ref readonly TextBlock Describe(Jcc32Code src)
        => ref _Jcc32Info[(byte)(src - Jcc32Base)];
}
