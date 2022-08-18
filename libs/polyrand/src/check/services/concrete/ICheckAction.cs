//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckAction : ITester, ITestResultSink
    {
        /// <summary>
        /// Manages the execution of an action that performs a validation exercise
        /// </summary>
        /// <param name="f">The action under test</param>
        /// <param name="name">The action name</param>
        void CheckAction(Action f, string name)
        {
            var succeeded = true;
            var count = Time.counter(true);
            try
            {
                f();
            }
            catch(Exception e)
            {
                term.errlabel(e, name);
                succeeded = false;
            }
            finally
            {
                ReportCaseResult(name, succeeded, count);
            }
        }

        /// <summary>
        /// Captures the outcome of an action invocation, identified by a supplied label
        /// </summary>
        /// <param name="f">The action to invoke</param>
        /// <param name="label">The case label</param>
        TestCaseRecord TestAction(Action f, string label)
        {
            var succeeded = true;
            var clock = Time.counter(true);

            try
            {
                f();
                return TestCaseRecord.define(label, true, clock);
            }
            catch(Exception e)
            {
                Print(e, label);
                return TestCaseRecord.define(label, false, clock);
            }
        }

        /// <summary>
        /// Captures the outcome of an action invocation, identified by a supplied label
        /// </summary>
        /// <param name="f">The action to invoke</param>
        /// <param name="label">The case label</param>
        TestCaseRecord TestAction<T>(Action<T> f, T point, string label)
        {
            var succeeded = true;

            var clock = Time.counter(true);
            try
            {
                f(point);
                return TestCaseRecord.define(label, true, clock);
            }
            catch(Exception e)
            {
                Print(e, label);
                return TestCaseRecord.define(label, false, clock);
            }
        }

        /// <summary>
        /// Captures the outcome of action invocation, identified by a parametrically-specialized label
        /// </summary>
        /// <param name="f">The action to invoke</param>
        /// <param name="label">The case label to specialize</param>
        /// <typeparam name="T">The label specialization type</typeparam>
        TestCaseRecord TestAction<T>(Action f, string label)
            where T : unmanaged
        {
            var succeeded = true;

            var clock = Time.counter(true);
            try
            {
                f();
                return TestCaseRecord.define(name<T>(label), true, clock);
            }
            catch(Exception e)
            {
                Print(e, label);
                return TestCaseRecord.define(name<T>(label), false, clock);
            }
        }
    }
}