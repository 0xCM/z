//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class BinaryModels
    {        
        public record class BinaryField<T> : IBinaryField<T>
            where T : BinaryType
        {
            public readonly @string Name;

            public readonly T Type;

            public BinaryField(@string name, T type)
            {
                Name = name;
                Type = type;
            }

            @string IBinaryField.Name 
                => Name;

            T IBinaryField<T>.Type
                => Type;
        }

        public record class AlignedField<T> : BinaryField<T>
            where T : BinaryType
        {
            public AlignedField(@string name, T type, ByteSize alignment)
                : base(name,type)
            {
                Alignment = alignment;
            }

            public readonly ByteSize Alignment;
        }

    }
}