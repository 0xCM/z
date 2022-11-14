//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct DataFlowSpec : IComparable<DataFlowSpec>
    {
        public const string TableId = "api.dataflow.specs";

        public const byte FieldCount = 4;

        [Render(16)]
        public Actor Actor;

        [Render(16)]
        public string Source;

        [Render(16)]
        public string Target;

        [Render(1)]
        public string Description;

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

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,16,16,1};
    }
}