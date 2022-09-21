//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class DigitParserChecks: Checker<DigitParserChecks>
    {
        public Outcome CheckCases()
            => DigitParserCases.check();
    }
}