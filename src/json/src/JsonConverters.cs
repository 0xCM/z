//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class Json
    {
        public class PathPartConverter : JsonConverter<PathPart>
        {
            public override PathPart Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => new PathPart(reader.GetString());

            public override void Write(Utf8JsonWriter writer, PathPart value, JsonSerializerOptions options)
                => writer.WriteStringValue(value.Format(PathSeparator.FS));
        }
    }

}