using TestingESPER.esper.elements;

namespace TestingESPER.esper.warnings {
    public class ElementWarning {
        public Element element;
        public string warning = "";

        public ElementWarning(Element element) {
            this.element = element;
        }
    }
}
