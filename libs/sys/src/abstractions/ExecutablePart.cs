//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ExecutablePart<P> : Part<P>, IExecutablePart<P>
        where P : Part<P>, IExecutablePart<P>, new()
    {
        public static void RunPart(params string[] args)
            => new P().Execute(args);
        
        public abstract void Execute(params string[] args);
    }
}