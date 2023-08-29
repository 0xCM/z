//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct ExecToken<P> : IDataType<ExecToken<P>>, IDataString<ExecToken<P>>
{
    public readonly ExecToken Token;

    public readonly P? Payload;

    [MethodImpl(Inline)]
    public ExecToken(ExecToken token)
    {
        Token = token;
        Payload = default(P);
    }

    [MethodImpl(Inline)]
    public ExecToken(ExecToken token, P payload)
    {
        Token = token;
        Payload = payload;
    }

    public ExecToken()
    {
        Token = ExecToken.Empty;
        Payload = default(P);
    }

    [MethodImpl(Inline)]
    public ExecToken<P> Complete(ulong seq, bool success, P payload)
        => new (Token.Complete(seq,success), payload);

    public ulong StartSeq 
        => Token.StartSeq;

    public Timestamp Started
        => Token.Started;

    public Timestamp? Finished 
        => Token.Finished;

    public ulong EndSeq
        => Token.EndSeq;

    public bool Success
        => Token.Success;

    public bool HasPayload
        => Payload != null;
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

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Token.Hash & sys.hash(Payload);
    }

    public bool Equals(ExecToken<P> src)
        => Token.Equals(src.Token) && (Payload?.Equals(src.Payload) ?? false);

    public string Format()
        => Token.Format();

    public override string ToString()
        => Format();

    public override int GetHashCode()
        => Hash;

    public int CompareTo(ExecToken<P> src)
        => StartSeq.CompareTo(src.StartSeq);

    [MethodImpl(Inline)]
    public static implicit operator ExecToken(ExecToken<P> src)
        => src.Token;

    [MethodImpl(Inline)]
    public static implicit operator ExecToken<P>((ExecToken token, P payload) src)
        => new (src.token,src.payload);

    public static ExecToken<P> Empty => new();
}
