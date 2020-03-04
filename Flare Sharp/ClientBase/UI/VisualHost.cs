using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flare_Sharp.ClientBase.UI
{
    public class VisualHost : FrameworkElement
    {
        // Create a collection of child visual objects.
        public VisualCollection children;
        public VisualHost()
        {
            children = new VisualCollection(this);
        }

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return children.Count; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return children[index];
        }
    }
}
