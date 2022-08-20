//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ScalarType : SizedType, IScalarType, IEquatable<ScalarType>
    {
        public NativeClass NativeClass {get;}

        [MethodImpl(Inline)]
        public ScalarType(Identifier name, NativeClass kind, BitWidth content, BitWidth storage)
            : base(name, nameof(ScalarType), (ulong)kind, content, storage)
        {
            NativeClass = kind;
        }


        public bool Equals(ScalarType src)
            => Name.Equals(src.Name) && ContentWidth == src.ContentWidth;

        public static ScalarType Empty
        {
            [MethodImpl(Inline)]
            get => new ScalarType(EmptyString, NativeClass.None, 0, 0);
        }
    }
}