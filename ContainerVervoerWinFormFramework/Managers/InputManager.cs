using ContainerVervoerWinFormFramework.Managers.Interface;
using ContainerVervoerWinFormFramework.Ships.ContainerDistributor.Interface;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoerWinFormFramework.Managers
{
    class InputManager : IInputManager
    {
        private IShip _ship;
        public IList<IContainer> _containers;
        private IContainerDistributor distributor;
        public InputManager(IList<IContainer> containers, IShip ship)
        {
            distributor.Distrobute(ship, _containers);
        }

    }
}
