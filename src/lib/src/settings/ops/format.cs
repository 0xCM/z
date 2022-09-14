//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Settings
    {
        public static string format(ISettings src)
        {
            var dst = text.emitter();
            dst.AppendLine($"[{src.Name}]");
            render(src.Lookup,dst);
            return dst.Emit();
        }

        public static string format(Index<Setting> src, char sep)
        {
            var dst = text.emitter();
            iter(src, x => dst.AppendLine(x.Format(sep)));
            return dst.Emit();
        }

        public static string format<T>(in T src, char sep)
            where T : ISettings
        {
            var fields = typeof(T).PublicInstanceFields();
            var count = fields.Length;
            var dst = text.emitter();
            dst.AppendLine($"[{src.Name}]");
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendLineFormat("{0}{1}{2}",field.Name, sep, field.GetValue(src));
            }
            return dst.Emit();
        }

        public static string format<K,V>(K key, V value)
            => string.Format(RP.Setting, key, value);

        public static string format(SettingMembers src, char sep)
        {
            var dst = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var member = ref src[i];
                dst.AppendLine($"{member.Name}{sep}{member.FieldType.DisplayName()}");
            }

            return dst.Emit();
        }
    }
}