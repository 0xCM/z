//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct DataFlowSpec : IComparable<DataFlowSpec>
    {
        const string TableId = "api.dataflows.specs";

        [Render(16)]
        public @string Actor;

        [Render(16)]
        public @string Source;

        [Render(16)]
        public @string Target;

        [Render(1)]
        public @string Description;

        public int CompareTo(DataFlowSpec src)
        {
            var i = Actor.CompareTo(src.Actor);
            if(i==0)
            {
                var j = Source.CompareTo(src.Source);
                if(j==0)
                    return Target.CompareTo(Target);
                else
                    return j;
            }
            else
            {
                return i;
            }
        }        
    }
}