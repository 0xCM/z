//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    [ApiHost]
    public static class EcmaContext
    {
        [MethodImpl(Inline), Op]
        public static ModuleContext Context(this Module row, IEcmaReader reader)
            => new ModuleContext(reader,row);

        [MethodImpl(Inline), Op]
        public static FieldContext Context(this Field row, IEcmaReader reader)
            => new FieldContext(reader,row);
    }
}