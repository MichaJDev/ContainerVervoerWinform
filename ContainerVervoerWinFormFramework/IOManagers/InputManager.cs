using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
using ContainerVervoerWinFormFramework.ContainerDistributors;
using ContainerVervoerWinFormFramework.ShipRules;

namespace ContainerVervoerWinFormFramework.IOManagers
{
    class InputManager
    {
        public bool Error { get; private set; }
        public string Reason { get; private set; }
        public IShip ParseToDistributor(IShip ship, IList<IContainer> containers)
        {
            IContainerDistributor distributor = new ContainerDistributor(ship, containers);
            IShip iShip = distributor.Distribute();
            ShipRuleTester test = new ShipRuleTester(iShip, distributor);
            Error = (test.TestMaximumWeight() || test.TestMinimumWeight() || test.TestBalance() || test.TestSlotWeightMaxCapacity() || test.TestContainersLeftOver());
            Reason = test.Reason;
            return iShip;
        }

    }

}
