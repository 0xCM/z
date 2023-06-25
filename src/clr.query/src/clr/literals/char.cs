//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static char @char(FieldInfo f)
            => (char)f.GetRawConstantValue();
    }
}