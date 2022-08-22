//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct ArrayReader<T> : ICachedReader<T>
    {
        readonly T[] Data;

        int Index;

        [MethodImpl(Inline)]
        public ArrayReader(T[] src)
        {
            Data = src;
            Index = 0;
        }

        [MethodImpl(Inline)]
        public bool HasPrior()
            => Index > 0;

        [MethodImpl(Inline)]
        public bool HasNext()
            => Index < Data.Length;

        [MethodImpl(Inline)]
        public ref readonly T Next()
            => ref skip(Data,Index++);

        [MethodImpl(Inline)]
        public ref readonly T Prior()
            => ref skip(Data,--Index);

        [MethodImpl(Inline)]
        public bool Next(out T dst)
        {
            if(HasNext())
            {
                dst = Next();
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public bool Advance()
        {
            if(HasNext())
            {
                Index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        [MethodImpl(Inline)]
        public ref readonly T ViewNext()
            => ref skip(Data,Index+1);

        [MethodImpl(Inline)]
        public bool ViewNext(out T dst)
        {
            if(HasNext())
            {
                dst = ViewNext();
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public static implicit operator ArrayReader<T>(T[] src)
            => new ArrayReader<T>(src);
    }
}