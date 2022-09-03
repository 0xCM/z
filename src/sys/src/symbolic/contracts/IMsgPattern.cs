//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IMsgPattern : IFormatPattern
    {

    }

    public interface IMsgPattern<H,T> : IMsgPattern
        where H : struct, IMsgPattern<H,T>
    {
        string Format(in T a0);

        MsgCapture Capture(in T a0);

        byte IFormatPattern.ArgCount => 1;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(T));
    }

    public interface IMsgPattern<H,A0,A1> : IMsgPattern
        where H : struct, IMsgPattern<H,A0,A1>
    {
        string Format(in A0 a0, in A1 a1);

        MsgCapture Capture(in A0 a0, in A1 a1);

        byte IFormatPattern.ArgCount => 2;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1));
    }

    public interface IMsgPattern<H,A0,A1,A2> : IMsgPattern
        where H : struct, IMsgPattern<H,A0,A1,A2>
    {
        string Format(in A0 a0, in A1 a1, in A2 a2);

        MsgCapture Capture(in A0 a0, in A1 a1, in A2 a2);

        byte IFormatPattern.ArgCount => 3;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1), typeof(A2));
    }

    public interface IMsgPattern<H,A0,A1,A2,A3> : IMsgPattern
        where H : struct, IMsgPattern<H,A0,A1,A2,A3>
    {
        string Format(in A0 a0, in A1 a1, in A2 a2, in A3 a3);

        MsgCapture Capture(in A0 a0, in A1 a1, in A2 a2, in A3 a3);

        byte IFormatPattern.ArgCount => 4;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1), typeof(A2), typeof(A3));
    }

    public interface IMsgPattern<H,A0,A1,A2,A3,A4> : IMsgPattern
        where H : struct, IMsgPattern<H,A0,A1,A2,A3,A4>
    {
        string Format(in A0 a0, in A1 a1, in A2 a2, in A3 a3, in A4 a4);

        MsgCapture Capture(in A0 a0, in A1 a1, in A2 a2, in A3 a3, in A4 a4);

        byte IFormatPattern.ArgCount => 5;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1), typeof(A2), typeof(A3), typeof(A4));
    }
}