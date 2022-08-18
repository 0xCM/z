//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PolyBits
    {
        public static BfDataset<F,T> dataset<F,W,T>(asci64 name, NativeSize size)
            where F : unmanaged, Enum
            where W : unmanaged, Enum
            where T : unmanaged
                => new BfDataset<F,T>(name, size, Symbols.index<F>().Kinds.ToArray(), indices<F>(), widths<W>());

        public static BfDataset<F,T> dataset<F,T>(asci64 name, NativeSize size, params byte[] widths)
            where F : unmanaged, Enum
            where T : unmanaged
                => new BfDataset<F,T>(name, size, Symbols.index<F>().Kinds.ToArray(), indices<F>(), widths);

        public static BfDataset<F> dataset<F>(asci64 name, NativeSize size, params byte[] widths)
            where F : unmanaged,Enum
                => new BfDataset<F>(name, size, Symbols.kinds<F>().ToArray(), indices<F>(), widths);

        public static BfDataset<F> dataset<F>(asci64 name, NativeSize size, ReadOnlySpan<byte> widths)
            where F : unmanaged,Enum
                => new BfDataset<F>(name, size, Symbols.kinds<F>().ToArray(), indices<F>(), widths.ToArray());

        public static BfDataset dataset(asci64 name, NativeSize size, ReadOnlySpan<Char5Seq> fields, ReadOnlySpan<byte> widths)
            => new BfDataset(name, size, fields.ToArray(), mapi(fields, (i,x) => (x,(uint)i)).ToDictionary(), widths.ToArray());
    }
}