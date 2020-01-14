using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;

namespace ContainerVervoerWinFormFramework.ContainerDistributors.Interface
{
    public interface IContainerDistributor
    {
        IShip Distribute();
        int LeftSideWeight { get; }
        int RightSideWeight { get; }
    }
}
