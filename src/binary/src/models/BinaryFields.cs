//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BinaryModels;

    public class BinaryFields
    {
        public static BinaryField<T> field<T>(string name, T type)        
            where T : IBinaryType
                => new BinaryField<T>(name,type);

        public static AlignedField<T> field<T>(string name, T type, ByteSize alignment)        
            where T : IBinaryType
                => new AlignedField<T>(name,type, alignment);

    }
}