//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class NativeSigDispenser : Dispenser<NativeSigDispenser>, ISigDispenser
    {
        readonly MemoryDispenser Memory;

        readonly StringDispenser Strings;

        readonly LabelDispenser Labels;

        readonly ConcurrentDictionary<Hex64,NativeSigRef> Dispensed;

        internal NativeSigDispenser(MemoryDispenser mem, StringDispenser strings, LabelDispenser labels)
            : base(false)
        {
            Memory = mem;
            Strings = strings;
            Labels = labels;
            Dispensed = new();
        }

        public NativeSigDispenser()
            : base(true)
        {
            Memory = Dispense.memory();
            Strings = Dispense.strings();
            Labels = Dispense.labels();
            Dispensed = new();
        }

        protected override void Dispose()
        {
            (Memory as IDisposable).Dispose();
            (Strings as IDisposable).Dispose();
            (Labels as IDisposable).Dispose();
        }

        [MethodImpl(Inline)]
        NativeOp Operand(Label name, NativeType type, NativeOpMod mod = default)
            => new NativeOp(name, type, mod);

        public NativeSigRef Sig(string scope, string opname, NativeType ret, params NativeOpDef[] opspecs)
        {
            var id = next();
            var count = (byte)opspecs.Length;
            var size = size<byte>() + size<StringRef>() + (count + 1)*NativeOp.StorageSize;
            var data = Memory.Memory(size);
            var dst = new NativeSigRef(id, data);
            dst.Scope = Strings.String(scope);
            dst.Name = Strings.String(opname);
            dst.OperandCount = count;
            dst.Return = Operand("return", ret);

            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref skip(opspecs,i);
                dst[i] = Operand(spec.Name, spec.Type, spec.Mod);
            }

            return dst;
        }

        public NativeSigRef Sig(NativeSigSpec src)
            => Sig(src.Scope, src.Name, src.ReturnType, src.Operands);
    }
}