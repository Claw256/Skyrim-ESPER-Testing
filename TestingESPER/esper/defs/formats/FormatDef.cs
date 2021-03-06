using TestingESPER.esper.elements;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;
using System;

namespace TestingESPER.esper.defs {
    public class FormatDef : Def {
        public virtual bool customSortKey => false;
        public override XEDefType defType => XEDefType.dtIntegerFormater;

        public FormatDef(DefinitionManager manager, JObject src)
            : base(manager, src) {}

        public virtual string DataToValue(ValueElement element, dynamic data) {
            throw new NotImplementedException();
        }

        public virtual dynamic ValueToData(ValueElement element, string value) {
            throw new NotImplementedException();
        }

        public virtual string GetSortKey(ValueElement element, dynamic data) {
            return DataToValue(element, data);
        }
    }
}
