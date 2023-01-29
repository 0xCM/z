//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Timing 
    {
        [Parser]
        public static Outcome parse(string src, out Timestamp dst)
        {
            var outcome = Outcome.Empty;
            dst = Timestamp.Zero;
            var dash = text.index(src, Chars.Dash);
            if(dash == NotFound)
                return (false, "Date separator not found");

            var date = dash - 4;
            if(date < 0)
                return (false, $"The date index {date} is negative");

            var dot = text.index(src,Chars.Dot);
            if(dot == NotFound)
                return (false, "Time separator not found");

            var time = dot + 1;
            if(time <= date)
                return (false, $"The time separator index {time} is invalid");

            var seg0 = text.slice(src, date, 10).Split(Chars.Dash);
            if(seg0.Length != 3)
                return (false, $"The date segment has {seg0.Length} segments and should have 3");

            var seg1 = text.slice(src, time + 1).Split(Chars.Dot);

            if(seg1.Length != 4)
                return (false, $"The time segment has {seg1.Length} segments and should have 4");

            if(!NumericParser.parse(skip(seg0,0), out int yyyy))
                return (false, "Attempt to parse year failed");
            if(!NumericParser.parse(skip(seg0,1), out int MM))
                return (false, "Attempt to parse month failed");
            if(!NumericParser.parse(skip(seg0,2), out int dd))
                return (false, "Attempt to parse day failed");
            if(!NumericParser.parse(skip(seg1,0), out int HH))
                return (false, "Attempt to parse hour failed");
            if(!NumericParser.parse(skip(seg1,1), out int mm))
                return (false, "Attempt to parse minutes failed");
            if(!NumericParser.parse(skip(seg1,2), out int ss))
                return (false, "Attempt to parse seconds failed");
            if(!Intervals.parse(skip(seg1,3), (0,999), out int fff, out outcome))
                return outcome;

            dst =  new DateTime(yyyy,MM,dd,HH, mm, ss, fff);

            return true;
        }


    }
}