//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    partial struct Tables
    {
        [Free]
        public delegate Outcome RowParser<T>(string src, out T dst)
            where T : struct;
    }
}