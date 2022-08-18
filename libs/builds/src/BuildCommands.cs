//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Build;

    public class BuildCommands
    {
        public static BuildProjectCmd project(FS.FilePath src)
        {
            var dst = new BuildProjectCmd();
            dst.Platform = "Any Cpu";
            dst.Configuration = "Release";
            dst.Graph = true;
            dst.MaxCpuCount = (uint)Environment.ProcessorCount;
            dst.Verbosity = LogVerbosity.minimial;
            dst.ProjectPath = src;
            return dst;
        }

        public static string format(in BuildProjectCmd src)
        {
            var dst = text.emitter();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void render(in BuildProjectCmd src, ITextEmitter dst)
        {
            const string PropertySpec = "/p:{0}={1}";

            const string Flag = "-{0}";

            const string OptionValue = "-{0}:{1}";

            const string QuotedOptionAssign ="-{0}:{1}=" + RpOps.QuotedSlot2;

            const string QuotedPropertySpec = "/p:{0}=" + RpOps.QuotedSlot1;

            dst.Append("dotnet build");

            dst.AppendSpace();
            dst.Append(src.ProjectPath.Format(PathSeparator.BS));

            dst.AppendSpace();
            dst.AppendFormat(PropertySpec, nameof(src.Configuration), src.Configuration);

            dst.AppendSpace();
            dst.AppendFormat(QuotedPropertySpec, nameof(src.Platform), src.Platform);

            if(src.LogFile.IsNonEmpty)
            {
                dst.AppendSpace();
                dst.AppendFormat(Flag, "fl");
                dst.AppendSpace();
                dst.AppendFormat(QuotedOptionAssign, "flp", nameof(src.LogFile), src.LogFile.Format(PathSeparator.BS));
                if(src.Verbosity != 0)
                    dst.AppendFormat(";{0}={1} ","verbosity", src.Verbosity);
            }

            if(src.MaxCpuCount != 0)
            {
                dst.AppendSpace();
                dst.AppendFormat(OptionValue, nameof(src.MaxCpuCount), src.MaxCpuCount);
            }

            if(src.Graph)
            {
                dst.AppendSpace();
                dst.AppendFormat(OptionValue, "graph", src.Graph);
            }
        }
    }
}