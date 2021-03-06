using TestingESPER.esper.elements;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;
using System;

namespace TestingESPER.esper.defs.TES5 {
    public class AtxtPositionFormat : FormatDef {
        public static readonly string defId = "AtxtPositionFormat";
        public override bool customSortKey => true;

        public AtxtPositionFormat(DefinitionManager manager, JObject src)
            : base(manager, src) {}

        public override string DataToValue(ValueElement element, dynamic data) {
            UInt16 v = data;
            return $"{v} -> {v / 17}:{v % 17}";
        }

        public override dynamic ValueToData(ValueElement element, string value) {
            return Int64.Parse(value);
        }

        public override string GetSortKey(ValueElement element, dynamic data) {
            UInt16 v = data;
            return $"{v / 17:X2}{v % 17:X2}";
        }
    }
}
