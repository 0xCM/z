//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    using DP = DataParser;
    using NP = NumericParser;

    partial class Settings
    {
        public static uint parse<T>(ReadOnlySpan<string> src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var counter = 0u;
            var settings = parse(src, sep);
            var fields = typeof(T).PublicInstanceFields().Select(x => (x.Name,x)).ToDictionary();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                if(setting.IsEmpty)
                    continue;

                if(fields.TryGetValue(setting.Name, out var field))
                {
                    if(parse(setting.ValueText, field.FieldType, out var x))
                    {
                        field.SetValue(dst, x);
                        counter++;
                    }
                }
            }
            return counter;
        }

        public static Setting parse(string src, char sep)
        {
            var i = text.index(src, sep);
            var setting = Setting.Empty;
            if(i > 0)
                setting = new Setting(text.trim(text.left(src, i)), text.trim(text.right(src, i)));
            return setting;
        }

        [Op]
        public static SettingLookup parse(ReadOnlySpan<string> src, char sep)
        {
            var count = src.Length;
            var dst = sys.alloc<Setting>(count);
            for(var i=0; i<count; i++)
                seek(dst, i) = parse(skip(src,i), sep);
            return new (dst);
        }

        [Parser]
        public static Outcome parse(string src, char sep, out Setting<string> dst)
        {
            if(sys.empty(src))
            {
                dst = default;
                return (false, "!!Empty!!");
            }
            else
            {
                var i = src.IndexOf(sep);
                if(i == NotFound)
                {
                    dst = default;
                    return (false, "Setting delimiter not found");
                }
                else
                {
                    if(i == 0)
                        dst = new Setting<string>(EmptyString, text.slice(src,i+1));
                    else
                        dst = new Setting<string>(text.slice(src,0, i), text.slice(src,i+1));
                    return true;
                }
            }
        }

        [Op]
        public static SettingLookup parse(ReadOnlySpan<TextLine> src, char sep)
        {
            var count = src.Length;
            var buffer = span<Setting>(count);
            ref var dst = ref first(buffer);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var content = line.Content;
                var j = text.index(content, sep);
                if(j > 0)
                {
                    var name = text.left(content, j).Trim();
                    var value = text.right(content, j).Trim();
                    seek(dst, counter++) = new Setting(name, value);
                }
            }
            return new(slice(buffer,0,counter).ToArray());
        }

        public static bool parse(string src, Type type, out dynamic? dst)
        {
            dst = null;
            if(nonempty(src))
            {
                var input = src;
                if(type == typeof(string))
                {
                    dst = input;
                }
                else if (type == typeof(bool))
                {
                    if(BitParser.semantic(input, out bit x))
                        dst = (bool)x;
                }                
                else if(type == typeof(bit))
                {
                    if(BitParser.parse(input, out bit x))
                        dst = x;
                }
                else if(type == typeof(FilePath))
                    dst = FS.path(src);
                else if(type == typeof(FileUri))
                    dst =  FS.uri(src);
                else if(type == typeof(FS.FolderPath))
                    dst = FS.dir(src);
                else if(type.IsPrimalNumeric())
                    numeric(input, type, out dst);
                else if(type.IsEnum)
                {
                    if(Enums.parse(type, src, out object x))
                    {
                        dst = x;
                    }
                }
                else if(src.Length == 1 && type == typeof(char))
                    dst = src[0];
            }
            return dst != null;
        }

        static bool numeric(string src, Type type, out dynamic? dst)
        {
            dst = null;
            if(type.IsUInt8())
            {
                if(NP.parse(src, out byte x))
                    dst = x;
            }
            else if(type.IsInt8())
            {
                if(NP.parse(src, out sbyte x))
                    dst = x;
            }
            else if(type.IsInt16())
            {
                if(NP.parse(src, out short x))
                    dst = x;
            }
            else if(type.IsUInt16())
            {
                if(NP.parse(src, out ushort x))
                    dst = x;
            }
            else if(type.IsUInt32())
            {
                if(NP.parse(src, out uint x))
                    dst = x;
            }
            else if(type.IsInt32())
            {
                if(NP.parse(src, out int x))
                    dst = x;
            }
            else if(type.IsUInt64())
            {
                if(NP.parse(src, out ulong x))
                    dst = x;
            }
            else if(type.IsInt64())
            {
                if(NP.parse(src, out long x))
                    dst = x;
            }
            else if(type.IsFloat32())
            {
                if(NP.parse(src, out float x))
                    dst = x;
            }
            else if(type.IsFloat64())
            {
                if(NP.parse(src, out double x))
                    dst = x;
            }
            return dst != null;
        }
        public static bool parse<T>(string src, char sep, out T dst)
        {
            dst = Setting<T>.Empty;
            if(nonempty(src))
            {
                var name = EmptyString;
                var input = src;
                if(SQ.contains(src, sep))
                {
                    name = src.LeftOfFirst(sep);
                    input = src.RightOfFirst(sep);
                }

                if(typeof(T) == typeof(string))
                {
                    dst = generic<T>(input);
                    return true;
                }
                else if (typeof(T) == typeof(bool))
                {
                    if(DP.parse(input, out bool value))
                    {
                        dst = generic<T>(value);
                        return true;
                    }
                }
                else if(typeof(T) == typeof(bit))
                {
                    if(DP.parse(input, out bit u1))
                    {
                        dst = generic<T>((bool)u1);
                        return true;
                    }
                }
                else if(DP.numeric(input, out T g))
                {
                    dst = g;
                    return true;
                }
                else if(typeof(T).IsEnum)
                {
                    if(Enums.parse(typeof(T), src, out object o))
                    {
                        dst =(T)o;
                        return true;
                    }
                }
                else if(src.Length == 1 && typeof(T) == typeof(char))
                {
                    dst = generic<T>(name[0]);
                    return true;
                }
            }
            return false;
        }


    }
}