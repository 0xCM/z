//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class PipelineService<H>
        where H : PipelineService<H>, new()
    {
        /// <summary>
        /// Instantites the serice without initialization
        /// </summary>
        [MethodImpl(Inline)]
        protected static H @new() => new H();

        public static H create(IPipeline pipes)
        {
            var part = @new();
            part.Init(pipes);
            return part;
        }

        protected IPipeline Pipeline {get; private set;}

        protected EventSignal Signal {get; private set;}

        public void Init(IPipeline pipes)
        {
            Pipeline = pipes;
            Signal = pipes.Signal;
            Initialized();
        }

        protected virtual void Initialized()
        {

        }

        protected PipelineService()
        {

        }

        protected PipelineService(IPipeline pipes)
        {
            Init(pipes);
        }
    }
}