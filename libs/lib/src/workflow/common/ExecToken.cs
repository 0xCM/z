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

        public static ExecToken Empty
        {
            [MethodImpl(Inline)]
            get => new ExecToken(ulong.MaxValue);
        }

        public string Format()
        {
            var i=0u;
            Span<char> dst = stackalloc char[82];
            text.copy(string.Format("{0:D5}", StartSeq), ref i, dst);
            text.copy(Chars.Colon, ref i, dst);
            text.copy(string.Format("{0:D5}", EndSeq), ref i, dst);
            text.copy(Chars.Space, ref i, dst);
            text.copy(Chars.Pipe, ref i, dst);
            text.copy(Chars.Space, ref i, dst);
            text.copy(Started.Format(), ref i, dst);
            text.copy(Chars.Space, ref i, dst);
            text.copy(Chars.Pipe, ref i, dst);
            text.copy(Chars.Space, ref i, dst);
            if(Finished != null)
                text.copy(Finished.Value.Format(), ref i, dst);
            return text.format(slice(dst,0,i));
        }

        public override string ToString()
            => Format();
    }
}