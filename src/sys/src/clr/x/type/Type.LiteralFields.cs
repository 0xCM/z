//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ReflectionFlags;

    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// Queries the source <see cref='Type'/> for <see cref='FieldInfo'/> members determined by the
        /// <see cref='BF_Declared'/> flags where <see cref='FieldInfo.IsLiteral'/> is true
        /// </summary>
        /// <param name="src">The source type</param>
        [Op]
        public static FieldInfo[] LiteralFields(this Type src)
            => src.GetFields(BF_Declared).Where(f => f.IsLiteral && f.Untagged<IgnoreAttribute>()).ToArray();

        /// <summary>
        /// Queries the source <see cref='Type'/> for <see cref='FieldInfo'/> members determined by the
        /// <see cref='BF_Declared'/> flags where <see cref='FieldInfo.IsLiteral'/> is true with field types that match
        /// a specified type
        /// </summary>
        /// <param name="src">The source type</param>
        /// <param name="match">The literal field type to match</param>
        [Op]
        public static FieldInfo[] LiteralFields(this Type src, Type match)
            => src.GetFields(BF_Declared).Where(f => f.IsLiteral && f.FieldType == match).ToArray();

        public static bool LiteralField(this Type src, string name, out FieldInfo field)
        {
            var result = src.GetFields(BF_Declared).Where(x => x.IsLiteral && x.Name == name).ToArray();
            if(result.Length != 0)
            {
                field = result[0];
            }
            else
            {
                field = null;
            }
            return field != null;
        }
    }
}