//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct LogSettings
    {
        /// <summary>
        /// The status log path
        /// </summary>
        public readonly FilePath StatusPath;

        /// <summary>
        /// The error log path
        /// </summary>
        public readonly FilePath ErrorPath;

        public LogSettings(FilePath status, FilePath errors)
        {
            StatusPath = status;
            ErrorPath = errors;
        }

        public LogSettings(FS.FolderPath root)
        {
            var ts = sys.timestamp();
            var control = ExecutingPart.Assembly;
            var id = control.Format();
            StatusPath = root + FS.folder($"{control.Format()}/status") + FS.file($"{id}.status.{ts}", FS.Log);
            ErrorPath = root + FS.folder(control.Format()) + FS.file($"{id}.errors.{ts}", FS.Log);
        }

        public LogSettings(PartId control, FS.FolderPath root, string name)
        {
            var id = text.empty(name) ? control.Format() : $"{control.Format()}.{name}";
            var ts = sys.timestamp();
            StatusPath = root + FS.folder($"{id}/status") + FS.file($"{id}.status.{ts}", FS.Log);
            ErrorPath = root + FS.folder(id) + FS.file($"{id}.errors.{ts}", FS.Log);
        }

        public string Format()
            => $"{nameof(StatusPath)}:{StatusPath.ToUri()}" + " | " + $"{nameof(ErrorPath)}:{ErrorPath.ToUri()}";

        public override string ToString()
            => Format();
    }
}