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
        public static IShip ParseToDistributor(IShip ship, IList<IContainer> containers)
        {
            IContainerDistributor distributor = new ContainerDistributor(ship, containers);
            IShip iShip =  distributor.Distribute();

            ShipRuleTester test = new ShipRuleTester(ship, distributor, containers);
            bool error = test.TestMaximumWeight() || test.TestMinimumWeight() || test.TestBalance() || test.TestSlotWeightMaxCapacity() || test.TestContainersLeftOver();
            if (error)
            {
                return null;
            }
            return iShip;
        }

    }

}
