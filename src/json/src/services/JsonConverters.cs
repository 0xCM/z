//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class JsonConverters
    {
        public static void register(IEnumerable<JsonConverter> src)
            => Converters.AddRange(src);

        public static void register(params JsonConverter[] src)
            => Converters.AddRange(src);

        public static JsonSerializerOptions coverters(JsonSerializerOptions dst)
        {
            sys.iter(Converters, converter => dst.Converters.Add(converter));
            return dst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>
        /// Adapted from https://github.com/dotnet/runtime/blob/6de7147b9266d7730b0d73ba67632b0c198cb11e/src/libraries/System.Text.Json/src/System/Text/Json/Nodes/JsonValueOfT.cs
        /// </remarks>
        public static T convert<T>(object src)
        {
            if(src is JsonElement e)
            {
                switch (e.ValueKind)
                {
                    case JsonValueKind.Number:
                        if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                        {
                            return (T)(object)e.GetInt32();
                        }

                        if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                        {
                            return (T)(object)e.GetInt64();
                        }

                        if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                        {
                            return (T)(object)e.GetDouble();
                        }

                        if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
                        {
                            return (T)(object)e.GetInt16();
                        }

                        if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
                        {
                            return (T)(object)e.GetDecimal();
                        }

                        if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
                        {
                            return (T)(object)e.GetByte();
                        }

                        if (typeof(T) == typeof(float) || typeof(T) == typeof(float?))
                        {
                            return (T)(object)e.GetSingle();
                        }

                        if (typeof(T) == typeof(uint) || typeof(T) == typeof(uint?))
                        {
                            return (T)(object)e.GetUInt32();
                        }

                        if (typeof(T) == typeof(ushort) || typeof(T) == typeof(ushort?))
                        {
                            return (T)(object)e.GetUInt16();
                        }

                        if (typeof(T) == typeof(ulong) || typeof(T) == typeof(ulong?))
                        {
                            return (T)(object)e.GetUInt64();
                        }

                        if (typeof(T) == typeof(sbyte) || typeof(T) == typeof(sbyte?))
                        {
                            return (T)(object)e.GetSByte();
                        }
                        break;

                    case JsonValueKind.String:
                        if (typeof(T) == typeof(string))
                        {
                            return (T)(object)e.GetString()!;
                        }

                        if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                        {
                            return (T)(object)e.GetDateTime();
                        }

                        if (typeof(T) == typeof(DateTimeOffset) || typeof(T) == typeof(DateTimeOffset?))
                        {
                            return (T)(object)e.GetDateTimeOffset();
                        }

                        if (typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?))
                        {
                            return (T)(object)e.GetGuid();
                        }

                        if (typeof(T) == typeof(char) || typeof(T) == typeof(char?))
                        {
                            string? str = e.GetString();
                            Debug.Assert(str != null);
                            if (str.Length == 1)
                            {
                                return (T)(object)str[0];
                            }
                        }
                        break;

                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                        {
                            return (T)(object)e.GetBoolean();
                        }
                        break;
                }
            }

            return Unsupported.raise<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>
        /// Adapted from https://github.com/dotnet/runtime/blob/6de7147b9266d7730b0d73ba67632b0c198cb11e/src/libraries/System.Text.Json/src/System/Text/Json/Nodes/JsonValueOfT.cs
        /// </remarks>
        public static bool convert<T>(object src, out T dst)
        {
            bool success;
            if(src is JsonElement e)
            {
                var element = (JsonElement)src;
                switch (element.ValueKind)
                {
                    case JsonValueKind.Number:
                        if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                        {
                            success = element.TryGetInt32(out int value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                        {
                            success = element.TryGetInt64(out long value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                        {
                            success = element.TryGetDouble(out double value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
                        {
                            success = element.TryGetInt16(out short value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
                        {
                            success = element.TryGetDecimal(out decimal value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
                        {
                            success = element.TryGetByte(out byte value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(float) || typeof(T) == typeof(float?))
                        {
                            success = element.TryGetSingle(out float value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(uint) || typeof(T) == typeof(uint?))
                        {
                            success = element.TryGetUInt32(out uint value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(ushort) || typeof(T) == typeof(ushort?))
                        {
                            success = element.TryGetUInt16(out ushort value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(ulong) || typeof(T) == typeof(ulong?))
                        {
                            success = element.TryGetUInt64(out ulong value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(sbyte) || typeof(T) == typeof(sbyte?))
                        {
                            success = element.TryGetSByte(out sbyte value);
                            dst = (T)(object)value;
                            return success;
                        }
                        break;

                    case JsonValueKind.String:
                        if (typeof(T) == typeof(string))
                        {
                            string? strResult = element.GetString();
                            Debug.Assert(strResult != null);
                            dst = (T)(object)strResult;
                            return true;
                        }

                        if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                        {
                            success = element.TryGetDateTime(out DateTime value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(DateTimeOffset) || typeof(T) == typeof(DateTimeOffset?))
                        {
                            success = element.TryGetDateTimeOffset(out DateTimeOffset value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?))
                        {
                            success = element.TryGetGuid(out Guid value);
                            dst = (T)(object)value;
                            return success;
                        }

                        if (typeof(T) == typeof(char) || typeof(T) == typeof(char?))
                        {
                            string? str = element.GetString();
                            Debug.Assert(str != null);
                            if (str.Length == 1)
                            {
                                dst = (T)(object)str[0];
                                return true;
                            }
                        }
                        break;

                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                        {
                            dst = (T)(object)element.GetBoolean();
                            return true;
                        }
                        break;
                }
            }
            dst = default!;
            return false;
        }

        class BitWidthTransform : JsonTransform<BitWidth>
        {
            protected override BitWidth Read(ref Utf8JsonReader src) 
            {
                var dst = BitWidth.Zero;
                Sizes.parse(src.GetString(), out dst);
                return dst;            
            }

            protected override void Write(BitWidth src, Utf8JsonWriter dst) 
                => dst.WriteStringValue(src.Content.ToString());
        }        

        class ByteSizeTransform : JsonTransform<ByteSize>
        {
            protected override ByteSize Read(ref Utf8JsonReader src) 
            {
                var dst = ByteSize.Zero;
                Sizes.parse(src.GetString(), out dst);
                return dst;            
            }

            protected override void Write(ByteSize src, Utf8JsonWriter dst) 
                => dst.WriteStringValue(src.Content.ToString());
        }        

        class StringTransform : JsonTransform<@string>
        {
            protected override @string Read(ref Utf8JsonReader src) 
                => src.GetString();

            protected override void Write(@string src, Utf8JsonWriter dst) 
                => dst.WriteStringValue(src);
        }        

        class FilePathTransform : JsonTransform<FilePath>
        {
            protected override FilePath Read(ref Utf8JsonReader src) 
                => FS.path(src.GetString());

            protected override void Write(FilePath src, Utf8JsonWriter dst) 
                => dst.WriteStringValue(src.Format(PathSeparator.FS));
        }        

        class FileUriTransform : JsonTransform<FileUri>
        {
            protected override FileUri Read(ref Utf8JsonReader src) 
                => new FileUri(src.GetString());

            protected override void Write(FileUri src, Utf8JsonWriter dst) 
                => dst.WriteStringValue(src.Format());
        }        

        class FolderPathTransform : JsonTransform<FolderPath>
        {
            protected override FolderPath Read(ref Utf8JsonReader src) 
                => FS.dir(src.GetString());

            protected override void Write(FolderPath src, Utf8JsonWriter dst) 
                => dst.WriteStringValue(src.Format(PathSeparator.FS));
        }        

        class AssemblyVersionTransform : JsonTransform<AssemblyVersion>
        {
            protected override AssemblyVersion Read(ref Utf8JsonReader src)             
            {
                throw no<AssemblyVersion>();

            }

            protected override void Write(AssemblyVersion src, Utf8JsonWriter dst) 
            {
                dst.WritePropertyName(nameof(src.Major));
                dst.WriteNumberValue(src.Major);
                dst.WritePropertyName(nameof(src.Minor));
                dst.WriteNumberValue(src.Minor);
                dst.WritePropertyName(nameof(src.Build));
                dst.WriteNumberValue(src.Build);
                dst.WritePropertyName(nameof(src.Revision));
                dst.WriteNumberValue(src.Revision);
            }
        }        

        static JsonConverters()
        {
            register(new StringTransform());
            register(new FilePathTransform());
            register(new FolderPathTransform());
            register(new BitWidthTransform());
            register(new ByteSizeTransform());
            register(new FileUriTransform());
            register(new AssemblyVersionTransform());
        }

        static List<JsonConverter> Converters = new();
    }    
}