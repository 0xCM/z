//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Sequential<T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public static ref Sequential<T> next(ref Sequential<T> src)
        {
            ref var dst = ref @edit(src);
            ref var value = ref dst.Lo;
            if(size<T>() == 1)
                uint8(ref value) = (byte)(uint8(value) + 1);
            else if(size<T>() == 2)
                uint16(ref value) = (ushort)(uint16(value) + 1);
            else if(size<T>() == 4)
                uint32(ref value) = uint32(value) + 1u;
            else if(size<T>() == 8)
                uint64(ref value) = uint64(value) + 1ul;
            else
                throw no<T>();
            return ref dst;
        }

        const long Step = 1;

        internal T Lo;

        internal T Hi;

        [MethodImpl(Inline)]
        public Sequential(T src)
        {
            Lo = src;
            Hi = default;
        }

        [MethodImpl(Inline)]
        public Sequential(T src, T hi)
        {
            Lo = src;
            Hi = hi;
        }

        public Sequential<T> Next()
            => next(ref this);

        public void IncLo()
        {
            ref var x = ref @as<T,long>(Lo);
            x += Step;
        }

        public void IncHi()
        {
            ref var x = ref @as<T,long>(Hi);
            x += Step;
        }

        public void DecLo()
        {
            ref var x = ref @as<T,long>(Lo);
            x -= Step;
        }

        public void DecHi()
        {
            ref var x = ref @as<T,long>(Hi);
            x -= Step;
        }

        public string Format()
            => EmptyString;

        [MethodImpl(Inline)]
        public static Sequential<T> operator ++(Sequential<T> src)
        {
            src.IncLo();
            return src;
        }

        [MethodImpl(Inline)]
        public static Sequential<T> operator --(Sequential<T> src)
        {
            src.DecLo();
            return src;
        }

        [MethodImpl(Inline)]
        public static implicit operator Sequential<T>(T src)
            => new Sequential<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Sequential<T> src)
            => src.Lo;
    }
}