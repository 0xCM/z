//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Build.Utilities;
    using Microsoft.Build.Framework;

    public class BuildEventLog : Logger
    {
        FilePath LogPath;

        public override void Initialize(IEventSource src)
        {
            src.BuildStarted += Handle;
            src.BuildFinished += Handle;
            src.CustomEventRaised += Handle;
            src.MessageRaised += Handle;
            src.ProjectStarted +=  Handle;
            src.ProjectFinished += Handle;
            src.ErrorRaised += Handle;
            src.StatusEventRaised += Handle;
            src.TargetFinished += Handle;
            src.TargetStarted += Handle;
            src.TaskStarted += Handle;
            src.TaskFinished += Handle;
            src.WarningRaised += Handle;

            if (Parameters == null)
                throw new LoggerException("Log file unspecified.");

            var parameters = Parameters.SplitClean(Chars.Semicolon);
            if(parameters.Length == 0)
                throw new LoggerException("Log file unspecified.");


            var logFile = parameters[0];
            if (text.blank(logFile))
                throw new LoggerException("Log file unspecified.");

            LogPath = FS.path(logFile);

        }

        public override LoggerVerbosity Verbosity
            => LoggerVerbosity.Detailed;

        public override void Shutdown()
        {

        }

        void Handle(object sender, TaskStartedEventArgs e)
        {

        }

        void Handle(object sender, TaskFinishedEventArgs e)
        {

        }

        void Handle(object sender, BuildStatusEventArgs e)
        {

        }


        void Handle(object sender, TargetStartedEventArgs e)
        {

        }

        void Handle(object sender, TargetFinishedEventArgs e)
        {

        }

        void Handle(object sender, CustomBuildEventArgs e)
        {

        }

        void Handle(object sender, BuildErrorEventArgs e)
        {

        }

        void Handle(object sender, BuildWarningEventArgs e)
        {

        }

        void Handle(object sender, BuildMessageEventArgs e)
        {

        }

        void Handle(object sender, ProjectStartedEventArgs e)
        {

        }

        void Handle(object sender, ProjectFinishedEventArgs e)
        {

        }

        void Handle(object sender, BuildStartedEventArgs e)
        {

        }

        void Handle(object sender, BuildFinishedEventArgs e)
        {

        }
    }
}