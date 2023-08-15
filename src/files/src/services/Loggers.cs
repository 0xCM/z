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

        public static IWfEmissions emission(Assembly src, Timestamp ts)
            => new EmissionLog(emissions(src,ts));

        static FilePath emissions(Assembly src, Timestamp ts)
            => AppSettings.Default.DbRoot().Scoped($"logs/{src.PartName()}").Path(FS.file($"{src.PartName()}.emissions.{ts}.csv"));

        public static IWfEmissions emission(FilePath dst)
            => new EmissionLog(dst);

        public static IWorkerLog worker(FilePath dst, bool delete = true)
        {
            if(delete)
                dst.Delete();
            var errors = dst.ChangeExtension(FS.ext("errors.log"));
            if(delete)
                errors.Delete();
            return worker(new LogSettings(dst, errors));
        }

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(LogSettings config)
            => new WorkerLog(config);

        [MethodImpl(Inline), Op]
        public static LogSettings configure(string name, IDbArchive dst)
            => new LogSettings(ExecutingPart.Name, dst.Root, name);

        [MethodImpl(Inline), Op]
        public static LogSettings configure(PartId part, IDbArchive dst)
            => new LogSettings(part, dst.Root, EmptyString);
    }
}