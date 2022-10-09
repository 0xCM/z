//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct ExecToken
    {
        public ulong StartSeq;

        public Timestamp Started;

        public Timestamp? Finished;

        public ulong EndSeq;

        [MethodImpl(Inline)]
        public ExecToken(ulong seq)
        {
            StartSeq = seq;
            Started = Timestamp.now();
            Finished = null;
            EndSeq = 0;
        }

        [MethodImpl(Inline)]
        public ExecToken Complete(ulong seq)
        {
            EndSeq = seq;
            Finished = Timestamp.now();
            return this;
        }

        public ExecToken()
        {
            StartSeq = 0;
            Started = Timestamp.Zero;
            Finished = null;
            EndSeq = 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Started.IsZero;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Started.IsNonZero;
        }

        public string Format()
        {
            var i=0u;
            Span<char> dst = stackalloc char[82];
            SE.copy(string.Format("{0:D5}", StartSeq), ref i, dst);
            SE.copy(Chars.Colon, ref i, dst);
            SE.copy(string.Format("{0:D5}", EndSeq), ref i, dst);
            SE.copy(Chars.Space, ref i, dst);
            SE.copy(Chars.Pipe, ref i, dst);
            SE.copy(Chars.Space, ref i, dst);
            SE.copy(Started.Format(), ref i, dst);
            SE.copy(Chars.Space, ref i, dst);
            SE.copy(Chars.Pipe, ref i, dst);
            SE.copy(Chars.Space, ref i, dst);
            if(Finished != null)
                SE.copy(Finished.Value.Format(), ref i, dst);
            return sys.@string(slice(dst,0,i));
        }

        public override string ToString()
            => Format();

        public static ExecToken Empty
        {
            [MethodImpl(Inline)]
            get => new ();
        }
    }
}