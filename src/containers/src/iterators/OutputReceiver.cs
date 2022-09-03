//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct OutputReceiver<T>
    {
        internal T Current;

        internal ViewTrigger<T> Trigger;

        [MethodImpl(Inline)]
        public static OutputReceiver<T> create(ViewTrigger<T> trigger)
        {
            var receiver = new OutputReceiver<T>();
            receiver.Trigger = trigger;
            receiver.Current = default;
            return receiver;
        }
    }
}