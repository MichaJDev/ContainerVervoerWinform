using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
using ContainerVervoerWinFormFramework.ContainerDistributors;
using ContainerVervoerWinFormFramework.ShipRuleTest;

namespace ContainerVervoerWinFormFramework.IOManagers
{
    class InputManager
    {
        public static bool ParseToDistributor(IShip ship, IList<IContainer> containers)
        {
            IContainerDistributor distributor = new ContainerDistributor(ship, containers);
            bool error = distributor.Distribute();
            if (!error)
            {
                ShipRuleTester test = new ShipRuleTester(ship,distributor);
                error = test.TestMaximumWeight();
                if (!error)
                {
                    error = test.TestMinimumWeight();
                }
            }
            return error;
        }

    }
}
