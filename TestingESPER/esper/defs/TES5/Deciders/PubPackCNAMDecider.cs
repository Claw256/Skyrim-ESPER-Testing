using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;

namespace TestingESPER.esper.defs.TES5 {
    public class PubPackCNAMDecider : Decider {
        public override int Decide(Container container) {
            string anam = container?.GetData("ANAM");
            return anam switch {
                "Bool" => 1,
                "Int" => 2,
                "Float" => 3, "ObjectList" => 3,
                _ => 0
            };
        }
    }
}
