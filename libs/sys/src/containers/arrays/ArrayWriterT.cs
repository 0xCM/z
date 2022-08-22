//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct ArrayWriter<T>
    {
        public readonly T[] Storage;

        int Index;

        [MethodImpl(Inline)]
        public ArrayWriter(T[] src)
        {
            Storage = src;
            Index = 0;
        }

        public void Reset()
        {
            Index = 0;
        }

        [MethodImpl(Inline)]
        public readonly int Pos()
            => Index;

        [MethodImpl(Inline)]
        public bool HasPrior()
            => Index > 0;

        [MethodImpl(Inline)]
        public bool HasNext()
            => Index < Storage.Length;

        [MethodImpl(Inline)]
        public ref T Next()
            => ref seek(Storage,Index++);

        [MethodImpl(Inline)]
        public ref T Prior()
            => ref seek(Storage,--Index);

        [MethodImpl(Inline)]
        public bool Next(ref T dst)
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
        public static implicit operator ArrayWriter<T>(T[] src)
            => new ArrayWriter<T>(src);
    }
}