//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = Microsoft.Extensions.DependencyModel;
    using D = JsonDeps;

    using static sys;
    using static JsonDeps;

    using api = JsonDeps;

    public class ProjectDeps
    {
        readonly M.DependencyContext Source;

        readonly Index<M.CompilationLibrary> _CompilationLibraries;

        readonly Index<M.RuntimeLibrary> _RuntimeLibraries;

        readonly M.CompilationOptions _Options;

        readonly Index<M.RuntimeFallbacks> RuntimeGraph;

        internal ProjectDeps(M.DependencyContext src)
        {
            if(src != null)
            {
                Source = src;
                _CompilationLibraries = src.CompileLibraries.Array();
                _RuntimeLibraries = src.RuntimeLibraries.Array();
                _Options = src.CompilationOptions;
                RuntimeGraph = src.RuntimeGraph.Array();
            }
            else
            {
                _CompilationLibraries = sys.empty<M.CompilationLibrary>();
                _RuntimeLibraries = sys.empty<M.RuntimeLibrary>();
                RuntimeGraph = sys.empty<M.RuntimeFallbacks>();
            }
        }

        public Options Options()
        {
            if(_Options != null)
            {
                var dst = new Options();
                return api.extract(_Options, ref dst);
            }
            else
                return D.Options.Empty;
        }

        public TargetInfo Target()
        {
            var dst = new TargetInfo();
            return api.extract(Source, ref dst);
        }

        public Index<RuntimeLib> RuntimeLibs()
        {
            var count = _RuntimeLibraries.Count;
            if(count != 0)
            {
                var dst = sys.alloc<RuntimeLib>(count);
                var src = _RuntimeLibraries;
                for(var i=0; i<count; i++)
                    api.extract(src[i], ref dst[i]);
                return dst;
            }
            else
            {
                return sys.empty<RuntimeLib>();
            }
        }

        public Index<JsonGraph> RuntimeFallbacks()
        {
            var src = RuntimeGraph;
            var count = src.Count;
            var dst = new JsonGraph();
            var nodes = list<JsonGraph>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var f = ref src[i];
                nodes.Add(new JsonGraph(f.Runtime, f.Fallbacks.Array()));
            }
            return nodes.ToIndex();
        }

        public Index<Library> Libs()
        {
            var count = _CompilationLibraries.Count;
            var dst = alloc<Library>(count);
            var src = _CompilationLibraries.View;
            for(var i=0; i<count; i++)
                api.extract(src[i], ref dst[i]);
            return dst;
        }
    }
}