//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl
{
    using static sys;
    using static intel.TypeNames;
    using static NativeTypes;
    
    public readonly struct Types
    {
        public const string @char = "char";

        public const string @short = "short";

        public const string @int = "int";

        public const string @long = "long";

        public const string size_t = nameof(size_t);

        public const string @float = "float";

        public const string @double = "double";

        public const string @void = "void";

        public const string unsigned = "unsigned";

        public static NativeTypeMap map()
            => NativeTypeMap.build(intrinsics);

        static void intrinsics(NativeTypeMap.MapBuilder map)
        {
            map.Map(__int8, i8());
            map.Map(__int16, i16());
            map.Map(__int32, i32());
            map.Map(__int64, i64());
            map.Map(__uint8, u8());
            map.Map(__uint16, u16());
            map.Map(__uint32, u32());
            map.Map(__uint64, u64());
            map.Map(__tile, i32());

            map.Map(__mmask8, u8());
            map.Map(__mmask16, u16());
            map.Map(__mmask32, u32());
            map.Map(__mmask64, u64());

            map.Map(__m64, i64());

            map.Map(__m128i, i128());
            map.Map(__m128, seg128x32f());
            map.Map(__m128bh, seg128x16f());
            map.Map(__m128d, seg128x64f());

            map.Map(__m256i, i256());
            map.Map(__m256bh, seg256x16f());
            map.Map(__m256, seg256x32f());
            map.Map(__m256d, seg256x64f());

            map.Map(__m512, seg512x32f());
            map.Map(__m512i, i512());
            map.Map(__m512d, seg512x64f());
            map.Map(__m512bh, seg512x16f());

            map.Map(unsigned, u32());
            map.Map(size_t, u64());
            map.Map(@char, i8());
            map.Map(@short, i16());
            map.Map(@int, i32());
            map.Map(@long, i64());
            map.Map(@float, f32());
            map.Map(@double, f64());
            map.Map(@void, @void());
        }
    }
}