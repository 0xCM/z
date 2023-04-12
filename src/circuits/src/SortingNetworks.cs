//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct SortingNetworks
    {
        public static SortingNetwork<T> define<T>()
            where T : unmanaged
        {
            var channels = alloc<Comparator<T>>(6);
            var i=0;
            seek(channels, i++) = new Comparator<T>();
            seek(channels, i++) = new Comparator<T>();
            seek(channels, i++) = new Comparator<T>();
            seek(channels, i++) = new Comparator<T>();
            seek(channels, i++) = new Comparator<T>();
            seek(channels, i++) = new Comparator<T>();
            return new SortingNetwork<T>(channels);
        }

        public static void run(ITextEmitter dst)
        {
            var sorter = SortingNetworks.define<byte>();
            run(sorter, dst);

            byte x0 = 9, x1 = 5, x2 = 2, x3 = 6;
            run(x0,x1,x2,x3,sorter, dst);

        }

        public static void run(SortingNetwork<byte> sorter, ITextEmitter dst)
        {
            byte x0 = 9, x1 = 5, x2 = 2, x3 = 6;
            sorter.Send(x0, x1, x2, x3, out var y0, out var y1, out var y2, out var y3);
            dst.WriteLine(string.Format("{0} -> {1}", x0, y0));
            dst.WriteLine(string.Format("{0} -> {1}", x1, y1));
            dst.WriteLine(string.Format("{0} -> {1}", x2, y2));
            dst.WriteLine(string.Format("{0} -> {1}", x3, y3));
        }

        public static void run<T>(T x0, T x1, T x2, T x3, SortingNetwork<T> sorter, ITextEmitter dst)
            where T : unmanaged
        {
            sorter.Send(x0, x1, x2, x3, out var y0, out var y1, out var y2, out var y3);
            dst.WriteLine(string.Format("{0} -> {1}", x0, y0));
            dst.WriteLine(string.Format("{0} -> {1}", x1, y1));
            dst.WriteLine(string.Format("{0} -> {1}", x2, y2));
            dst.WriteLine(string.Format("{0} -> {1}", x3, y3));
        }
    }
}