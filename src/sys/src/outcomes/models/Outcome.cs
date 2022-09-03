//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Outcomes;

    /// <summary>
    /// Defines the outcome of an operation/process
    /// </summary>
    public readonly struct Outcome : IOutcome
    {
        [MethodImpl(Inline)]
        internal static Outcome combine(Outcome a, Outcome b)
            => (a.Ok && b.Ok, string.Format("{0}\r\r{1}",a.Message, b.Message));

        [MethodImpl(Inline)]
        public static Outcome fail(string msg)
            => (false,msg);

        [MethodImpl(Inline)]
        public static Outcome success(dynamic data, string msg = EmptyString)
            => new Outcome(true, data, msg ?? EmptyString);

        [MethodImpl(Inline)]
        public static Outcome define(bool success, dynamic data, string msg = EmptyString)
            => new Outcome(success, data, msg ?? EmptyString);

        public bool Ok {get;}

        public string Message {get;}

        public dynamic Data {get;}

        public ulong MessageCode {get;}

        public bool Fail => !Ok;

        public Outcome(bool success)
        {
            Ok = success;
            Message = success ? EmptyString : "Bad";
            MessageCode = api.u8(Ok);
            Data = true;
        }

        public Outcome(bool success, string message)
        {
            Ok = success;
            Message = message;
            MessageCode = api.u8(Ok);
            Data = message ?? EmptyString;
        }

        Outcome(bool success, dynamic data, string message)
        {
            Ok = success;
            Message = message;
            Data = data;
            MessageCode = api.u8(Ok);
            Data = message;
        }

        public Outcome(Exception e)
        {
            Ok = false;
            Message = e.ToString();
            MessageCode = api.u8(Ok);
            Data = e;
        }

        public Outcome(Exception e, string msg)
        {
            Ok = false;
            Message = string.Format("{0} - {1}", msg, e);
            MessageCode = api.u8(Ok);
            Data = msg ?? EmptyString;
        }

        [MethodImpl(Inline)]
        Outcome(ulong code)
        {
            Ok = false;
            Message = EmptyString;
            MessageCode = code;
            Data = EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == null;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Message;

        public override string ToString()
            => Format();

        public void Require()
        {
            if(Fail)
                throw new Exception(Message ?? "An eggregious blunder");
        }

        public static Outcome operator +(Outcome a, Outcome b)
            => combine(a,b);

        public static Outcome operator &(Outcome a, Outcome b)
            => combine(a,b);

        public static implicit operator Outcome(bool src)
            => new Outcome(src);

        public static implicit operator bool(Outcome src)
            => src.Ok;

        public static implicit operator Outcome(Exception e)
            => new Outcome(e);

        public static implicit operator Outcome((Exception e, string msg) src)
            => new Outcome(src.e,src.msg);

        [MethodImpl(Inline)]
        public static implicit operator Outcome((bool success, string msg) src)
            => new Outcome(src.success, src.msg);

        public static bool operator true(Outcome src)
            => src.Ok == true;

        [MethodImpl(Inline)]
        public static bool operator false(Outcome src)
            => src.Ok == false;

        public static Outcome Success
        {
            [MethodImpl(Inline)]
            get => new Outcome(true);
        }

        public static Outcome Failure
        {
            [MethodImpl(Inline)]
            get => new Outcome(false);
        }

        public static Outcome Empty
        {
            [MethodImpl(Inline)]
            get => new Outcome(ulong.MaxValue);
        }
    }
}