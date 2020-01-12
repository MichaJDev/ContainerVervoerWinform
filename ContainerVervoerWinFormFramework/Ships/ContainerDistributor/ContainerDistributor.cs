using ContainerVervoerWinFormFramework.Ships.ContainerDistributor.Interface;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoerWinFormFramework.Ships.ContainerDistributor
{
    public class ContainerDistributor : IContainerDistributor
    {
        public void Distrobute(IShip ship, IList<IContainer> containers)
        {
            throw new NotImplementedException();
        }
    }
}
