using ContainerVervoerWinFormFramework.Ships.ContainerDistributor.Interface;
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

namespace ContainerVervoerWinFormFramework.Ships.ContainerDistributor
{
    public class ContainerDistributor : IContainerDistributor
    {
        private IList<IContainer> Containers { get; set; }

        private IEnumerable<IContainer> SortedContainers
        {
            get { return SortContainers(Containers); }
            set { value = SortedContainers; }
        }

        private IShip Ship { get; set; }

        public ContainerDistributor(IShip ship, IList<IContainer> containers)
        {
            Containers = containers;
            Ship = ship;
        }
        public bool Distribute()
        {
            foreach (IContainer container in SortedContainers)
            {
                return PlaceExceptValuables(container);
            }
            return false;
        }
        private bool RemoveStoredContainer(IContainer container)
        {
            List<IContainer> newContainerList = SortedContainers.ToList();
            newContainerList.Remove(container);
            SortedContainers = newContainerList;
            return (!SortedContainers.Contains(container));
        }
        private IList<IContainer> SortContainers(IList<IContainer> containers)
        {
            return containers.OrderBy(x => x.Type).ToList();
        }
        private bool PlaceExceptValuables(IContainer container)
        {
            switch (container.Type)
            {
                case ContainerType.Normal:
                    return PlaceNormal(container);
                    break;
                case ContainerType.Cooled:
                    return PlaceCooled(container);
                    break;
                case ContainerType.Valuable:
                    return PlaceValuable(container);
                    break;
                default:
                    return false;
                    break;
            }
        }

        private bool PlaceValuable(IContainer container)
        {
            if (IsPlacable(container))
                throw new NotImplementedException();
            throw new NotImplementedException();
        }

        private bool PlaceCooled(IContainer container)
        {
            if (IsPlacable(container))
                throw new NotImplementedException();
            throw new NotImplementedException();
        }

        private bool PlaceNormal(IContainer container)
        {
            if (IsPlacable(container))
                throw new NotImplementedException();
            throw new NotImplementedException();
        }
        private bool IsPlacable(IContainer container)
        {
            return IsBalanced(container) && HasCapacity(container);
        }
        private bool HasCapacity(IContainer container)
        {
            throw new NotImplementedException();
        }

        private bool IsBalanced(IContainer container)
        {
            throw new NotImplementedException();
        }

        private IList<IList<ISlot>> ConvertGridToList(IEnumerable<IEnumerable<ISlot>> grid)
        {
            return (IList<IList<ISlot>>)grid;
        }

    }
}
