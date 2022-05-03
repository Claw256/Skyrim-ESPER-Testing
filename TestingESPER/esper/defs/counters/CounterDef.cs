using TestingESPER.esper.elements;
using TestingESPER.esper.setup;
using System.Text.Json;
using System;

namespace TestingESPER.esper.defs {
    public class CounterDef : Def {
        public virtual bool canSetCount => false;

        public CounterDef(DefinitionManager manager, JsonElement src)
            : base(manager, src) { }

        public virtual void SetCount(Container container, UInt32 count) {
            throw new NotImplementedException();
        }

        public virtual UInt32 GetCount(Container container) {
            throw new NotImplementedException();
        }
    }
}
