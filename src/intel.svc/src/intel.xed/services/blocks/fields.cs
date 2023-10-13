//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedZ
{        
    public static IEnumerable<BlockField> fields(InstBlockLineSpec src)
    {
        var field = BlockField.Empty;
        foreach(var line in src.Lines.Storage)
            if(parse(line, out field))
                yield return field;
    }
}