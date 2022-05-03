using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;
using TestingESPER.esper.setup;
using Newtonsoft.Json.Linq;
using System;

namespace TestingESPER.esper.defs.TES5 {
    public class ScriptFragmentsPackCounter : CounterDef {
        public static readonly string defId = "ScriptFragmentsPackCounter";

        public ScriptFragmentsPackCounter(
            DefinitionManager manager, JObject src
        ) : base(manager, src) { }

        // TODO: SetCount?

        public override UInt32 GetCount(Container container) {
            UInt32 count = 0;
            int flags = container.GetData("Flags");
            for (int i = 0; i < 8; i++) {
                int flagOrd = 1 << i;
                if ((flags & flagOrd) == 0) continue;
                count++;
            }
            return count;
        }
    }
}
