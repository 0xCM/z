//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitGrid;

    public class BitGridEmitter
    {
        // public static string export<M,N,T>(BitGrid16<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
        //     where M: unmanaged, ITypeNat
        //     where N: unmanaged, ITypeNat
        //     where T: unmanaged
        //         => export<M,N>(g.Content, dir, showrow, label);

        // public static string export<M,N,T>(BitGrid32<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
        //     where M: unmanaged, ITypeNat
        //     where N: unmanaged, ITypeNat
        //     where T: unmanaged
        //         => export<M,N>(g.Content, dir, showrow, label);

        // public static string export<M,N,T>(BitGrid64<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
        //     where M: unmanaged, ITypeNat
        //     where N: unmanaged, ITypeNat
        //     where T: unmanaged
        //         => export<M,N>(g.Content, dir, showrow, label);

        /// <summary>
        /// Exports a grid report to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string export<M,N,T>(BitGrid128<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => export<M,N,T>(g.Data, dir, showrow, label);

        /// <summary>
        /// Exports a grid report to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string export<M,N,T>(BitGrid256<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => export<M,N,T>(g.Data, dir, showrow, label);

        // public static string export<M,N,T>(SubGrid16<M,N,T> g, FS.FolderPath dir, bool showrow = false,  [CallerName] string label = null)
        //     where M: unmanaged, ITypeNat
        //     where N: unmanaged, ITypeNat
        //     where T: unmanaged
        //         => export<M,N>(g.Data, dir, showrow, label);

        // public static string export<M,N,T>(SubGrid32<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
        //     where M: unmanaged, ITypeNat
        //     where N: unmanaged, ITypeNat
        //     where T: unmanaged
        //         => export<M,N>(g.Data, dir, showrow, label);

        // public static string export<M,N,T>(SubGrid64<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
        //     where M: unmanaged, ITypeNat
        //     where N: unmanaged, ITypeNat
        //     where T: unmanaged
        //         => export<M,N>(g.Content, dir, showrow, label);

        /// <summary>
        /// Exports a grid report to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string export<M,N,T>(SubGrid128<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => export<M,N,T>(g.Data, dir, showrow, label);

        /// <summary>
        /// Exports a grid report to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string export<M,N,T>(SubGrid256<M,N,T> g, FS.FolderPath dir, bool showrow = false, [CallerName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => export<M,N,T>(g.Data, dir, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid16<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid32<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid64<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid128<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid256<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid16<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid32<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid64<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid128<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid256<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N>(ushort data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
                => text.join(Eol,title(label, n16, default(M), default(N), default(ushort)), HeaderSep, format<M,N>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N>(uint data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
                => text.join(Eol,title(label, n32, default(M), default(N), default(uint)), HeaderSep, format<M,N>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N>(ulong data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
                => text.join(Eol,title(label, n64, default(M), default(N), default(ulong)), HeaderSep, format<M,N>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N,T>(Vector128<T> data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => text.join(Eol,title(label, n128, default(M), default(N), default(T)), HeaderSep, format<M,N,T>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N,T>(Vector256<T> data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => text.join(Eol,title(label, n256, default(M), default(N), default(T)), HeaderSep, format<M,N,T>(data,showrow));

        static string HeaderSep
            => new string('-',80);

        static FS.FileName filename<W,M,N,T>(string label, W w, M m = default, N n = default, T t = default)
            where W : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => FS.file($"{label}_{sigtext(w,m,n,t)}",FS.ext("grid"));

        /// <summary>
        /// Creates a grid writer predicated on type parameters
        /// </summary>
        /// <param name="label">The grid label</param>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cel type representative</param>
        /// <typeparam name="W">The grid width type</typeparam>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static StreamWriter writer<W,M,N,T>(FS.FolderPath dir, [CallerName] string label = null, W w = default, M m = default, N n = default, T t = default)
            where W: unmanaged, ITypeNat
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => (dir + filename(label,w,m,n,t)).Writer();

        /// <summary>
        /// Exports grid data to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string export<M,N>(FS.FolderPath dir, ushort g, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
        {
            var data = report<M,N>(g,showrow,label);
            using var sink = writer(dir, label,n16, default(M), default(N), default(ushort));
            sink.WriteLine(data);
            sink.Flush();
            return data;
        }

        /// <summary>
        /// Exports grid data to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string export<M,N>(FS.FolderPath dir, uint g, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
        {
            var data = report<M,N>(g,showrow,label);
            using var sink = writer(dir, label,n32, default(M), default(N), default(uint));
            sink.WriteLine(data);
            sink.Flush();
            return data;
        }

        /// <summary>
        /// Exports grid data to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string export<M,N>(FS.FolderPath dir, ulong g, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
        {
            var data = report<M,N>(g,showrow,label);
            using var sink = writer(dir, label,n64, default(M), default(N), default(ulong));
            sink.WriteLine(data);
            sink.Flush();
            return data;
        }

        /// <summary>
        /// Exports grid data to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string export<M,N,T>(Vector128<T> g, FS.FolderPath dir, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
        {
            var data = report<M,N,T>(g,showrow,label);
            using var sink = writer(dir, label,n128, default(M), default(N), default(T));
            sink.WriteLine(data);
            sink.Flush();
            return data;
        }

        /// <summary>
        /// Exports grid data to a file
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indicies should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string export<M,N,T>(Vector256<T> g, FS.FolderPath dir, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
        {
            var data = report<M,N,T>(g,showrow,label);
            using var sink = writer(dir, label,n256, default(M), default(N), default(T));
            sink.WriteLine(data);
            sink.Flush();
            return data;
        }
    }
}