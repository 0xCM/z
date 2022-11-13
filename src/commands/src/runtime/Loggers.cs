//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Loggers
    {
        [MethodImpl(Inline), Op]
        public static EmissionLogEntry entry(in FileWritten src, out EmissionLogEntry dst)
        {
            dst.ExecToken = src.Token;
            dst.Target = src.Target;
            dst.FileType = src.Target.Ext;
            dst.Quantity = src.EmissionCount;
            dst.EventType = src.EmissionCount == 0 ? EmissionEventKind.Emitting : EmissionEventKind.Emitted;
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static EmissionLogEntry entry<T>(in WfTableFlow<T> src, out EmissionLogEntry dst)
            where T : struct
        {
            dst.ExecToken = src.Token;
            dst.Target = src.Target;
            dst.FileType = src.Target.Ext;
            dst.Quantity = src.EmissionCount;
            dst.EventType = src.EmissionCount == 0 ? EmissionEventKind.Emitting : EmissionEventKind.Emitted;
            return dst;
        }

        public static IWfEmissions emission(Assembly src, Timestamp ts)
            => new EmissionLog(emissions(src,ts));

        static FilePath emissions(Assembly src, Timestamp ts)
            => AppSettings.Default.DbRoot().Scoped($"logs/{src.PartName()}").Path(FS.file($"{src.PartName()}.emissions.{ts}.csv"));

        public static IWfEmissions emission(FilePath dst)
            => new EmissionLog(dst);

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(LogSettings config)
            => new WorkerLog(config);

        [MethodImpl(Inline), Op]
        public static LogSettings configure(string name, FolderPath dst)
            => new LogSettings(ExecutingPart.Name, dst, name);

        [MethodImpl(Inline), Op]
        public static LogSettings configure(PartId part, FolderPath dst)
            => new LogSettings(part, dst, EmptyString);
    }
}