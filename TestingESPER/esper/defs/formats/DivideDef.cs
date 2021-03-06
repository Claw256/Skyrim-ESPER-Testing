using TestingESPER.esper.elements;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;

namespace TestingESPER.esper.defs {
    public class DivideDef : FormatDef {
        public static readonly string defId = "divide";
        public int divisionValue;

        public DivideDef(DefinitionManager manager, JObject src)
            : base(manager, src) {
            divisionValue = src.Value<int>("value");
        }

        public override string DataToValue(ValueElement element, dynamic data) {
            float f = data / (float) divisionValue;
            return f.ToString(sessionOptions.floatFormat);
        }

        public override dynamic ValueToData(ValueElement element, string value) {
            return float.Parse(value) * divisionValue;
        }
    }
}
