//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IFormatPattern
    {
        string PatternText {get;}

        byte ArgCount {get;}

        ReadOnlySpan<Type> ArgTypes {get;}
    }

    public interface IFormatPattern<H,T> : IFormatPattern
        where H : struct, IFormatPattern<H,T>
    {
        string Format(in T a0);

        RenderCapture Capture(in T a0);

        byte IFormatPattern.ArgCount => 1;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(T));
    }

    public interface IFormatPattern<H,A0,A1> : IFormatPattern
        where H : struct, IFormatPattern<H,A0,A1>
    {
        string Format(in A0 a0, in A1 a1);

        byte IFormatPattern.ArgCount 
            => 2;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1));
    }

    public interface IFormatPattern<H,A0,A1,A2> : IFormatPattern
        where H : struct, IFormatPattern<H,A0,A1,A2>
    {
        string Format(in A0 a0, in A1 a1, in A2 a2);

        RenderCapture Capture(in A0 a0, in A1 a1, in A2 a2);

        byte IFormatPattern.ArgCount 
            => 3;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1), typeof(A2));
    }

    public interface IFormatPattern<H,A0,A1,A2,A3> : IFormatPattern
        where H : struct, IFormatPattern<H,A0,A1,A2,A3>
    {
        string Format(in A0 a0, in A1 a1, in A2 a2, in A3 a3);

        RenderCapture Capture(in A0 a0, in A1 a1, in A2 a2, in A3 a3);

        byte IFormatPattern.ArgCount 
            => 4;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1), typeof(A2), typeof(A3));
    }

    public interface IFormatPattern<H,A0,A1,A2,A3,A4> : IFormatPattern
        where H : struct, IFormatPattern<H,A0,A1,A2,A3,A4>
    {
        string Format(in A0 a0, in A1 a1, in A2 a2, in A3 a3, in A4 a4);

        byte IFormatPattern.ArgCount 
            => 5;

        ReadOnlySpan<Type> IFormatPattern.ArgTypes
            => array(typeof(A0), typeof(A1), typeof(A2), typeof(A3), typeof(A4));
    }
}