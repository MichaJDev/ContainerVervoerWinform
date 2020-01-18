using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ContainerVervoerWinFormFramework.ContainerDistributors;
using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
using ContainerVervoerWinFormFramework.ShipRules;
using ContainerVervoerWinFormFramework.Ships;
using ContainerVervoerWinFormFramework.Ships.Containers;
using ContainerVervoerWinFormFramework.Ships.Containers.Enums;
using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
using ContainerVervoerWinFormFramework.Ships.Interface;
using NUnit.Framework;

namespace ContainerVervoerWinFormFramework.Tests
{
    public class Tests
    {
        static Random rdm = new Random();

        IList<IContainer> containerList = new List<IContainer>
        {

            new Container(25000, ContainerType.Cooled),
            new Container(22000, ContainerType.Cooled),
            new Container(23000, ContainerType.Cooled),
            new Container(24000, ContainerType.Normal),
            new Container(22400, ContainerType.Normal),
            new Container(25000, ContainerType.Normal),
            new Container(22000, ContainerType.Normal),
            new Container(21040, ContainerType.Normal),
            new Container(22020, ContainerType.Normal),
            new Container(22040, ContainerType.Valuable),
            new Container(23040, ContainerType.Valuable),
            new Container(21055, ContainerType.Valuable),
            new Container(15000, ContainerType.Valuable)
        };

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestBalanceSucceed()
        {
            /// <summary> TestRun with original Information</summary>
            /// <remarks> This test should return true</remarks>
            int width = 3;
            int height = 3;
            IShip originalShip = new Ship(width, height, (width * height) * 150000, containerList);
            IContainerDistributor distributor = new ContainerDistributor(originalShip, containerList);
            ShipRuleTester ruleTester = new ShipRuleTester(originalShip, distributor);
            bool OriginalBalanceTest = ruleTester.TestBalance();

            Debug.WriteLine("1231233");
            Assert.IsFalse(OriginalBalanceTest);

        }
        [Test]
        public void TestMaximumWeightSucceed()
        {
            /// <summary> TestRun with original Information</summary>
            /// <remarks> This test should return true</remarks>
            int width = 3;
            int height = 3;
            IShip originalShip = new Ship(width, height, (width * height) * 150000, containerList);
            IContainerDistributor distributor = new ContainerDistributor(originalShip, containerList);
            ShipRuleTester ruleTester = new ShipRuleTester(originalShip, distributor);

            bool OriginalMaxWeightTest = ruleTester.TestMaximumWeight();

            Assert.IsFalse(OriginalMaxWeightTest);
        }

        [Test]
        public void TestMaxStackWeightSucceed()
        {

            int width = 3;
            int height = 3;
            IShip originalShip = new Ship(width, height, (width * height) * 150000, containerList);
            IContainerDistributor distributor = new ContainerDistributor(originalShip, containerList);
            ShipRuleTester ruleTester = new ShipRuleTester(originalShip, distributor);

            bool OriginalSlotWeightMaxTest = ruleTester.TestSlotWeightMaxCapacity();


            Assert.IsFalse(OriginalSlotWeightMaxTest);
        }



        [Test]
        public void TestShipFailureMinimumWeight()
        {
            IShip FailureShip = new Ship(4, 4, 60000000, containerList);
            IContainerDistributor nastyDistribute = new ContainerDistributor(FailureShip, containerList);
            ShipRuleTester ruleTester = new ShipRuleTester(FailureShip, nastyDistribute);

            bool FailureMinimumWeightTest = ruleTester.TestMinimumWeight();

            Assert.IsTrue(FailureMinimumWeightTest);
        }
    }
}
