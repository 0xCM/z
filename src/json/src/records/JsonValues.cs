//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static JsonPrimitives;
    using static JsonRecords;

    [ApiHost]
    public class JsonValues
    {
        public static Seq<JsonValue> seq(uint count)
            => sys.alloc<JsonValue>(count);

        [Op]
        public static FieldValue<I8,sbyte> i8(sbyte value)
            => value;

        [Op]
        public static FieldValue<U8,byte> u8(byte value)
            => value;

        [Op]
        public static FieldValue<U8,short> i16(short value)
            => value;

        [Op]
        public static FieldValue<U8,ushort> u16(ushort value)
            => value;

        public static FieldValue<Text,JsonText> text(string value)
            => new JsonText(value);
    }
}