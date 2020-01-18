using ContainerVervoerWinFormFramework.Ships.Containers;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;
using System.Collections.Generic;

namespace ContainerVervoerWinForm.Ships.Slots
{
    public class Slot : ISlot
    {

        public IList<IContainer> Stack { get; set; }

        public IContainer ValuableContainer { get; private set; }

        public bool IsEmpty { get { return Stack.Count == 0; } }
        public int StackWeight => CalculateStackWeight();
        public Slot(IList<IContainer> containers)
        {
            Stack = containers;
        }
        private int CalculateStackWeight()
        {
            int weight = 0;
            foreach (IContainer container in Stack)
            {
                weight += container.Weight;
            }
            return weight;
        }

    }
}
