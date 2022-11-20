//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class BlitMachine : AppService<BlitMachine>
    {
        IPolyrand Random;

        Index<byte> Buffer;

        uint BufferSize;

        protected override void Initialized()
        {
            BufferSize = Pow2.T14;
            Random = Rng.wyhash64();
            Buffer = alloc<byte>(BufferSize);
        }

        [MethodImpl(Inline)]
        Span<T> Cells<T>()
            where T : unmanaged
                => recover<T>(Buffer.Edit);

        [MethodImpl(Inline)]
        Span<T> Cells<T>(uint offset, uint count)
            where T : unmanaged
                => slice(recover<T>(Buffer.Edit),offset,count);

        public void Run()
        {
        }
    }
}