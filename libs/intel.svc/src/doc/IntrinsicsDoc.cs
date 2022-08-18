//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;

    using static core;
    using static XedModels;

    public partial class IntrinsicsDoc
    {
        const int MaxDefCount = Pow2.T13;

        public static Index<IntrinsicDef> read(XmlDoc src)
        {
            var entries = new IntrinsicDef[MaxDefCount];
            var i = -1;
            using var reader = XmlReader.Create(new StringReader(src.Content));
            while (reader.Read() && i<MaxDefCount - 1)
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    switch(reader.Name)
                    {
                        case IntrinsicDef.ElementName:
                            i++;
                            entries[i] = IntrinsicDef.Empty;
                            entries[i].content = reader.Value;
                            entries[i].tech = reader[nameof(IntrinsicDef.tech)];
                            entries[i].name = reader[nameof(IntrinsicDef.name)];
                        break;

                        case Operation.ElementName:
                            read(reader, ref entries[i].operation);
                        break;

                        case Description.ElementName:
                            read(reader, ref entries[i].description);
                        break;

                        case Return.ElementName:
                            read(reader, ref entries[i].@return);
                        break;

                        case CpuId.ElementName:
                            read(reader, entries[i].CPUID);
                        break;

                        case Category.ElementName:
                            read(reader, ref entries[i].category);
                        break;

                        case Instruction.ElementName:
                            read(reader, entries[i].instructions);
                        break;

                        case InstructionType.ElementType:
                            read(reader, entries[i].types);
                        break;

                        case IntrinsicsDoc.Parameter.ElementName:
                            read(reader, entries[i].parameters);
                        break;
                        case Header.ElementName:
                            read(reader, ref entries[i].header);
                        break;
                    }
                }
            }

            return slice(span(entries),0,i).ToArray().Sort();
        }

        static void read(XmlReader reader, ref Operation dst)
        {
            const string amp = "&amp;";
            var content = reader.ReadInnerXml().Replace(XmlEntities.gt, ">").Replace(XmlEntities.lt, "<").Replace(amp, "&");
            foreach(var line in Lines.read(content,trim:false))
                dst.Content.Add(line);
        }

        static void read(XmlReader reader, CpuIdMembership dst)
            => dst.Add(reader.ReadInnerXml());

        static void read(XmlReader reader, ref Category dst)
            => dst = reader.ReadInnerXml();

        static void read(XmlReader reader, ref Header dst)
            => dst = reader.ReadInnerXml();

        static void read(XmlReader reader, ref Description dst)
            => dst =  reader.ReadInnerXml().Replace("\n", " ");

        static void read(XmlReader reader, ref Return dst)
        {
            dst.varname = reader[nameof(Return.varname)];
            dst.etype = reader[nameof(Return.etype)];
            dst.type = reader[nameof(Return.type)];
            dst.memwidth =  reader[nameof(Return.memwidth)];
        }

        static void read(XmlReader reader, Parameters dst)
        {
            var target = new IntrinsicsDoc.Parameter();
            target.varname = reader[nameof(target.varname)] ?? EmptyString;
            target.etype = reader[nameof(target.etype)] ?? EmptyString;
            target.type = reader[nameof(target.type)] ?? EmptyString;
            target.memwidth = reader[nameof(target.memwidth)] ?? EmptyString;
            target.immwidth = reader[nameof(target.immwidth)] ?? EmptyString;
            dst.Add(target);
        }

        static void read(XmlReader reader, InstructionTypes dst)
            => dst.Add(reader.ReadInnerXml());

        static void read(XmlReader reader, Instructions dst)
            => dst.Add(new (
                name: reader[nameof(Instruction.name)],
                form: reader[nameof(Instruction.form)],
                xed: Enums.parse(reader[nameof(Instruction.xed)], default(InstFormType)))
                );

    }
}