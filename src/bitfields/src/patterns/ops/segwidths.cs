//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static Seq<byte> segwidths(BpExpr src)
    {
        var fields = symbols(src);
        var count = fields.Length;
        var buffer = alloc<byte>(count);
        for(var i=0; i<count; i++)
            seek(buffer,i) = (byte)fields[i].Length;
        return buffer;
    }
}