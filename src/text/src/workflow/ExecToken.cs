//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record struct ExecToken : IDataType<ExecToken>, IDataString<ExecToken>
    {
        public ulong StartSeq;

        public Timestamp Started;

        public Timestamp? Finished;

        public ulong EndSeq;

        public bool Success;

        [MethodImpl(Inline)]
        public ExecToken(ulong seq)
        {
            StartSeq = seq;
            Started = Timestamp.now();
            Finished = null;
            EndSeq = 0;
            Success = false;            
        }

        [MethodImpl(Inline)]
        public ExecToken Complete(ulong seq, bool success)
        {
            EndSeq = seq;
            Success = success;
            Finished = Timestamp.now();
            Success = success;
            return this;
        }

        public ExecToken()
        {
            StartSeq = 0;
            Started = Timestamp.Zero;
            Finished = null;
            EndSeq = 0;
            Success = false;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.nhash(StartSeq) | Started.Hash | (Finished ?? Timestamp.Zero).Hash | nhash(EndSeq);
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

        [MethodImpl(Inline)]
        public bool Equals(ExecToken src)
            => StartSeq == src.StartSeq && Started == src.Started && EndSeq == src.EndSeq && Finished == src.Finished;

        public int CompareTo(ExecToken src)
            => StartSeq.CompareTo(src.StartSeq);

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

        public override int GetHashCode()
            => Hash;

        public static ExecToken Empty
        {
            [MethodImpl(Inline)]
            get => new ();
        }
    }
}