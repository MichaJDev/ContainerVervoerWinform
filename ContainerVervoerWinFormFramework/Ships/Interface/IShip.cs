using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;

namespace ContainerVervoerWinFormFramework.Ships.Interface
{
    public interface IShip
    {
        IEnumerable<IEnumerable<ISlot>> Grid { get; set; }
        int Width { get;}
        int Height { get; }
        int MaxCapacity { get; }
        IList<IContainer> Containers { get;  }

    }
}
