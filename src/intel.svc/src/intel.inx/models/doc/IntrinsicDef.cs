//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class IntrinsicsDoc
{
    public record struct IntrinsicDef : IComparable<IntrinsicDef>
    {
        public const string ElementName = "intrinsic";

        public @string tech;

        public @string name;

        public @string content;

        public InstructionTypes types;

        public CpuIdMembership CPUID;

        public Category category;

        public Return @return;

        public Parameters parameters;

        public Description description;

        public Operation operation;

        public Instructions instructions;

        public Header header;

        public FunctionSig Sig()
            => new FunctionSig(@return, name, parameters);

        public int CompareTo(IntrinsicDef src)
        {
            var result = CPUID.Format().CompareTo(src.CPUID.Format());
            if(result == 0)
                result = name.CompareTo(src.name);
            return result;
        }

        static IntrinsicDef init()
        {
            var dst = new IntrinsicDef();
            dst.tech = EmptyString;
            dst.name = EmptyString;
            dst.content = EmptyString;
            dst.types = new ();
            dst.CPUID = new ();
            dst.category = EmptyString;
            dst.@return = Return.Empty;
            dst.parameters = new ();
            dst.description = EmptyString;
            dst.operation = new (list<TextLine>());
            dst.instructions = new ();
            dst.header = EmptyString;
            return dst;
        }

        public static IntrinsicDef Empty => init();
    }
}
