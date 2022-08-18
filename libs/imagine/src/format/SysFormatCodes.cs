//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct SysFormatCodes
    {
        const string OpenSlot = "{0:";

        const string CloseSlot = "}";

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static SysFormatCode<SysFormatKind,C> define<C>(SysFormatKind kind, C code)
            => (kind,code);

        [MethodImpl(Inline), Op]
        public static SysFormatCode<SysFormatKind,char> define(SysFormatKind kind, char code)
            => (kind,code);

        [MethodImpl(Inline), Op]
        public static SysFormatCode<SysFormatKind,string> define(SysFormatKind kind, string code)
            => (kind,code);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static SysFormatCode<object> untyped<C>(in SysFormatCode<C> src)
            => new SysFormatCode<object>(src.Kind, src.Code);

        [Op, Closures(AllNumeric)]
        public static string slot<C>(C code)
            => string.Concat(OpenSlot, code.ToString() ?? "g",  CloseSlot);

        [Closures(AllNumeric)]
        public static string apply<T>(SysFormatCode def, T src)
            => string.Format(slot(def.Code), src);

        [Op, Closures(AllNumeric)]
        public static string format<C>(in SysFormatCode<C> src)
            => string.Format("{0}:{1}", src.Code, src.Kind);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref SysFormatCode charcode<C>(in SysFormatCode<C> src)
            => ref Unsafe.As<SysFormatCode<C>, SysFormatCode>(ref Unsafe.AsRef(src));

        [MethodImpl(Inline)]
        public static SysFormatCode<K,C> define<K,C>(K kind, C code)
            where K : unmanaged
                => (kind,code);

        [MethodImpl(Inline)]
        public static SysFormatCode<C> knownkind<K,C>(SysFormatCode<K,C> src)
            where K : unmanaged
                => new SysFormatCode<C>(Unsafe.As<K,SysFormatKind>(ref Unsafe.AsRef(src.Kind)), src.Code);

        public static string format<K,C>(SysFormatCode<K,C> src)
            where K : unmanaged
                => string.Format("{0}:{1}", src.Code, src.Kind);

        public static string apply<K,C,T>(SysFormatCode<K,C> def, T subject)
            where K : unmanaged
                => string.Format(def.Slot, subject);

        public static string apply<C,T>(SysFormatCode<C> def, T src)
            => string.Format(slot(def.Code), src);
    }
}