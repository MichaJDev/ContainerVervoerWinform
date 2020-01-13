using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;

namespace ContainerVervoerWinFormFramework.Ships.Interface
{
    public interface IShip
    {
        ISlot[,] Grid { get; }
        int Width { get; }
        int Length { get; }
        int MaxCapacity { get; }
        IList<IContainer> Containers { get; }

    }
}
