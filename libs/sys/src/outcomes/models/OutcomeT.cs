//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Outcomes;

    /// <summary>
    /// Describes an operation result
    /// </summary>
    public readonly struct Outcome<T> : IOutcome<T>
    {
        public bool Ok {get;}

        public T Data {get;}

        readonly string _Message;

        public ulong MessageCode {get;}

        public bool Fail => !Ok;

        [MethodImpl(Inline)]
        public Outcome(Outcome src)
        {
            Ok = src.Ok;
            Data = default;
            _Message = src.Message;
            MessageCode = src.MessageCode;
        }

        [MethodImpl(Inline)]
        public Outcome(Outcome src, T data)
        {
            Ok = src.Ok;
            Data = data;
            _Message = src.Message;
            MessageCode = src.MessageCode;
        }

        [MethodImpl(Inline)]
        public Outcome(bool ok, T data = default)
        {
            Ok = ok;
            Data = data;
            _Message = EmptyString;
            MessageCode = api.u8(Ok);
        }

        public Outcome(bool ok, string message)
        {
            Ok = ok;
            Data = default;
            _Message = message;
            MessageCode = 0;
        }

        [MethodImpl(Inline)]
        public Outcome(bool ok, T data, string message)
        {
            Ok = ok;
            Data = data;
            _Message = message ?? EmptyString;
            MessageCode = api.u8(Ok);
        }

        [MethodImpl(Inline)]
        Outcome(ulong code)
        {
            Ok = false;
            Data = default;
            _Message = EmptyString;
            MessageCode = code;
        }

        [MethodImpl(Inline)]
        public Outcome(Exception e, T data = default)
        {
            Ok = false;
            Data = data;
            _Message = e.ToString();
            MessageCode = api.u8(Ok);
        }

        public string Message
            => _Message ?? "<null>";


        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => MessageCode == ulong.MaxValue;
        }


        /// <summary>
        /// Extracts the enclosed data, if <see cref='Ok'/> is true
        /// </summary>
        /// <param name="content">Upon success, the payload</param>
        [MethodImpl(Inline)]
        public bool Payload(out T content)
        {
            if(Ok)
            {
                content = Data;
                return true;
            }
            else
            {
                content = default;
                return false;
            }
        }

        public T Require()
            => Ok ? Data : sys.@throw<T>();

        [MethodImpl(Inline)]
        public Either<Y,Z> Map<Y,Z>(Func<Outcome<T>,Y> success, Func<Outcome<T>,Z> failure)
            => Ok ? Either.right<Y,Z>(success(this)) : Either.right<Y,Z>(failure(this));

        [MethodImpl(Inline)]
        public string Format()
            => Ok ? string.Format("{0}",Data) : string.Format("Error: {0}", Message);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public Outcome<T> OnSuccess(Action<T> f)
        {
            if(Ok)
                f(Data);
            return this;
        }

        [MethodImpl(Inline)]
        public Outcome<T> OnFailure(Action<string> f)
        {
            if(!Ok)
                f(Message ?? "An eggregious blunder");
            return this;
        }

        [MethodImpl(Inline)]
        public static bool operator true(Outcome<T> src)
            => src.Ok == true;

        [MethodImpl(Inline)]
        public static bool operator false(Outcome<T> src)
            => src.Ok == false;

        [MethodImpl(Inline)]
        public static implicit operator Outcome<T>(T data)
            => new Outcome<T>(true, data);

        [MethodImpl(Inline)]
        public static implicit operator Outcome<T>(Outcome src)
            => new Outcome<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Outcome<T>(bool ok)
            => new Outcome<T>(ok, default(T));

        [MethodImpl(Inline)]
        public static implicit operator bool(Outcome<T> src)
            => src.Ok;

        [MethodImpl(Inline)]
        public static implicit operator Outcome(Outcome<T> src)
            => new Outcome(src.Ok, src.Message);

        [MethodImpl(Inline)]
        public static implicit operator Outcome<T>(Exception error)
            => new Outcome<T>(error);

        [MethodImpl(Inline)]
        public static implicit operator T(Outcome<T> src)
            => src.Ok ? src.Data : default;

        [MethodImpl(Inline)]
        public static implicit operator Outcome<T>((bool ok, T data) src)
            => new Outcome<T>(src.ok, src.data);

        [MethodImpl(Inline)]
        public static implicit operator Outcome<T>((bool success, string msg) src)
            => new Outcome<T>(src.success, src.msg);

        public static Outcome<T> Empty
        {
            [MethodImpl(Inline)]
            get => new Outcome<T>(ulong.MaxValue);
        }

        public static Outcome<T> Success
        {
            [MethodImpl(Inline)]
            get => new Outcome<T>(true);
        }
    }
}