using TestingESPER.esper.elements;
using System.Collections.Generic;

namespace TestingESPER.esper.warnings {
    public class ElementWarnings : List<ElementWarning> {
        public bool Add(Element element, string warning) {
            Add(new ElementWarning(element) {
                warning = warning
            });
            return true;
        }
    }
}
