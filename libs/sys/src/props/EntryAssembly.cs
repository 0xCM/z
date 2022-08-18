//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        public static Assembly EntryAssembly
        {
            [MethodImpl(Options), Op]
            get => Assembly.GetCallingAssembly();
        }
    }
}