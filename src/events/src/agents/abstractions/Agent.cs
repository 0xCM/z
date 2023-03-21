//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines base system agent abstraction
    /// </summary>
    public abstract class Agent : IAgent
    {
        public IAgentContext Context {get;}

        public event OnAgentTransition StateChanged;

        AgentStatus _State;

        /// <summary>
        /// Identifies the server to which the agent belongs
        /// </summary>
        public uint Part {get;}

        /// <summary>
        /// Identifies the agent relative to the server
        /// </summary>
        /// <remarks>
        /// There are three special cases to note:
        /// 1. The server itself is a service agent and will always be assigned and Id of 0
        /// 2. The server process, which more or less serves the same role as the Windows SCM,
        /// is always assigned an agent id of 1
        /// 3. The server complex, which serves as the bounding box for synthetic servers, agents,
        /// etc, is also a service agent. It will be assigned UInt32.MaxValue which will be considered
        /// an invalid id for any other agent
        /// </remarks>
        public uint HostId {get;}

        protected Agent(IAgentContext context, AgentIdentity id)
        {
            Part = id.PartId;
            HostId = id.HostId;
            Context = context;
            context.Register(this);
            State = AgentStatus.Created;
        }

        /// <summary>
        /// Specifies the current agent status
        /// </summary>
        public AgentStatus State
        {
            get => _State;

            protected set
            {
                if(_State == value)
                    return;

                var transition = new AgentTransition((Part,HostId), 0ul, _State, value);
                _State = value;

                Context.EventLog.AgentTransitioned(transition);
                StateChanged?.BeginInvoke(transition, new AsyncCallback(x =>{}), this);
            }
        }

        void DoRun()
        {
            State = AgentStatus.Running;
            OnRun();
        }

        void DoStop()
        {
            State = AgentStatus.Stopping;
            OnStop();
            State = AgentStatus.Stopped;
        }

        void DoStart()
        {
            if(State == AgentStatus.Running)
                return;

            State = AgentStatus.Starting;
            OnStart();
            State = AgentStatus.Started;
            DoRun();
        }

        void DoTerminate()
        {
            if(State == AgentStatus.Running)
                Stop().Wait();

            State = AgentStatus.Terminating;
            OnTerminate();
            State = AgentStatus.Terminated;
        }

        void DoConfigure(dynamic config)
        {
            if(State == AgentStatus.Created || State == AgentStatus.Stopped)
            {
                State = AgentStatus.Configuring;
                OnConfigure(config);
                State = AgentStatus.Configured;
            }
        }

        /// <summary>
        /// Terminates the agent,releasing any captured resources
        /// </summary>
        public async Task Terminate()
            => await Task.Factory.StartNew(DoTerminate);

        /// <summary>
        /// Configures the agent prior to a run
        /// </summary>
        /// <param name="config">The agent-specific configuration data</param>
        public async Task Configure(dynamic config)
             => await Task.Factory.StartNew(() => DoConfigure(config));

        /// <summary>
        /// Starts the agent from a running state
        /// </summary>
        public async Task Start()
            => await Task.Factory.StartNew(DoStart);

        /// <summary>
        /// Starts the agent from a stopped state
        /// </summary>
        public async Task Stop()
            => await Task.Factory.StartNew(DoStop);

        /// <summary>
        /// Terminates the agent
        /// </summary>
        public virtual void Dispose()
            => Terminate().Wait();

        protected virtual void OnConfigure(dynamic config) { }

        protected virtual void OnRun() { }

        protected virtual void OnStop() { }

        protected virtual void OnStart() { }

        protected virtual void OnTerminate() { }
    }
}