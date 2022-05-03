﻿using TestingESPER.esper.elements;
using TestingESPER.esper.resolution;

namespace TestingESPER.esper.defs.TES5 {
    public class CTDACompValueDecider : Decider {
        public override int Decide(Container container) {
            if (container == null) return 0;
            long type = container.GetData("Type");
            bool isGlobal = (type & 0x4) != 0;
            return isGlobal ? 1 : 0;
        }
    }
}
