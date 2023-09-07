//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    sealed class Components : WfAppCmd<Components>
    {
        public static void Main(string[] args)
        {
            term.announce("hello");
            var src = ExecutingPart.Assembly.Types();
            iter(src, a => term.cyan(a.FullName) );
        }
    }        
}
