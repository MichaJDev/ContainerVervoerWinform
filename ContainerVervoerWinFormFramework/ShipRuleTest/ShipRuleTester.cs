using ContainerVervoerWinFormFramework.ContainerDistributors;
using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;
using System.Collections.Generic;

namespace ContainerVervoerWinFormFramework.ShipRuleTest
{
    public class ShipRuleTester
    {
        //private bool IsOdd { get { return Ship.Width % 2 == 1; } }

        private IShip Ship { get; set; }
        private IList<IContainer> Containers { get; }
        private IContainerDistributor Distributor { get; set; }

        public ShipRuleTester(IShip ship, IContainerDistributor distributor, IList<IContainer> containers)
        {
            Ship = ship;
            Distributor = distributor;
            Containers = containers;
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

        private int GetStackWeight(ISlot containerSlot)
        {
            //Calculate stack weight on top of lowest positioned container of this slot
            return containerSlot.StackWeight - containerSlot.Stack[0].Weight;
        }
        public bool TestSlotWeightMaxCapacity()
        {
            bool error = false;
            for (int x = 0; x < Ship.Width && !error; x++)
            {
                for (int y = 0; y < Ship.Length && !error; y++)
                {
                    if (!Ship.Grid[x, y].IsEmpty)
                    {
                        if ((GetStackWeight(Ship.Grid[x, y]) > 120000))
                        {
                            error = true;
                        }
                    }
                }
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

        public bool TestContainersLeftOver()
        {
            bool leftOver = false;
            if (Containers.Count > 0)
            {
                leftOver = true;
            }
            return leftOver;

        }
    }
}
