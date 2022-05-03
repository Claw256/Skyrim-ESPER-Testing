using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;

namespace TestingESPER.esper.defs.TES5 {
    public class COEDOwnerDecider : Decider {
        public override int Decide(Container container) {
            MainRecord owner = (MainRecord) container?.GetElement("@Owner");
            return owner?.signature.ToString() switch {
                "NPC_" => 1,
                "FACT" => 2,
                _ => 0
            };
        }
    }
}
