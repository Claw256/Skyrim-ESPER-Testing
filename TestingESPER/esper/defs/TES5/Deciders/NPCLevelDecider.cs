using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;

namespace TestingESPER.esper.defs.TES5 {
    public class NPCLevelDecider : Decider {
        public override int Decide(Container container) {
            var e = container.GetElement("Flags");
            if (e == null) return 0;
            long data = e.GetData();
            return (data & 0x80) != 0 ? 1 : 0;
        }
    }
}
