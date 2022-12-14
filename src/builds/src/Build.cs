//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;
    using D = Microsoft.Build.Definition;
    using C = Microsoft.Build.Construction;

    using static sys;

    [ApiHost]
    public partial class Build
    {
        [MethodImpl(Inline), Op]
        public static Sdk sdk(string name)
            => new Sdk(name);

        [MethodImpl(Inline), Op]
        public static PropertyGroup group(Property[] src)
            => new PropertyGroup(src);

        [MethodImpl(Inline), Op]
        public static TargetFramework framework(string value)
            => new TargetFramework(value);

        [MethodImpl(Inline)]
        public static Property<T> property<T>(T src)
            where T : struct, IProjectProperty<T>
                => new Property<T>(src);
        [Op]
        public static ProjectSpec project(FilePath src)
            => new(E.Project.FromFile(src.Name, new D.ProjectOptions {}), src);

        public static string format(ProjectSpec src)
        {
            var dst = text.emitter();
            for(var i=0; i<src.Props.Count; i++)
                dst.AppendLine(src.Props[i].Format());
            for(var i=0; i<src.Items.Count; i++)
                dst.Append(src.Items[i].Format());
            return dst.Emit();
        }

        public static ReadOnlySeq<ProjectItem> items(ProjectSpec src, Func<ProjectItem,bool> predicate)
            => src.Items.Where(predicate);

        public static Solution sln(FilePath src)
        {
            var sln = new Solution();
            var data = C.SolutionFile.Parse(src.Name);
            var projects = data.ProjectsInOrder.Index().Where(p => p != null);
            var count = projects.Count;
            var dst = sys.alloc<SlnProject>(count);
            sln.Path = src;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref projects[i];
                ref var project = ref seek(dst,i);
                project.Path = FS.path(input?.AbsolutePath ?? EmptyString);
                project.ProjectName = input?.ProjectName ?? EmptyString;
                project.ProjectGuid = Guid.Parse(input.ProjectGuid);
                if(input.Dependencies != null)
                    project.Dependencies = input.Dependencies.Map(x => Guid.Parse(x));
                else
                    project.Dependencies = sys.empty<Guid>();
                if(input.ProjectConfigurations != null)
                {
                    var configs = input.ProjectConfigurations.Values.Index();
                    project.Configurations = sys.alloc<SlnProjectConfig>(configs.Count);

                    for(var j=0; j<configs.Count; j++)
                        define(configs[i], ref project.Configurations[j]);
                }
                else
                    project.Configurations = sys.empty<SlnProjectConfig>();
            }

            return sln;
        }

        static ref SlnProjectConfig define(in C.ProjectConfigurationInSolution src, ref SlnProjectConfig dst)
        {
            dst.Build = src.IncludeInBuild;
            dst.FullName = src.FullName;
            dst.SimpleName = src.ConfigurationName;
            dst.Platform = src.PlatformName;
            return ref dst;
        }

    }
}