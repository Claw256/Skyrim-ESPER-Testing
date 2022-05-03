using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;

namespace TestingESPER.esper.defs.TES5 {
    public class PerkDATADecider : Decider {
        public override int Decide(Container container) {
            var type = container.GetData(@"PRKE\Type");
            return type ?? 0;
        }
    }
}
