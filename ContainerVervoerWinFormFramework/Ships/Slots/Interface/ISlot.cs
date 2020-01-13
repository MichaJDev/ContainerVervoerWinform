using ContainerVervoerWinFormFramework.Ships.Containers;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using System.Collections.Generic;

namespace ContainerVervoerWinFormFramework.Ships.Slots.Interface
{
    public interface ISlot
    {
        IList<IContainer> Stack { get; }
        IContainer ValuableContainer { get; }
        bool IsEmpty { get; }
        int StackWeight { get; }
    }
}
