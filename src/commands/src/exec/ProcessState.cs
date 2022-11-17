//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProcessState : IDisposable
    {
        static ConcurrentDictionary<ProcessId,ExecutingProcess> _Executing = new();

        static ConcurrentDictionary<ProcessId,ExecutedProcess> _Completed = new();

        public static void enlist(ExecutingProcess spec)
            => _Executing.TryAdd(spec.Id,spec);

        public static void remove(ExecutedProcess exec)
        {
            if(_Executing.TryRemove(exec.Id))
            {
                _Completed.TryAdd(exec.Id, exec);
            }
        }

        public static ICollection<ExecutingProcess> Executing()
            => _Executing.Values;

        public static ICollection<ExecutedProcess> Finished()
            => _Completed.Values;

        public void Dispose()
        {
            sys.iter(_Executing.Values, p => p.Adapted.Close());
        }
    }
}