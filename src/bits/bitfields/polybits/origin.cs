//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline)]
        public static BfOrigin<T> origin<T>(T src)
            => src;

        [MethodImpl(Inline)]
        public static BfOrigin<ClrTypeName> origin(Type src)
            => new BfOrigin<ClrTypeName>(src);

        [MethodImpl(Inline)]
        public static BfOrigin<ClrTypeName> origin<T>()
            => origin(typeof(T));

        [MethodImpl(Inline)]
        public static BfOrigin<string> origin(FieldInfo src)
            => string.Format("[{0}/{1}/{2}:{3}]",
                    src.DeclaringType.Assembly.PartName(),
                    src.DeclaringType.Namespace,
                    src.DeclaringType.DisplayName(),
                    src.Name
                    );
    }
}