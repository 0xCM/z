//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiNameParts;

    [LiteralProvider(api)]
    public readonly struct ApiNames
    {
        public const string Tuples = tuples;

        public const string ClrHandles = clr + dot + handles;

        const string formatter = nameof(formatter);

        // ~~ Symbolic
        // ~~ -----------------------------------------------------------------------------------------

        public const string ConstBytes256 = @const + dot + bytes + dot + "256";

        public const string Seq = seq;

        const string v512 = nameof(v512);

        public const string Vex512 = vex + dot + v512;

        public const string VexReflex = vex + dot + reflex;

        public const string Cmd = cmd + dot + core;

        public const string BitSeqApi = bits + dot + seq + dot + api;

        public const string BitSeq = bits + dot + seq;

        public const string AsmSemanticRender = asm + dot + semantic + dot + render;

        public const string AsmSemanticArchive = asm + dot + semantic + dot + archive;

        public const string FxSlots = fx + dot + slots;

        public const string dot = ApiNameParts.dot;

        public const string sequences = nameof(sequences);

        const string samples = nameof(samples);

        const string catalog = nameof(catalog);

        public const string Algorithms = algorithms;

        // ~~ LinqX
        // ~~ -----------------------------------------------------------------------------------------

        public const string LinqXPress = linq + dot + expressions;

        public const string LinqXQuery = linq + dot + expressions + dot + query;

        public const string LinqXFunc = linq + dot + expressions + dot + functions;

        public const string LinqXFuncX = linq + dot + expressions + dot + extensions;

        public const string algorithms = nameof(algorithms);

        public const string Partition = math + dot + partition;

        public const string CheckClose = checks + dot + "close";

        public const string FilePathParser = parsers + dot + files + dot + paths;

        public const string StaticBuffers = buffers + dot + "static";
    }
}