using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;

namespace TestingESPER.esper.defs.TES5 {
    public class TypeDecider : Decider {
        public override int Decide(Container container) {
            int? type = (int?) container?.GetData("Type");
            return type ?? 0;
        }
    }
}
