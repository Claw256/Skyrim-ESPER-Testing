using TestingESPER.esper.elements;
using TestingESPER.esper.helpers;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;
using System;

namespace TestingESPER.esper.defs.TES5 {
    public class CTDAFunctionFormat : FormatDef {
        public static readonly string defId = "CTDAFunctionFormat";

        public CTDAFunctionFormat(DefinitionManager manager, JObject src)
            : base(manager, src) {}

        public override string DataToValue(ValueElement element, dynamic data) {
            UInt16 index = data;
            var ctdaFunction = manager.ctdaFunctions.FunctionByIndex(index);
            if (ctdaFunction != null) return ctdaFunction.name;
            return $"<Unknown: {data.ToString()}>";
        }

        public override dynamic ValueToData(ValueElement element, string value) {
            var ctdaFunction = manager.ctdaFunctions.FunctionByName(value);
            if (ctdaFunction != null) return ctdaFunction.index;
            return DataHelpers.ParseInt64(value);
        }
    }
}
