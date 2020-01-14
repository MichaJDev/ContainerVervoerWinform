using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ContainerVervoerWinFormFramework.Ships.Containers.Enums;
using ContainerVervoerWinFormFramework.Ships.Slots.Interface;

namespace ContainerVervoerWinFormFramework.ContainerDistributors
{
    public class ContainerDistributor : IContainerDistributor
    {
        private IList<IContainer> Containers { get; set; }
        private IShip Ship { get; set; }
        private bool IsOdd { get { return Ship.Width % 2 == 1; } }
        public int LeftSideWeight { get; private set; }
        public int RightSideWeight { get; private set; }
        private int[] WidthPlacementOrder { get; set; }

        private int nextXPosition, nextYPosition, nextZPosition;
        public ContainerDistributor(IShip ship, IList<IContainer> containers)
        {
            Containers = containers;
            Ship = ship;
            WidthPlacementOrder = InitWidthPlaceOrder();
            nextXPosition = WidthPlacementOrder[0];
            nextYPosition = 0;
            nextZPosition = 0;
            LeftSideWeight = 0;
            RightSideWeight = 0;
        }
        public IShip Distribute()
        {
            IList<IContainer> sortedContainers = SortContainers(Containers);
            bool error = false; while (!error && (HasCoolableContainers(Containers) || HasNormalContainers(Containers)))
            {
                int curZPos = nextZPosition;
                foreach (IContainer container in sortedContainers)
                {
                    if ((IsCoolable(container) && nextYPosition == 0) || (!IsCoolable(container) && !IsValuable(container)))
                    {

                        Ship.Grid[nextXPosition, nextYPosition].Stack.Add(container);
                        AddWeightToShipSide(container.Weight, nextXPosition);
                        Containers.Remove(container);
                        CalculateNextPosition();
                    }
                }
            }

            nextXPosition = 0;
            nextYPosition = 0;
            foreach (IContainer container in Containers)
            {

                nextXPosition = WidthPlacementOrder[0];
                nextYPosition = Ship.Length - 1;

                Ship.Grid[nextXPosition, nextYPosition].Stack.Add(container);
                AddWeightToShipSide(container.Weight, nextXPosition);
                Containers.Remove(container);

                int nextIndex = -1;
                for (int i = 0; i < Ship.Width && nextIndex < 0; i++)
                {
                    if (WidthPlacementOrder[i] == nextXPosition)
                    {
                        nextIndex = i + 1;
                    }
                }

                if (nextIndex < 0 || nextIndex >= Ship.Length)
                {
                    nextYPosition -= 2;
                    nextXPosition = WidthPlacementOrder[0];
                    if (nextYPosition < 0)
                    {
                        break;
                    }
                }
                else
                {
                    nextXPosition = WidthPlacementOrder[nextIndex];
                }
            }
            return Ship;
        }

        private int[] InitWidthPlaceOrder()
        {
            int xLeft = 0;
            int xRight = Ship.Width - 1;
            int[] widthPlacementOrder = new int[Ship.Width];
            for (int i = 0; i < Ship.Width; i++)
            {
                int moduleIndex = i % 4;
                if (moduleIndex == 0 || moduleIndex == 3)
                {
                    widthPlacementOrder[i] = xLeft;
                    xLeft++;
                }
                else
                {
                    widthPlacementOrder[i] = xRight;
                    xRight--;
                }
            }
            return widthPlacementOrder;
        }
        private bool HasCoolableContainers(IList<IContainer> containers)
        {
            int coolableContainers = 0;
            foreach (IContainer container in Containers)
            {
                if (container.Type == ContainerType.Cooled)
                {
                    coolableContainers++;
                }
            }
            return coolableContainers > 0;
        }
        private bool HasNormalContainers(IList<IContainer> containers)
        {
            int normalContainers = 0;
            foreach (IContainer container in Containers)
            {
                if (container.Type == ContainerType.Normal)
                {
                    normalContainers++;
                }
            }
            return normalContainers > 0;
        }
        private bool IsCoolable(IContainer container)
        {
            return container.Type == ContainerType.Cooled;
        }
        private void CalculateNextPosition()
        {
            int nextIndex = -1;
            for (int i = 0; i < Ship.Width && nextIndex < 0; i++)
            {
                if (WidthPlacementOrder[i] == nextXPosition)
                {
                    nextIndex = i + 1;
                }
            }
            if (nextIndex >= 0 && nextIndex < Ship.Width)
            {
                nextXPosition = WidthPlacementOrder[nextXPosition + 1];
            }
            else
            {
                nextXPosition = WidthPlacementOrder[0];
                nextYPosition += 1;
                if (nextYPosition >= Ship.Length)
                {
                    nextYPosition = 0;
                    nextZPosition += 1;
                }
            }
        }
        private int GetStackWeight(ISlot containerSlot)
        {
            //Calculate stack weight on top of lowest positioned container of this slot
            return containerSlot.StackWeight - containerSlot.Stack[0].Weight;
        }
        private IList<IContainer> SortContainers(IList<IContainer> containers)
        {
            return containers.OrderBy(c => c.Type).ThenByDescending(c => c.Weight).ToList();
        }
        private bool IsValuable(IContainer container)
        {
            return container.Type == ContainerType.Valuable;
        }
        private bool IsWeightAllowed(IContainer container, int x, int y)
        {
            bool allowed = true;
            if (Ship.Grid[x, y].IsEmpty)
            {
                if ((GetStackWeight(Ship.Grid[x, y]) + container.Weight) > 120000)
                {
                    allowed = false;
                }
            }
            return allowed;
        }

        private void AddWeightToShipSide(int containerWeight, int xPos)
        {
            int middle = -1;
            int leftMax = 0;
            int rightMin = 0;
            if (IsOdd)
            {
                middle = (Ship.Width - 1) / 2;
                leftMax = middle - 1;
                rightMin = middle + 1;
            }
            else
            {
                middle = -1;
                leftMax = Ship.Width / 2;
                rightMin = leftMax + 1;
            }
            if (xPos == middle)
            {
                LeftSideWeight += containerWeight / 2;
                RightSideWeight += containerWeight / 2;
            }
            else if (xPos <= leftMax)
            {
                LeftSideWeight += containerWeight;
            }
            else
            {
                RightSideWeight += containerWeight;
            }
        }
        /*
         *  Ship Balancing Mechanism 
         */
    }

}
