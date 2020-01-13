using ContainerVervoerWinFormFramework.Ships.Containers.Enums;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;

namespace ContainerVervoerWinFormFramework.Ships.Containers
{
    public class Container : IContainer
    {
        private int _containerWeight = 4000;
        private int _maxCapacity = 26000;
        public int ContentWeight { get; private set; }
        public int Weight => ContentWeight + _containerWeight;
        public int  MaxCapacity => _maxCapacity;
        public bool MaxWeight => Weight <= (_maxCapacity + _containerWeight);
        public ContainerType Type { get; private set; }

        //Purely to be able to instantiate and fetch MaxContainerCapacity;
        public Container()
        {

        }
        public Container(int contentWeight, ContainerType type)
        {
            ContentWeight = contentWeight;
            Type = type;
        }
        public override string ToString()
        {
            return $"Type: {Type} | Weight: {Weight} | ";
        }
    }
}
