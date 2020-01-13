using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;


namespace ContainerVervoerWinFormFramework.Ships
{
    public class Ship : IShip
    {
        public IEnumerable<IEnumerable<ISlot>> Grid { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MaxCapacity { get; private set; }
        public IList<IContainer> Containers { get; private set; }
        
        public Ship(int width, int height, int maxCapacity , IList<IContainer> containers)
        {
            Width = width;
            Height = height;
            MaxCapacity = maxCapacity;
            Containers = containers;
        }
    }
}
