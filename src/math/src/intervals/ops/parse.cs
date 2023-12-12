//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Intervals
{
    [Op]
    public static bool parse(string src, ClosedInterval<int> bounds, out int dst, out Outcome outcome)
    {
        outcome = NumericParser.parse(src, out dst);
        if(!outcome)
            return false;

        if(!contains(bounds, dst))
        {
            outcome = (false, $"The parsed value {dst} is not with the required range {bounds}");
            return false;
        }
        return true;
    }
}
