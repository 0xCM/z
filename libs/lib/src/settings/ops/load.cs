//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;

    partial class Settings
    {
        public static T load<T>(FilePath src)
            where T : ISettings<T>, new()
                => load<T>(lookup(src, Chars.Eq));

        public static T load<T>(SettingLookup src)
            where T : new()
        {
            var dst = new T();
            var members = Settings.members<T>();
            for(var i=0; i<members.Count; i++)
            {
                ref readonly var member = ref members[i];
                if(src.Find(member.Name, out var setting))
                {
                    member.SetValue(dst, setting.Value);
                }
            }

            return dst;
        }

        public static uint load(ref AsciLineReader src, Type type, char sep, out object dst)
        {
            dst = Activator.CreateInstance(type);
            var counter = 0u;
            var line = AsciLineCover.Empty;
            var members = Settings.members(type);
            while(src.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var data = SQ.right(content,i);
                        if(members.Member(name, out var field))
                        {
                            if(parse(Asci.format(data), field.FieldType, out var value))
                            {
                                field.SetValue(dst,value);
                                counter++;
                            }
                        }
                    }
                }
            }

            return counter;
        }

        public static uint load<T>(ref AsciLineReader src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var counter = 0u;
            var line = AsciLineCover.Empty;
            var members = Settings.members<T>();
            while(src.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var data = SQ.right(content,i);
                        if(members.Member(name, out var field))
                        {
                            if(parse(Asci.format(data), field.FieldType, out var value))
                            {
                                field.SetValue(dst,value);
                                counter++;
                            }
                        }
                    }
                }
            }

            return counter;
        }
    }
}