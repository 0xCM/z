//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AssemblyRefs : ReadOnlySeq<AssemblyName>
    {
        public readonly AssemblyName Source;

        public AssemblyRefs(AssemblyName[] src)
            : base(src)
        {

        }

        public ReadOnlySpan<AssemblyName> Targets
        {
            [MethodImpl(Inline)]
            get => View;
        }

        public override string Format()
        {
            var dst = text.emitter();
            dst.AppendFormat("{0} -> " + "{", Source.SimpleName());
            for(var i=0; i<Count; i++)
            {
                if(i!=0)
                    dst.Append(", ");
                dst.Append(this[i].SimpleName());
            }
            dst.Append("}");

            return dst.Emit();
        }
    }
}