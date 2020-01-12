using ContainerVervoerWinFormFramework.Ships.Containers;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;
using System.Collections.Generic;

namespace ContainerVervoerWinForm.Ships.Slots
{
    public class Slot : ISlot
    {
        private const int _slotWeight = 15000;
        public IList<IContainer> Containers { get; private set; }

        public IContainer ValuableContainer { get; private set; }

        public bool IsEmpty { get { return Containers.Count == 0; } }

        public int TotalWeight { get { return _slotWeight; } }

        public Slot(List<IContainer> containers)
        {
            Containers = containers;
        }

    }
}
