using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoerWinFormFramework.Ships.Interface
{
    public interface IShip
    {
        int Width { get;}
        int Height { get; }
        int MaxCapacity { get; }
        IList<IContainer> Containers { get;  }

    }
}
