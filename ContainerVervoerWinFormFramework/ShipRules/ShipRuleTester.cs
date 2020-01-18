using System;
using System.Collections.Generic;
using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;

namespace ContainerVervoerWinFormFramework.ShipRules
{
    public class ShipRuleTester
    {
        //private bool IsOdd { get { return Ship.Width % 2 == 1; } }

        private IShip Ship { get; set; }
        private IList<IContainer> Containers { get; }
        private IContainerDistributor Distributor { get; set; }

        public ShipRuleTester(IShip ship, IContainerDistributor distributor)
        {
            Ship = ship;
            Distributor = distributor;
            Containers = distributor.Containers;
        }

        public bool TestMinimumWeight()
        {
            bool error = GetGridWeight() < (Ship.MaxCapacity / 2);
            
            return error;
        }


        public bool TestMaximumWeight()
        {
            bool error = GetGridWeight() > (Ship.MaxCapacity / 2);

            return error;
        }


        public bool TestBalance()
        {
            bool error = false;
            float balance = (float)Distributor.LeftSideWeight / ((float)Distributor.LeftSideWeight + (float)Distributor.RightSideWeight);
            if (balance < 0.4f || balance > 0.6f)
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
            int gridWeight = Distributor.LeftSideWeight + Distributor.RightSideWeight;
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
