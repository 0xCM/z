//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using B = StatusFlagBits;
using I = StatusFlagIndex;

/// <summary>
/// Defines the state of a <see cref='B'/> join
/// </summary>
[ApiComplete]
public record struct StatusFlags : IEquatable<StatusFlags>
{
    B State;

    [MethodImpl(Inline)]
    public StatusFlags(RFlagBits state)
        => State = (B)state;

    [MethodImpl(Inline)]
    public StatusFlags(B state)
        => State = state;

    [MethodImpl(Inline)]
    public bit CF()
        => (State & B.CF) != 0;

    [MethodImpl(Inline)]
    public void CF(bit f)
        => State = (B)bit.set((uint)State, (byte)I.CF, f);

    [MethodImpl(Inline)]
    public bit PF()
        => (State & B.PF) != 0;

    [MethodImpl(Inline)]
    public void PF(bit pf)
        => State = (B)bit.set((uint)State, (byte)I.PF, pf);

    [MethodImpl(Inline)]
    public bit AF()
        => (State & B.AF) != 0;

    [MethodImpl(Inline)]
    public void AF(bit f)
        => State = (B)bit.set((uint)State, (byte)I.AF, f);

    [MethodImpl(Inline)]
    public bit OF()
        => (State & B.OF) != 0;

    [MethodImpl(Inline)]
    public void OF(bit f)
        => State = (B)bit.set((uint)State, (byte)I.OF, f);

    [MethodImpl(Inline)]
    public bit SF()
        => (State & B.SF) != 0;

    [MethodImpl(Inline)]
    public void SF(bit f)
        => State = (B)bit.set((uint)State, (byte)I.SF, f);

    [MethodImpl(Inline)]
    public bit ZF()
        => (State & B.ZF) != 0;

    [MethodImpl(Inline)]
    public void ZF(bit f)
        => State = (B)bit.set((uint)State, (byte)I.ZF, f);

    [MethodImpl(Inline)]
    public bit NO()
        => (State & B.OF) == 0;

    [MethodImpl(Inline)]
    public bit NC()
        => (State & B.CF) == 0;

    [MethodImpl(Inline)]
    public bit NZ()
        => (State & B.ZF) == 0;

    [MethodImpl(Inline)]
    public bit NS()
        => (State & B.SF) == 0;

    [MethodImpl(Inline)]
    public bit NP()
        => (State & B.PF) == 0;

    [MethodImpl(Inline)]
    public bit LT()
        => SF() != OF();

    [MethodImpl(Inline)]
    public bit A()
        => (State & B.CF) == 0 && (State & B.ZF) == 0;

    [MethodImpl(Inline)]
    public bit NA()
        => !A();

    [MethodImpl(Inline)]
    public bit Read(I i)
        => bit.test((uint)State, (byte)i);

    [MethodImpl(Inline)]
    public void Write(I index, bit b)
        => State = (B)bit.set((uint)State, (byte)index, b);

    [MethodImpl(Inline)]
    public bool Equals(StatusFlags src)
        => State == src.State;

    public string Format()
    {
        const string Header = "OF | SF | ZF | AF | PF | CF";
        const string Pattern = "{5}  | {4}  | {3}  | {2}  | {1}  | {0}";
        var values = string.Format(Pattern, CF(), PF(), AF(), ZF(), SF(), OF());
        return string.Format("{0}\n{1}", Header, values);
    }

    public override string ToString()
        => Format();

    public override int GetHashCode()
        => (int)State;

    [MethodImpl(Inline)]
    public static implicit operator StatusFlags(RFlagBits src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator RFlagBits(StatusFlags src)
        => (RFlagBits)src.State;

    [MethodImpl(Inline)]
    public static implicit operator StatusFlags(B src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator B(StatusFlags src)
        => src.State;

    [MethodImpl(Inline)]
    public static explicit operator ushort(StatusFlags src)
        => (ushort)src.State;

    [MethodImpl(Inline)]
    public static explicit operator uint(StatusFlags src)
        => (uint)src.State;

    public static StatusFlags Zero => default;
}
