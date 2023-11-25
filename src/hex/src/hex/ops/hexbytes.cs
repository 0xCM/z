//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Hex
{
    /// <summary>
    /// Parses a sequence of hex bytes, delimited by a space or comma
    /// </summary>
    /// <param name="src">The source</param>
    /// <param name="dst">The target</param>
    [Op]
    public static Outcome hexbytes(string src, out BinaryCode dst)
    {
        dst = BinaryCode.Empty;
        var result = Outcome.Success;
        if(empty(src))
            return result;

        var sep = delimiter(src);
        var parts = src.Replace(CharText.EOL, CharText.Space).SplitClean(sep).ToReadOnlySpan();
        var count = parts.Length;
        var buffer = alloc<byte>(count);
        ref var target = ref first(buffer);
        for(var i=0; i<count; i++)
        {
            ref readonly var part = ref skip(parts,i);
            result = parse8u(part, out seek(target,i));
            if(result.Fail)
            {
                result = (false, HexParseFailure.Format(part));
                return result;
            }
        }
        dst = buffer;
        return result;
    }

    [Op]
    static Outcome<uint> hexbytes(string src, Span<byte> dst)
    {
        var size = 0u;
        var limit = (uint)dst.Length;
        var result = Outcome.Success;
        if(empty(src))
            return size;
        var sep = delimiter(src);
        var parts = src.Replace(CharText.EOL, CharText.Space).SplitClean(sep).ToReadOnlySpan();
        var count = src.Length;
        for(var i=0u; i<count && i<limit; i++)
        {
            ref readonly var part = ref skip(parts,i);
            result = parse8u(part, out seek(dst,i));
            if(result.Fail)
                return (false,size);
            else
                size++;
        }
        return size;
    }

    static MsgPattern<string> HexParseFailure
        => "The value '{0}' could not be parsed as a hex number";
}