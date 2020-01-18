using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;
using ContainerVervoerWinForm.Ships.Slots;

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
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    IList<IContainer> emptyStackList = new List<IContainer>();
                    containerSlotGrid[x, y] = new Slot(emptyStackList);
                    containerSlotGrid[x, y].Stack.Clear();
                }
            }
            return containerSlotGrid;

        }
        public string ShipString()
        {
            return "SHIP";
        }
    }
}
