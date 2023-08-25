//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using F = StatusFlagBits;
using I = StatusFlagIndex;

/// <summary>
/// Defines the state of a <see cref='F'/> join
/// </summary>
[ApiComplete]
public record struct StatusFlags : IEquatable<StatusFlags>
{
    StatusFlagBits State;

    [MethodImpl(Inline)]
    public StatusFlags(RFlagBits state)
        => State = (StatusFlagBits)state;

    [MethodImpl(Inline)]
    public StatusFlags(StatusFlagBits state)
        => State = state;

    [MethodImpl(Inline)]
    public bit CF()
        => (State & F.CF) != 0;

    [MethodImpl(Inline)]
    public void CF(bit f)
        => State = (F)bit.set((uint)State, (byte)I.CF, f);

    [MethodImpl(Inline)]
    public bit PF()
        => (State & F.PF) != 0;

    [MethodImpl(Inline)]
    public void PF(bit pf)
        => State = (F)bit.set((uint)State, (byte)I.PF, pf);

    [MethodImpl(Inline)]
    public bit AF()
        => (State & F.AF) != 0;

    [MethodImpl(Inline)]
    public void AF(bit f)
        => State = (F)bit.set((uint)State, (byte)I.AF, f);

    [MethodImpl(Inline)]
    public bit OF()
        => (State & F.OF) != 0;

    [MethodImpl(Inline)]
    public void OF(bit f)
        => State = (F)bit.set((uint)State, (byte)I.OF, f);

    [MethodImpl(Inline)]
    public bit SF()
        => (State & F.SF) != 0;

    [MethodImpl(Inline)]
    public void SF(bit f)
        => State = (F)bit.set((uint)State, (byte)I.SF, f);

    [MethodImpl(Inline)]
    public bit ZF()
        => (State & F.ZF) != 0;

    [MethodImpl(Inline)]
    public void ZF(bit f)
        => State = (F)bit.set((uint)State, (byte)I.ZF, f);

    [MethodImpl(Inline)]
    public bit NO()
        => (State & F.OF) == 0;

    [MethodImpl(Inline)]
    public bit NC()
        => (State & F.CF) == 0;

    [MethodImpl(Inline)]
    public bit NZ()
        => (State & F.ZF) == 0;

    [MethodImpl(Inline)]
    public bit NS()
        => (State & F.SF) == 0;

    [MethodImpl(Inline)]
    public bit NP()
        => (State & F.PF) == 0;

    [MethodImpl(Inline)]
    public bit LT()
        => SF() != OF();

    [MethodImpl(Inline)]
    public bit A()
        => (State & F.CF) == 0 && (State & F.ZF) == 0;

    [MethodImpl(Inline)]
    public bit NA()
        => !A();

    [MethodImpl(Inline)]
    public bit Read(I i)
        => bit.test((uint)State, (byte)i);

    [MethodImpl(Inline)]
    public void Write(I index, bit b)
        => State = (F)bit.set((uint)State, (byte)index, b);

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
        => new StatusFlags(src);

    [MethodImpl(Inline)]
    public static implicit operator RFlagBits(StatusFlags src)
        => (RFlagBits)src.State;

    [MethodImpl(Inline)]
    public static implicit operator StatusFlags(StatusFlagBits src)
        => new StatusFlags(src);

    [MethodImpl(Inline)]
    public static implicit operator StatusFlagBits(StatusFlags src)
        => (StatusFlagBits)src.State;

    [MethodImpl(Inline)]
    public static explicit operator ushort(StatusFlags src)
        => (ushort)src.State;

    [MethodImpl(Inline)]
    public static explicit operator uint(StatusFlags src)
        => (uint)src.State;

    public static StatusFlags Zero => default;
}
