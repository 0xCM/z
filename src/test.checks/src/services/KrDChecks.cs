//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class KrDChecks: Checker<KrDChecks>
    {
        public Outcome CheckSeq8u()
        {
            var result = Outcome.Success;
            var i0 = (byte)0;
            var i1 = (byte)32;
            var j0 = (byte)0;
            var j1 = (byte)32;

            var count = i1*j1;
            var src = KrD.seq(i0, i1, j0, j1);
            if(src.Length != count)
            {
                result = (false, string.Format("{0} != {1}", src.Count, count));
                return result;
            }

            var seq = gcalc.seq(Intervals.lclosed(i0,i1));
            //iter(seq, term => Write(term.Format()));

            return result;
        }
    }
}