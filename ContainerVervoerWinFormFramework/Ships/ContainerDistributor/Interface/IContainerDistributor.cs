﻿using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System.Collections.Generic;

namespace ContainerVervoerWinFormFramework.Ships.ContainerDistributor.Interface
{
    public interface IContainerDistributor
    {
        void Distrobute(IShip ship, IList<IContainer> containers);
    }
}