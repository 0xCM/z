//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static XedRules;
using static sys;

using N = XedZ.BlockFieldName;

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