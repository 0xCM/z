//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(Type src)
            => src.TypeHandle.Value;

        [MethodImpl(Inline), Op]
        public static MemoryAddress address(Delegate src)
            => src.Method.MethodHandle.GetFunctionPointer();

        [MethodImpl(Inline), Op]
        public static MemberAddress address(ClrMember member, MemoryAddress address)
            => new MemberAddress(member,address);

        /// <summary>
        /// Computes the <see cref='MemberAddress'/> of a specified <see cref='MethodInfo'/>
        /// </summary>
        /// <param name="src">The source member</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemberAddress address(MethodInfo src)
            => new MemberAddress(src, src.MethodHandle.GetFunctionPointer());

        /// <summary>
        /// Computes the <see cref='MemberAddress'/> of a specified <see cref='FieldInfo'/>
        /// </summary>
        /// <param name="src">The source member</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemberAddress address(FieldInfo src)
            => new MemberAddress(src, src.FieldHandle.Value.ToPointer());
    }
}