//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct ApiCmdRoute : IDataType<ApiCmdRoute>, IDataString<ApiCmdRoute>
{
    [Parser]
    public static bool parse(string src, out ApiCmdRoute dst)
    {
        dst = new(src);
        return true;
    }

    const char Sep = Chars.FSlash;

    readonly ReadOnlySeq<string> Data;

    public readonly @string Path;

    [MethodImpl(Inline)]
    public ApiCmdRoute(string src)
    {
        Path = src;
        Data = text.split(src, Sep);
    }

    [MethodImpl(Inline)]
    public ApiCmdRoute(params string[] src)
    {
        Path = text.join(Sep,src);
        Data = src;
    }

    public bool IsPartial
        => IsNonEmpty && Data.Last == "*";

    public ApiCmdRoute Complete()
        => IsPartial ? new ApiCmdRoute(Data.View.Slice(0, Data.Length - 2).ToArray()) : this;

    public uint PartCount
    {
        [MethodImpl(Inline)]
        get => Data.Count;
    }

    public ref readonly string this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public ref readonly string this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Path.Hash;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Path.IsEmpty;            
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Path.IsNonEmpty;            
    }

    public ApiCmdRoute Refine(params string[] src)
    {
        var count = Data.Length + src.Length;
        var dst = sys.alloc<string>(Data.Length + src.Length);
        var j=0u;
        for(var i=0; i< Data.Length; i++)
            sys.seek(dst,j++) = Data[i];
        for(var i=0; i< src.Length; i++)
            sys.seek(dst,j++) = src[i];
        return new ApiCmdRoute(dst);            
    }

    public override int GetHashCode()
        => Hash;

    public bool Equals(ApiCmdRoute src)
        => Path == src.Path;

    public int CompareTo(ApiCmdRoute src)
        => Path.CompareTo(src.Path);

    public string Format()
        => Path;

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator ApiCmdRoute(string src)
        => new (src);
    
    [MethodImpl(Inline)]
    public static implicit operator @string(ApiCmdRoute src)
        => src.Path;

    public static ApiCmdRoute Empty => new();
}
