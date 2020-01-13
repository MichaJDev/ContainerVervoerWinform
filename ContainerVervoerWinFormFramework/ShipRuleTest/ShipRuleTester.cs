using ContainerVervoerWinFormFramework.ContainerDistributors;
using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;

namespace ContainerVervoerWinFormFramework.ShipRuleTest
{
    public class ShipRuleTester
    {
        private IShip Ship { get; set; }
        private bool IsOdd { get { return Ship.Width % 2 == 1; } }
        private IContainerDistributor Distributor { get; set; }
        public ShipRuleTester(IShip ship, IContainerDistributor distributor)
        {
            Ship = ship;
            Distributor = distributor;
        }

        public bool TestMinimumWeight()
        {
            bool error = false;

            if (GetGridWeight() < (Ship.MaxCapacity / 2))
            {
                error = true;
            }

            return error;
        }
        public bool TestMaximumWeight()
        {
            bool error = false;

            if (GetGridWeight() > (Ship.MaxCapacity / 2))
            {
                error = true;
            }

            return error;
        }
        public bool TestBalance()
        {
            bool error = false;
            int balance = Distributor.LeftSideWeight / (Distributor.LeftSideWeight + Distributor.RightSideWeight);
            if (balance < 40 || balance > 60)
            {
                error = true;
            }
            return error;
        }

        private int GetGridWeight()
        {
            int gridWeight = 0;
            for (int x = 0; x < Ship.Width; x++)
            {
                for (int y = 0; y < Ship.Length; y++)
                {
                    gridWeight += Ship.Grid[x, y].StackWeight;
                }
            }
            return gridWeight;
        }
    }
}
