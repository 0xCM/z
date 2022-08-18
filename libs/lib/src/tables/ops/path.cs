//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct Tables
    {
        public static FS.FilePath path(FS.FolderPath dir, Type t)
            => t.Tag<RecordAttribute>().MapValueOrElse(a => dir + FS.file(a.TableId, FS.Csv), () => dir + FS.file(t.Name, FS.Csv));

        public static FS.FilePath path(FS.FolderPath dir, Type t, string subject)
            => t.Tag<RecordAttribute>().MapValueOrElse(
                    a => dir + FS.file(string.Format("{0}.{1}", a.TableId, subject), FS.Csv),
                    () => dir + FS.file(string.Format("{0}.{1}", t.Name, subject), FS.Csv));

        public static FS.FilePath path<T>(FS.FolderPath dir)
            where T : struct
                => path(dir, typeof(T));

        public static FS.FilePath path<T>(FS.FolderPath dir, string subject)
            where T : struct
                => path(dir, typeof(T), subject);

        public static FS.FolderPath subdir(FS.FolderPath dir, string subject)
            => dir + FS.folder(subject);

        public static FS.FolderPath subdir(FS.FolderPath dir, FS.FolderName subject)
            => dir + subject;

        public static FS.FolderPath subdir(FS.FolderPath dir, TableId id)
            => dir + FS.folder(id.Format());

        public static FS.FolderPath subdir(FS.FolderPath dir, Type t)
            => t.Tag<RecordAttribute>().MapValueOrElse(a => dir + FS.folder(a.TableId), () => dir + FS.folder(t.Name));

        public static FS.FolderPath subdir<T>(FS.FolderPath dir)
            where T : struct
                => subdir(dir, typeof(T));

        public static FS.FilePath subpath<T>(FS.FolderPath dir, string subject)
            where T : struct
                => subpath(dir, identify<T>(), subject);

        public static FS.FilePath subpath<S>(FS.FolderPath dir, TableId id, S subject)
            => dir + FS.folder(id.Format()) + FS.file(string.Format(EnvFolders.qualified, id, subject), FS.Csv);
    }
}