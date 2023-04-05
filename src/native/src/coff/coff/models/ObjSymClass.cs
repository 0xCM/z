//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct ObjSymClass
    {
        public readonly ObjSymKind Kind;

        public readonly ObjSymCode Code;

        [MethodImpl(Inline)]
        public ObjSymClass(ObjSymCode code)
        {
            Code = code;
            Kind = CoffObjects.kind(code);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Pack();
        }

        [MethodImpl(Inline)]
        public ushort Pack()
            => math.or((ushort)Kind, math.sll((ushort)Code, 4));

        [MethodImpl(Inline)]
        public bool Equals(ObjSymClass src)
            => Code == src.Code;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator ObjSymClass(ObjSymCode src)
            => new ObjSymClass(src);

        [MethodImpl(Inline)]
        public static implicit operator ObjSymCode(ObjSymClass src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator ObjSymKind(ObjSymClass src)
            => src.Kind;
    }
}