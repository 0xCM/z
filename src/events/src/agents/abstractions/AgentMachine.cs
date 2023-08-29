//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines base system agent abstraction
/// </summary>
public abstract class AgentMachine : IAgentMachine
{
    public IAgentContext Context {get;}

    public event OnAgentTransition Transition;

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

    protected AgentMachine(IAgentContext context, AgentIdentity id)
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

            var transition = new AgentTransition((Part,HostId), sys.now(), _State, value);
            _State = value;

            Context.Sink.AgentTransitioned(transition);
            Transition?.BeginInvoke(transition, new AsyncCallback(x =>{}), this);
        }
    }

    /// <summary>
    /// Starts the agent
    /// </summary>
    public async Task Start()
    {
        if(State == AgentStatus.Running)
            return;

        State = AgentStatus.Starting;
        await Starting();
        State = AgentStatus.Started;
        State = AgentStatus.Running;
        await Running();
    }

    /// <summary>
    /// Starts the agent from a stopped state
    /// </summary>
    public async Task Stop()
    {
        State = AgentStatus.Stopping;
        await Stopping();
        State = AgentStatus.Stopped;
    }

    protected virtual async Task Starting() 
        => await sys.start(() => {});

    protected virtual async Task Running() 
        => await sys.start(() => {});

    protected virtual async Task Stopping() 
        => await sys.start(() => {});

    protected virtual async Task Terminating() 
        => await sys.start(() => {});
}
