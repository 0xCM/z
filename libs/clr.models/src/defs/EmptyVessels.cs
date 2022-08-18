//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ReflectionFlags;

    [ApiComplete]
    public readonly struct EmptyVessels
    {
        const byte _EmptyField = 0;

        static void _EmptyMethod() { }

        static byte _EmptyProp
            => _EmptyField;

        struct _EmptyStruct { }

        class _EmptyClass {}

        enum _EmptyEnum {}

        static Type VesselType
            => typeof(EmptyVessels);

        public static FieldInfo EmptyField
        {
            [MethodImpl(Inline)]
            get  => VesselType.GetFields(BF_All)[0];
        }

        public static Type EmptyStruct
        {
            [MethodImpl(Inline)]
            get => VesselType.GetNestedTypes()[0];
        }

        public static Type EmptyClass
        {
            [MethodImpl(Inline)]
            get => VesselType.GetNestedTypes()[1];
        }

        public static Type EmptyEnum
        {
            [MethodImpl(Inline)]
            get => VesselType.GetNestedTypes()[2];
        }

        public static Type EmptyType
        {
            [MethodImpl(Inline)]
            get => EmptyClass;
        }

        public static MethodInfo EmptyMethod
        {
            [MethodImpl(Inline)]
            get => VesselType.GetMethods(BF_All)[0];
        }

        [MethodImpl(Inline)]
        public static bool IsEmpty(FieldInfo src)
            => EmptyField.MetadataToken == src.MetadataToken;

        [MethodImpl(Inline)]
        public static bool IsNonEmpty(FieldInfo src)
            => EmptyField.MetadataToken != src.MetadataToken;

        [MethodImpl(Inline)]
        public static bool IsEmpty(Type src)
            => EmptyStruct.MetadataToken == src.MetadataToken;

        [MethodImpl(Inline)]
        public static bool IsNonEmpty(Type src)
            => EmptyStruct.MetadataToken != src.MetadataToken;

        [MethodImpl(Inline)]
        public static bool IsEmpty(MethodInfo src)
            => EmptyMethod.MetadataToken == src.MetadataToken;
    }
}