//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Nasm
    {
        [MethodImpl(Inline), Op]
        public static NasmListLineKind kind(in NasmListEntry src)
        {
            var kind = NasmListLineKind.None;
            if(src.Encoding.IsNonEmpty)
                kind = NasmListLineKind.Encoding;
            else if(src.Label.IsNonEmpty)
                kind = NasmListLineKind.Label;
            return kind;
        }
    }
}