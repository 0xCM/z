// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using Z0;
    public class ReadableILStringVisitor : ILInstructionVisitor
    {
        protected readonly IMsilFormatProvider formatProvider;

        protected readonly IILStringCollector collector;

        public ReadableILStringVisitor(IILStringCollector collector)
            : this(collector, DefaultMsilFormatProvider.Instance)
        {
        }

        public ReadableILStringVisitor(IILStringCollector collector, IMsilFormatProvider formatProvider)
        {
            this.formatProvider = formatProvider;
            this.collector = collector;
        }

        public override void VisitInlineBrTargetInstruction(InlineBrTargetInstruction inlineBrTargetInstruction)
        {
            collector.Process(inlineBrTargetInstruction, formatProvider.Label(inlineBrTargetInstruction.TargetOffset));
        }

        public override void VisitInlineFieldInstruction(InlineFieldInstruction inlineFieldInstruction)
        {
            string field;
            try
            {
                field = inlineFieldInstruction.Field.GetILSig();
            }
            catch (Exception ex)
            {
                field = "!" + ex.Message + "!";
            }
            collector.Process(inlineFieldInstruction, field);
        }

        public override void VisitInlineIInstruction(InlineIInstruction inlineIInstruction)
        {
            collector.Process(inlineIInstruction, inlineIInstruction.Value.ToString());
        }

        public override void VisitInlineI8Instruction(InlineI8Instruction inlineI8Instruction)
        {
            collector.Process(inlineI8Instruction, inlineI8Instruction.Value.ToString());
        }

        public override void VisitInlineMethodInstruction(InlineMethodInstruction inlineMethodInstruction)
        {
            string method;
            try
            {
                method = inlineMethodInstruction.Method.GetILSig();
            }
            catch (Exception ex)
            {
                method = "!" + ex.Message + "!";
            }
            collector.Process(inlineMethodInstruction, method);
        }

        public override void VisitInlineNoneInstruction(InlineNoneInstruction inlineNoneInstruction)
        {
            collector.Process(inlineNoneInstruction, string.Empty);
        }

        public override void VisitInlineRInstruction(InlineRInstruction inlineRInstruction)
        {
            collector.Process(inlineRInstruction, inlineRInstruction.Value.ToString());
        }

        public override void VisitInlineSigInstruction(InlineSigInstruction inlineSigInstruction)
        {
            collector.Process(inlineSigInstruction, formatProvider.SigByteArrayToString(inlineSigInstruction.Signature));
        }

        public override void VisitInlineStringInstruction(InlineStringInstruction inlineStringInstruction)
        {
            collector.Process(inlineStringInstruction, formatProvider.EscapedString(inlineStringInstruction.String));
        }

        public override void VisitInlineSwitchInstruction(InlineSwitchInstruction inlineSwitchInstruction)
        {
            collector.Process(inlineSwitchInstruction, formatProvider.MultipleLabels(inlineSwitchInstruction.TargetOffsets));
        }

        public override void VisitInlineTokInstruction(InlineTokInstruction inlineTokInstruction)
        {
            string member;
            try
            {
                string prefix = "";
                string token = "";
                switch (inlineTokInstruction.Member.MemberType)
                {
                    case MemberTypes.Method:
                    case MemberTypes.Constructor:
                        prefix = "method ";
                        token = ((MethodBase)inlineTokInstruction.Member).GetILSig();
                        break;
                    case MemberTypes.Field:
                        prefix = "field ";
                        token = ((FieldInfo)inlineTokInstruction.Member).GetILSig();
                        break;
                    default:
                        token = ((TypeInfo)inlineTokInstruction.Member).GetILSig();
                        break;
                }

                member = prefix + token;
            }
            catch (Exception ex)
            {
                member = "!" + ex.Message + "!";
            }
            collector.Process(inlineTokInstruction, member);
        }

        public override void VisitInlineTypeInstruction(InlineTypeInstruction inlineTypeInstruction)
        {
            string type;
            try
            {
                type = inlineTypeInstruction.Type.GetILSig();
            }
            catch (Exception ex)
            {
                type = "!" + ex.Message + "!";
            }
            collector.Process(inlineTypeInstruction, type);
        }

        public override void VisitInlineVarInstruction(InlineVarInstruction inlineVarInstruction)
            => collector.Process(inlineVarInstruction, formatProvider.Argument(inlineVarInstruction.Ordinal));

        public override void VisitShortInlineBrTargetInstruction(ShortInlineBrTargetInstruction shortInlineBrTargetInstruction)
            => collector.Process(shortInlineBrTargetInstruction, formatProvider.Label(shortInlineBrTargetInstruction.TargetOffset));

        public override void VisitShortInlineIInstruction(ShortInlineIInstruction shortInlineIInstruction)
        {
            collector.Process(shortInlineIInstruction, shortInlineIInstruction.Value.ToString());
        }

        public override void VisitShortInlineRInstruction(ShortInlineRInstruction shortInlineRInstruction)
        {
            collector.Process(shortInlineRInstruction, shortInlineRInstruction.Value.ToString());
        }

        public override void VisitShortInlineVarInstruction(ShortInlineVarInstruction shortInlineVarInstruction)
        {
            collector.Process(shortInlineVarInstruction, formatProvider.Argument(shortInlineVarInstruction.Ordinal));
        }
    }
}