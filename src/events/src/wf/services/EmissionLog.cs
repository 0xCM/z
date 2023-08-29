//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.IO;

public class EmissionLog : IEmissionLog
{
    public static IEmissionLog open(FilePath dst)
        => new EmissionLog(dst);

    public static IEmissionLog open(Assembly src, Timestamp ts)
        => new EmissionLog(AppSettings.Default.DbRoot().Scoped($"logs/{src.PartName()}").Path(FS.file($"{src.PartName()}.emissions.{ts}.csv")));

    [MethodImpl(Inline), Op]
    public static EmissionLogEntry entry(in FileEmission src, out EmissionLogEntry dst)
    {
        dst.ExecToken = src.Token;
        dst.Target = src.Target;
        dst.FileType = src.Target.Ext;
        dst.Quantity = src.Count;
        dst.Stage = src.Count == 0 ? EmissionStage.Emitting : EmissionStage.Emitted;
        return dst;
    }

    [MethodImpl(Inline), Op, Closures(UnsignedInts)]
    public static EmissionLogEntry entry<T>(in TableFlow<T> src, out EmissionLogEntry dst)
    {
        dst.ExecToken = src.Token;
        dst.Target = src.Target;
        dst.FileType = src.Target.Ext;
        dst.Quantity = src.EmissionCount;
        dst.Stage = src.EmissionCount == 0 ? EmissionStage.Emitting : EmissionStage.Emitted;
        return dst;
    }

    readonly FileStream Stream;

    readonly FilePath Target;

    readonly ICsvFormatter<EmissionLogEntry> Formatter;

    bool Closed;

    public EmissionLog(FilePath dst)
    {
        Closed = false;
        Target = dst;
        Target.EnsureParentExists().Delete();
        Stream = Target.Stream();
        Formatter = CsvTables.formatter<EmissionLogEntry>();
        FS.write(Formatter.FormatHeader() + Eol, Stream);
    }

    public bool IsEmpty
    {
        get => Target.IsEmpty;
    }

    public bool IsNonEmpty
    {
        get => Target.IsNonEmpty;
    }

    public string Format()
        => Target.ToUri().Format();
    
    public override string ToString()
        => Format();

    public void Close()
    {
        if(!Closed)
        {
            Stream.Flush();
            Stream.Dispose();
            Closed = true;
        }
    }

    public void Dispose()
    {
        Close();
    }

    public ref readonly FileEmission LogEmission(in FileEmission flow)
    {
        try
        {
            FS.write(Formatter.Format(entry(flow, out _)) + Eol, Stream);
        }
        catch(Exception error)
        {
            Console.WriteLine(error);
        }

        return ref flow;
    }

    public ref readonly TableFlow<T> LogEmission<T>(in TableFlow<T> flow)
    {
        try
        {
            FS.write(Formatter.Format(entry(flow, out _)) + Eol, Stream);
        }
        catch(Exception error)
        {
            Console.WriteLine(error);
        }
        return ref flow;
    }
}
