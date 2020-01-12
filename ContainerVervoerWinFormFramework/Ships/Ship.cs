using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;


namespace ContainerVervoerWinFormFramework.Ships
{
    public class Ship : IShip
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MaxCapacity { get; private set; }
        public IList<IContainer> Containers { get; private set; }
        
        public Ship(int width, int height, int maxCapcity , IList<IContainer> containers)
        {
            Width = width;
            Height = height;
            MaxCapacity = maxCapcity;
            Containers = containers;
        }
    }
}
