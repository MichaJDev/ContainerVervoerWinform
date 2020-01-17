using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;


namespace ContainerVervoerWinFormFramework.Ships
{
    public class Ship : IShip
    {
        public ISlot[,] Grid { get; set; }
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
            Grid = CreateContainerGrid(width, height);
        }

        private ISlot[,] CreateContainerGrid(int width, int length)
        {
            ISlot[,] containerSlotGrid = new ISlot[width, length];
            //for (int x = 1; x < width; x++)
            //{
            //    for (int y = 1; y < length; y++)
            //    {
            //        if (containerSlotGrid[x, y].Stack.Count >  0)
            //        {
            //            containerSlotGrid[x, y].Stack.Clear();
            //        }
                    
            //    }
            //}
            return containerSlotGrid;

        }
    }
}
