//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public readonly partial struct AsmPrototypes
    {
        [Op]
        public static ref byte range_check(byte[] src)
            => ref core.seek(src,3);

        const string dot = ".";

        const string prototypes = nameof(prototypes) + dot;

        const string eval = nameof(eval);

        const string evaluator = nameof(evaluator);

        const string contracted = nameof(contracted);

        const string client = nameof(client);

        const string loops = nameof(loops);

        const string dispatcher = nameof(dispatcher);

        const string branches = nameof(branches);

        const string extensions = nameof(extensions);

        const string store = nameof(store);

        const string @switch = nameof(@switch);

        const string calls = nameof(calls);

        const string targets = nameof(targets);

        public const string calc8 = nameof(calc8);

        public const string calc64 = nameof(calc64);

        public const string pointers = nameof(pointers);

        [ApiHost(prototypes + branches)]
        public readonly partial struct Branches
        {
        }
    }
}