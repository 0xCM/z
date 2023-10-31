//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static ErrorMsg;
using static CheckLengths;
using static CheckInvariant;
using static ClaimValidator;

using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

public readonly struct CheckPrimalSeq : ICheckPrimalSeq
{
    /// <summary>
    /// Returns true if the character spans are equal as strings, false otherwise
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Op]
    public static bool TestEq(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
        => sys.eq(a, b);

    /// <summary>
    /// Returns true if the character spans are equal as strings, false otherwise
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Op]
    public static bool TestEq(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
        => sys.eq(a,b);

    /// <summary>
    /// Returns true if the spans are equal, false otherwise
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Op]
    public static bool TestEq(ReadOnlySpan<sbyte> a, ReadOnlySpan<sbyte> b)
        => sys.eq(a,b);

    /// <summary>
    /// Returns true if the character spans are equal as strings, false otherwise
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Op]
    public static bool TestEq(ReadOnlySpan<int> a, ReadOnlySpan<int> b)
        => sys.eq(a,b);

    /// <summary>
    /// Returns true if the character spans are equal as strings, false otherwise
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Op]
    public static bool TestEq(ReadOnlySpan<uint> a, ReadOnlySpan<uint> b)
        => sys.eq(a,b);

    /// <summary>
    /// Returns true if the character spans are equal as strings, false otherwise
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Op]
    public static bool TestEq(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b)
        => sys.eq(a,b);

    /// <summary>
    /// Asserts the equality of two boolean arrays
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    /// <param name="caller">The caller member name</param>
    /// <param name="file">The source file of the calling function</param>
    /// <param name="line">The source file line number where invocation ocurred</param>
    public static void eq(ReadOnlySpan<bool> a, ReadOnlySpan<bool> b, [Caller] string caller = null, [File] string file = null, [CallerLine] int? line = null)
    {
        var count = length(a,b);
        for(var i = 0; i<count; i++)
            if(a[i] != b[i])
                throw failed(ClaimKind.Eq, ItemsNotEqual(i, a[i], b[i], caller, file, line));
    }

    /// <summary>
    /// Asserts content equality for two character spans
    /// </summary>
    /// <param name="a">The left span</param>
    /// <param name="b">The right span</param>
    /// <param name="caller">The invoking function</param>
    /// <param name="file">The file in which the invoking function is defined </param>
    /// <param name="line">The file line number of invocation</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void eq(ReadOnlySpan<char> a, ReadOnlySpan<char> b, [Caller] string caller = null, [File] string file = null, [CallerLine] int? line = null)
        => require(TestEq(a,b), string.Format("Equality fail, {0} != {1}", a.ToString(), b.ToString()), caller, file, line);

    /// <summary>
    /// Asserts content equality for two byte spans
    /// </summary>
    /// <param name="a">The left span</param>
    /// <param name="b">The right span</param>
    /// <param name="caller">The invoking function</param>
    /// <param name="file">The file in which the invoking function is defined </param>
    /// <param name="line">The file line number of invocation</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void eq(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b, [Caller] string caller = null, [File] string file = null, [CallerLine] int? line = null)
        => require(TestEq(a, b), "a != b", caller, file, line);

    /// <summary>
    /// Asserts content equality for two byte spans
    /// </summary>
    /// <param name="a">The left span</param>
    /// <param name="b">The right span</param>
    /// <param name="caller">The invoking function</param>
    /// <param name="file">The file in which the invoking function is defined </param>
    /// <param name="line">The file line number of invocation</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void eq(ReadOnlySpan<sbyte> a, ReadOnlySpan<sbyte> b, [Caller] string caller = null, [File] string file = null, [CallerLine] int? line = null)
        => require(TestEq(a, b), "a != b", caller, file, line);

    /// <summary>
    /// Asserts content equality for two byte spans
    /// </summary>
    /// <param name="a">The left span</param>
    /// <param name="b">The right span</param>
    /// <param name="caller">The invoking function</param>
    /// <param name="file">The file in which the invoking function is defined </param>
    /// <param name="line">The file line number of invocation</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void eq(ReadOnlySpan<int> a, ReadOnlySpan<int> b, [Caller] string caller = null, [File] string file = null, [CallerLine] int? line = null)
        => require(TestEq(a, b), "a != b", caller, file, line);

    /// <summary>
    /// Asserts content equality for two byte spans
    /// </summary>
    /// <param name="a">The left span</param>
    /// <param name="b">The right span</param>
    /// <param name="caller">The invoking function</param>
    /// <param name="file">The file in which the invoking function is defined </param>
    /// <param name="line">The file line number of invocation</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void eq(ReadOnlySpan<uint> a, ReadOnlySpan<uint> b, [Caller] string caller = null, [File] string file = null, [CallerLine] int? line = null)
        => require(TestEq(a, b), "a != b", caller, file, line);

    /// <summary>
    /// Asserts content equality for two byte spans
    /// </summary>
    /// <param name="a">The left span</param>
    /// <param name="b">The right span</param>
    /// <param name="caller">The invoking function</param>
    /// <param name="file">The file in which the invoking function is defined </param>
    /// <param name="line">The file line number of invocation</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void eq(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, [Caller] string caller = null, [File] string file = null, [CallerLine] int? line = null)
        => require(TestEq(a, b), "a != b", caller, file, line);
}
