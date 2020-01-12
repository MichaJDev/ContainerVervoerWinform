using ContainerVervoerWinFormFramework.Ships.Containers.Enums;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;

namespace ContainerVervoerWinFormFramework.Ships.Containers
{
    public class Container : IContainer
    {
        const int _containerWeight = 4000;
        const int _maxCapacity = 26000;
        public int ContentWeight { get; private set; }
        public int Weight { get { return ContentWeight + _containerWeight; } }
        public bool MaxWeight { get { return Weight <= (_maxCapacity + _containerWeight); } }
        public ContainerType Type { get; private set; }

        public Container(int contentWeight, ContainerType type)
        {
            ContentWeight = contentWeight;
            Type = type;
        }
    }
}
