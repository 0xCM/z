//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using NP = NumericParser;

    public class ValueDynamic
    {
        public static uint parse<T>(ReadOnlySpan<string> src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var counter = 0u;
            var settings = Settings.parse(src, sep);
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
                else if(type == typeof(_FileUri))
                    dst =  FS.uri(src);
                else if(type == typeof(FolderPath))
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
                    if(DataParser.parse(input, out bool value))
                    {
                        dst = generic<T>(value);
                        return true;
                    }
                }
                else if(typeof(T) == typeof(bit))
                {
                    if(DataParser.parse(input, out bit u1))
                    {
                        dst = generic<T>((bool)u1);
                        return true;
                    }
                }
                else if(NP.parse(input, out T g))
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