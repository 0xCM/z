//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public class TokenDispenser
{
    public static ref readonly TokenDispenser Service => ref Instance;

    [MethodImpl(Inline)]
    public static ExecToken open()
        => Service.Open();

    public static ExecToken close(ExecToken src, bool success = true)
        => Service.Close(src, success);

    public static ExecToken close(ExecFlow src, bool success = true)
        => Service.Close(src.Token, success);

    public static ExecToken close(FileEmission src)
        => Service.Close(src.Token, src.Succeeded);

    public static ExecToken close<T>(TableFlow<T> src, bool success = true)
        => Service.Close(src.Token, success);

    public static ExecToken close<T>(ExecFlow<T> src, bool success = true)
        => Service.Close(src.Token, success);

    long StartToken;

    long EndToken;

    static TokenDispenser Instance;
    
    TokenDispenser()
    {
        StartToken = 0;
        EndToken = 0;
    }

    public static TokenDispenser create()
        => Instance;

    [MethodImpl(Inline), Op]
    public ExecToken Open()
        => new ((ulong)inc(ref StartToken));

    [MethodImpl(Inline), Op]
    public ExecToken Close(ExecToken src, bool success = true)
        => src.Complete((ulong)inc(ref EndToken), success);

    static TokenDispenser()
    {
        Instance = new();
    }
}
