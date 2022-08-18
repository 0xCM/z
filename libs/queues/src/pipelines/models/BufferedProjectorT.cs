//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BufferedProjector<T>
    {
        readonly Queue<T> Buffer;

        readonly ISFxProjector<T> Projector;

        [MethodImpl(Inline)]
        public BufferedProjector(IPipeline pipes, Queue<T> buffer, ISFxProjector<T> projector)
        {
            Buffer = buffer;
            Projector = projector;
        }

        [MethodImpl(Inline)]
        public void Deposit(T src)
            => Buffer.Enqueue(src);

        [MethodImpl(Inline)]
        public bool Emit(out T dst)
        {
            if(Buffer.TryDequeue(out var src))
            {
                dst = Projector.Invoke(src);
                return true;
            }
            dst = default;
            return false;
        }
    }
}