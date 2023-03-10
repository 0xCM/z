//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public class Types
    {
        public abstract record class DataType
        {
            public readonly @string Name;

            protected DataType(@string name)
            {
                Name = name;
            }
        }

        public abstract record class SegmentType : DataType
        {
            protected SegmentType(@string name)
                : base(name)
            {
                
            }
        }

        public record class Stream : DataType
        {
            public Stream(@string name)
                : base(name)
            {

            }
        }

        public record class Aligned : SegmentType
        {
            public Aligned(@string name, ByteSize aligment)
                : base(name)
            {
                Alignment = aligment;
            }

            public readonly ByteSize Alignment;           
        }
    }
}