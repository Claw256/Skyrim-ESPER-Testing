using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;

namespace TestingESPER.esper.defs.TES5 {
    public class NAVIParentDecider : Decider {
        public override int Decide(Container container) {
            var e = container.GetParentElement(e => e.def.IsSubrecord());
            var isIsland = e?.GetElement("Parent Worldspace");
            if (isIsland == null) return 0;
            return isIsland.GetData() == 0 ? 1 : 0;
        }
    }
}
