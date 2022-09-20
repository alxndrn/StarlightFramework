using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Web
{
    public interface IInteractionsService
    {
        IInteractionsService Release();
        IInteractionsService MoveToElement(Element element);
        IInteractionsService DragAndDrop(Element sourceElement, Element destinationElement);
        IInteractionsService DoubleClick(Element element);
        IInteractionsService ClickAndHold(Element element);
        void Perform();
    }
}
