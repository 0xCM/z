//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class BufferedProjector<S,T>
    {
        readonly Queue<S> Buffer;

        readonly ISFxProjector<S,T> Projector;

        [MethodImpl(Inline)]
        public BufferedProjector(IPipeline pipes, Queue<S> buffer, ISFxProjector<S,T> projector)
        {
            Buffer = buffer;
            Projector = projector;
        }

        [MethodImpl(Inline)]
        public void Deposit(S src)
            => Buffer.Enqueue(src);

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