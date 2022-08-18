//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static string SimpleName(this AssemblyName src)
            => src.FullName.LeftOfFirst(Chars.Comma);
    }
}