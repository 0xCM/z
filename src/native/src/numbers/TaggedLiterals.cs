//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public static class TaggedLiterals
    {
        public static Index<BinaryLiteral<T>> binary<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
                => from f in typeof(E).LiteralFields().ToArray()
                    where f.Tagged<BinaryLiteralAttribute>()
                    let a = f.Tag<BinaryLiteralAttribute>().Require()
                    select BinaryLiteral.define(base2, f.Name, Enums.scalar<E,T>((E)f.GetValue(null)), a.Text);

        public static NumericLiteral binaryliteral(FieldInfo target, object value)
        {
            if(!IsBinaryLiteral(target))
                return NumericLiteral.Empty;
            return NumericLiterals.numeric(base2, target.Name, value, target.Tag<BinaryLiteralAttribute>().Value.Text);
        }

        [MethodImpl(Inline), Op]
        public static LiteralInfo describe(string Name, object Data, string Text, TypeCode TypeCode, bool IsEnum, bool MultiLiteral)
            => new LiteralInfo(Name,Data, Text, TypeCode, IsEnum, MultiLiteral);

        /// <summary>
        /// Describes a literal field tagged with a <see cref='MultiLiteralAttribute'/> along with text that ought to be the render resule of the described literal
        /// </summary>
        /// <param name="src">The source field</param>
        /// <param name="text">The expeced render value</param>
        [MethodImpl(Inline), Op]
        public static LiteralInfo polymorphic(FieldInfo src, string text)
            => describe(
                Name: src.Name,
                Data: src.GetRawConstantValue(),
                Text: text,
                TypeCode: Type.GetTypeCode(src.FieldType),
                IsEnum: src.FieldType.IsEnum,
                MultiLiteral: true
                );


        /// <summary>
        /// Describes a literal field tagged with a <see cref='MultiLiteralAttribute'/>
        /// </summary>
        /// <param name="src">The source field</param>
        [Op]
        public static LiteralInfo polymorphic(FieldInfo src)
            => src.Tag<MultiLiteralAttribute>().MapValueOrDefault(tag => polymorphic(src, tag.Data), LiteralInfo.Empty);

        /// <summary>
        /// Tests whether a specified field is tagged with a <see cref='BinaryLiteralAttribute'/>
        /// </summary>
        /// <param name="src">The field to test</param>
        public static bool IsBinaryLiteral(FieldInfo src)
            => Attribute.IsDefined(src, typeof(BinaryLiteralAttribute));

        /// <summary>
        /// Tests whether a specified field is tagged with a <see cref='MultiLiteralAttribute'/>
        /// </summary>
        /// <param name="src">The field to test</param>
        public static bool IsMultiLiteral(FieldInfo src)
            => Attribute.IsDefined(src, typeof(MultiLiteralAttribute));
    }
}