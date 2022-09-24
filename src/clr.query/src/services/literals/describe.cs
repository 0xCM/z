//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static LiteralInfo describe(string Name, object Data, string Text, TypeCode TypeCode, bool IsEnum, bool MultiLiteral)
            => new LiteralInfo(Name,Data, Text, TypeCode, IsEnum, MultiLiteral);
    }
}