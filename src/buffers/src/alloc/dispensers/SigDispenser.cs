//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static NativeSigs;

public class SigDispenser : Dispenser<SigDispenser>, ISigDispenser
{
    readonly MemoryDispenser Memory;

    readonly StringDispenser Strings;

    internal SigDispenser(MemoryDispenser mem, StringDispenser strings)
        : base(false)
    {
        Memory = mem;
        Strings = strings;
    }

    public SigDispenser()
        : base(true)
    {
        Memory = Dispense.memory();
        Strings = Dispense.strings();
    }

    protected override void Dispose()
    {
        (Memory as IDisposable).Dispose();
        (Strings as IDisposable).Dispose();
    }

    [MethodImpl(Inline)]
    Operand Operand(Label name, NativeType type, Modifier mod = default)
        => new Operand(name, type, mod);

    public NativeSigRef Sig(ReadOnlySpan<char> scope, ReadOnlySpan<char> opname, NativeType ret, params Operand[] opspecs)
    {
        var id = next();
        var count = (byte)opspecs.Length;
        var size = size<byte>() + size<StringRef>() + (count + 1)* NativeSigs.Operand.StorageSize;
        var data = Memory.Memory(size);
        var dst = new NativeSigRef(id, data);
        dst.Scope = Strings.String(scope);
        dst.Name = Strings.String(opname);
        dst.OperandCount = count;
        dst.Return = Operand("return", ret);

        for(var i=0; i<count; i++)
        {
            ref readonly var spec = ref skip(opspecs,i);
            dst[i] = Operand(spec.Name, spec.Type, spec.Modifiers);
        }

        return dst;
    }

    public NativeSigRef Sig(NativeSig src)
        => Sig(src.Scope, src.Name, src.ReturnType, src.Operands);
}
