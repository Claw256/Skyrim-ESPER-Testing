using TestingESPER.esper.elements;
using System.Collections.Generic;

namespace TestingESPER.esper.conflicts {
    public class ConflictView {
        public ConflictRow row;

        public ConflictView(MainRecord rec) {
            var master = rec.master;
            var records = new List<Element>() { master };
            records.AddRange(master.overrides);
            row = new ConflictRow(records);
        }
    }
}
