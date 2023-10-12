//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

/// <summary>
/// mm rrr nnn
/// https://gmail.com
/// </summary>
public struct ModRmSymbolic
{
    public static ModRmSymbolic init()
        => new();

    public struct ModSymbols
    {
        ByteBlock2 Data;

        [MethodImpl(Inline)]
        public ModSymbols(asci2 src)
        {
            Data[0] = src[0];
            Data[1] = src[1];
        }
    }

    public struct RegSymbols
    {
        ByteBlock3 Data;

        [MethodImpl(Inline)]
        public RegSymbols(asci4 src)
        {
            Data[0] = src[0];
            Data[1] = src[1];
            Data[2] = src[2];
        }
    }
    
    public struct RmSymbols
    {
        ByteBlock3 Data;

        [MethodImpl(Inline)]
        public RmSymbols(asci4 src)
        {
            Data[0] = src[0];
            Data[1] = src[1];
            Data[2] = src[2];
        }
    }
    
    public ref ModSymbols Mod
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref @as<ModSymbols>(slice(Data.Bytes,8));
    }

    public ref RegSymbols Reg
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref @as<RegSymbols>(slice(Data.Bytes,4));
    }

    public ref RegSymbols Rm
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref @as<RegSymbols>(Data.Bytes);
    }

    ByteBlock16 Data;

    [MethodImpl(Inline)]
    public ModRmSymbolic()
    {
        Data = ByteBlock16.Empty;
        var i=0u;        
        Data[i++] = AsciSymbols.m;
        Data[i++] = AsciSymbols.m;
        Data[i++] = AsciSymbols.Space;
        Data[i++] = AsciSymbols.r;
        Data[i++] = AsciSymbols.r;
        Data[i++] = AsciSymbols.r;
        Data[i++] = AsciSymbols.Space;
        Data[i++] = AsciSymbols.n;
        Data[i++] = AsciSymbols.n;
        Data[i++] = AsciSymbols.n;
    }

    public ref AsciSymbol this[int i]
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref @as<AsciSymbol>(Data[i]);
    }

    public ref AsciSymbol this[uint i]
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref @as<AsciSymbol>(Data[i]);
    }

    public Span<AsciSymbol> Symbols
    {
        [MethodImpl(Inline), UnscopedRef]
        get => recover<AsciSymbol>(Data.Bytes);
    }

    public string Format()
        => @as<asci16>(Data.Bytes).Format();

    public override string ToString()
        => Format();
}