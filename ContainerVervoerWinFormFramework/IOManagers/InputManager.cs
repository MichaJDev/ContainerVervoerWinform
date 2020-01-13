using ContainerVervoerWinFormFramework.Ships.ContainerDistributor.Interface;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.Ships.ContainerDistributor;

namespace ContainerVervoerWinFormFramework.IOManagers
{
    class InputManager
    {
        public static void ParseToDistributor(IShip ship, IList<IContainer> containers)
        {
            IContainerDistributor distributor = new ContainerDistributor(ship, containers);
            distributor.Distribute();
        }

    }
}
