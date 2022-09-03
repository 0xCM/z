//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static MemberInfo member(Module src, CliToken token)
            => src.ResolveMember((int)token);

        /// <summary>
        /// Defines a tagged member
        /// </summary>
        /// <param name="m">The member</param>
        /// <param name="t">The tag</param>
        /// <typeparam name="M">The member type</typeparam>
        /// <typeparam name="T">The tag type</typeparam>
        [MethodImpl(Inline)]
        public static ClrMemberTag<M,T> member<M,T>(M m, T t)
            where M : MemberInfo
            where T : Attribute
                => (m,t);
    }
}