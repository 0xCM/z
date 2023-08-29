//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct LogSettings
{
    [MethodImpl(Inline), Op]
    public static LogSettings configure(PartName control, IDbArchive dst)
        => new (control, dst.Root, EmptyString);

    /// <summary>
    /// The status log path
    /// </summary>
    public readonly FilePath StatusPath;

    /// <summary>
    /// The error log path
    /// </summary>
    public readonly FilePath ErrorPath;

    public LogSettings(FilePath status, FilePath error)
    {
        StatusPath = status;
        ErrorPath = error;            
    }

    public LogSettings(PartName control, FolderPath root, string name)
    {
        var id = text.empty(name) ? control.Format() : $"{control.Format()}.{name}";
        var ts = sys.timestamp();
        StatusPath = root + FS.folder($"{id}/status") + FS.file($"{id}.status.{ts}", FS.Log);
        ErrorPath = root + FS.folder(id) + FS.file($"{id}.errors.{ts}", FS.Log);
    }

    public string Format()
        => StatusPath.ToUri().Format();

    public override string ToString()
        => Format();
}
