//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    [ApiHost]
    public class CalcBuilder : AppService<CalcBuilder>
    {
        public static ClassChecks Checks(IWfRuntime wf) 
            => ClassChecks.create(wf);

        public class ClassChecks : Checker<ClassChecks>
        {
        }

        const NumericKind Closure = Integers;

        ByteSize BlockSize;

        public CalcBuilder()
        {
        }

    }
}