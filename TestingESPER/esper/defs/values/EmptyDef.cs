using TestingESPER.esper.elements;
using TestingESPER.esper.io;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;
using System;

namespace TestingESPER.esper.defs {
    public class EmptyDef : ValueDef {
        public static readonly string defId = "empty";
        public override XEDefType valueDefType => XEDefType.dtEmpty;

        public override int? size => 0;

        public EmptyDef(DefinitionManager manager, JObject src)
            : base(manager, src) { }

        public override string GetValue(ValueElement element) {
            return "";
        }

        public override void SetValue(ValueElement element, string value) {}

        public override dynamic DefaultData() {
            return null;
        }

        public override dynamic ReadData(DataSource source, UInt32? dataSize) {
            return null;
        }

        public override string GetSortKey(Element element) {
            return "";
        }

        internal override void WriteData(
            ValueElement element, PluginFileOutput output
        ) { }
    }
}
