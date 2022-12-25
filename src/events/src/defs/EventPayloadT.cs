//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EventPayload<T>
    {
        readonly T _Data;

        public readonly bool IsNonEmpty;

        [MethodImpl(Inline)]
        public EventPayload(T data)
        {
            _Data = sys.require(data);
            IsNonEmpty = data != null;
        }

        [MethodImpl(Inline)]
        EventPayload(T data, bool empty)
        {
            _Data = data;
            IsNonEmpty = false;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline), Op]
            get => !IsNonEmpty;
        }

        public T Data
        {
            [MethodImpl(Inline), Op]
            get => sys.require(_Data);
        }

        [MethodImpl(Inline)]
        public string Format()
            => $"{Data}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EventPayload<T>(T src)
            => new EventPayload<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(EventPayload<T> src)
            => src.Data;

        public static EventPayload<T> Empty
        {
            [MethodImpl(Inline)]
            get => new EventPayload<T>(default,true);
        }
    }
}