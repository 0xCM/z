//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
       public static string fence(string src, Fence<char> fence)
            => $"{fence.Left}{src}${fence.Right}";
    }
}