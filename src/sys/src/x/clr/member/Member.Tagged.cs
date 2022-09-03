//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether an attribute of specified type is attached to a member
        /// </summary>
        /// <param name="m">The member to test</param>
        /// <param name="tAttrib">The target attribute type</param>
        [MethodImpl(Inline), Op]
        public static bool Tagged(this MemberInfo m, Type tAttrib)
            => System.Attribute.IsDefined(m, tAttrib);

        /// <summary>
        /// Determines whether an attribute is applied to a subject
        /// </summary>
        /// <param name="m">The subject to examine</param>
        /// <typeparam name="T">The type of attribute for which to check</typeparam>
        [MethodImpl(Inline)]
        public static bool Tagged<T>(this MemberInfo m)
            where T : Attribute
                => System.Attribute.IsDefined(m, typeof(T));

        /// <summary>
        /// Returns true if a parametrically-identified attribute is not applied to the subject
        /// </summary>
        /// <param name="m">The subject to examine</param>
        /// <typeparam name="T">The type of attribute for which to check</typeparam>
        [MethodImpl(Inline)]
        public static bool Untagged<T>(this MemberInfo m)
            where T : Attribute
                => !m.Tagged<T>();
    }
}