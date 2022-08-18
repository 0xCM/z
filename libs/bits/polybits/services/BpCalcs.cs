//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitPatterns;

    public class BpCalcs
    {
        public readonly BpDef Def;

        [MethodImpl(Inline)]
        public BpCalcs(in BpDef def)
        {
            Def = def;
        }

        public ref readonly asci32 Name
        {
            [MethodImpl(Inline)]
            get => ref Def.Name;
        }

        /// <summary>
        /// The pattern source
        /// </summary>
        public ref readonly BfOrigin Origin
        {
            [MethodImpl(Inline)]
            get => ref Def.Origin;
        }

        /// <summary>
        /// The pattern specification
        /// </summary>
        public ref readonly BitPattern Pattern
        {
            [MethodImpl(Inline)]
            get => ref Def.Pattern;
        }

        /// <summary>
        /// The width of the data represented by the pattern
        /// </summary>
        [MethodImpl(Inline)]
        public uint BitWidth()
            => api.bitwidth(Pattern);

        [MethodImpl(Inline)]
        public DataSize Size()
            => api.size(Pattern);

        /// <summary>
        /// The minimum amount of storage required to store the represented data
        /// </summary>
        [MethodImpl(Inline)]
        public NativeSize MinSize()
            => api.minsize(Pattern);

        /// <summary>
        /// A data type with size of <see cref='MinSize'/> or greater
        /// </summary>
        [MethodImpl(Inline)]
        public Type DataType()
            => api.datatype(Pattern);

        /// <summary>
        /// The segments in the field
        /// </summary>
        [MethodImpl(Inline)]
        public Index<BfSegModel> Segments()
            => api.segs(Pattern);

        [MethodImpl(Inline)]
        public BfModel Model()
            => api.model(Name, Pattern, Origin);

        [MethodImpl(Inline)]
        public Index<byte> SegWidths()
            => api.segwidths(Pattern);

        [MethodImpl(Inline)]
        public Index<string> Indicators()
            => api.indicators(Pattern);

        [MethodImpl(Inline)]
        public BpInfo Description()
            => api.describe(Name, Pattern, Origin);

        /// <summary>
        /// A semantic identifier
        /// </summary>
        [MethodImpl(Inline)]
        public string Descriptor()
            => api.descriptor(Pattern);

        [MethodImpl(Inline)]
        public string BitString(ulong value)
            => api.bitstring(Def, value);

        [MethodImpl(Inline)]
        public string BitString<T>(T value)
            where T : unmanaged
                => api.bitstring(Def, value);
    }
}