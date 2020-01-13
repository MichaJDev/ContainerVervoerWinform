using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;


namespace ContainerVervoerWinFormFramework.Ships
{
    public class Ship : IShip
    {
        public ISlot[,] Grid { get { return CreateContainerGrid(Width, Length); } }
        public int Width { get; private set; }
        public int Length { get; private set; }
        public int MaxCapacity { get; private set; }
        public IList<IContainer> Containers { get; private set; }

        public Ship(int width, int height, int maxCapacity, IList<IContainer> containers)
        {
            Width = width;
            Length = height;
            MaxCapacity = maxCapacity;
            Containers = containers;
            CreateContainerGrid(Width, Length);
        }
        private ISlot[,] CreateContainerGrid(int width, int length)
        {
            ISlot[,] containerSlotGrid = new ISlot[width, length];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    containerSlotGrid[x, y].Stack.Clear();
                }
            }
            return containerSlotGrid;

        }
    }
}
