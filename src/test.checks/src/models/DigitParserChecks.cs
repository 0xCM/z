//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class DigitParserChecks: Checker<DigitParserChecks>
    {
        public Outcome CheckCases()
            => DigitParserCases.check();
    }
}