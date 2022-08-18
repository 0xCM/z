//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataHandler<T> : IDataHandler<T>
    {
        readonly DataReceiver<T> Receiver;

        [MethodImpl(Inline)]
        public DataHandler(DataReceiver<T> receiver)
            => Receiver = receiver;

        [MethodImpl(Inline)]
        public void Handle(T data)
            => Receiver(data);

        public static DataHandler<T> Empty
            => new DataHandler<T>(t => {});
    }
}