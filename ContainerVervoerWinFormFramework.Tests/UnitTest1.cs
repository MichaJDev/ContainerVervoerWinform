//using System;
//using System.Collections;
//using System.Collections.Generic;
//using ContainerVervoerWinFormFramework.ContainerDistributors;
//using ContainerVervoerWinFormFramework.ContainerDistributors.Interface;
//using ContainerVervoerWinFormFramework.ShipRules;
//using ContainerVervoerWinFormFramework.Ships;
//using ContainerVervoerWinFormFramework.Ships.Containers;
//using ContainerVervoerWinFormFramework.Ships.Containers.Enums;
//using ContainerVervoerWinFormFramework.Ships.Containers.Interface;
//using ContainerVervoerWinFormFramework.Ships.Interface;
//using NUnit.Framework;

//namespace ContainerVervoerWinFormFramework.Tests
//{
//    public class Tests
//    {
//        static Random rdm = new Random(Guid.NewGuid().GetHashCode());
//        static int ContainerWeight = rdm.Next(1 - 26000);
//        IList<IContainer> containerList = new List<IContainer>
//        {

//            new Container(ContainerWeight, ContainerType.Cooled),
//            new Container(ContainerWeight, ContainerType.Cooled),
//            new Container(ContainerWeight, ContainerType.Cooled),
//            new Container(ContainerWeight, ContainerType.Normal),
//            new Container(ContainerWeight, ContainerType.Normal),
//            new Container(ContainerWeight, ContainerType.Normal),
//            new Container(ContainerWeight, ContainerType.Normal),
//            new Container(ContainerWeight, ContainerType.Normal),
//            new Container(ContainerWeight, ContainerType.Normal),
//            new Container(ContainerWeight, ContainerType.Valuable),
//            new Container(ContainerWeight, ContainerType.Valuable),
//            new Container(ContainerWeight, ContainerType.Valuable),
//            new Container(ContainerWeight, ContainerType.Valuable)
//        };

//        [SetUp]
//        public void Setup()
//        {

//        }

//        [Test]
//        public void TestBalanceSucceed()
//        {
//            /// <summary> TestRun with original Information</summary>
//            /// <remarks> This test should return true</remarks>
//            int width = 3;
//            int height = 3;
//            IShip originalShip = new Ship(width, height, (width * height) * 150000, containerList);
//            IContainerDistributor distributor = new ContainerDistributor(originalShip, );
//            ShipRuleTester ruleTester = new ShipRuleTester(originalShip, distributor, t);
//            bool OriginalBalanceTest = ruleTester.TestBalance();


//            Assert.IsTrue(OriginalBalanceTest);

//        }
//        [Test]
//        public void TestMaximumWeightSucceed()
//        {
//            /// <summary> TestRun with original Information</summary>
//            /// <remarks> This test should return true</remarks>
//            int width = 3;
//            int height = 3;
//            IShip originalShip = new Ship(width, height, (width * height) * 150000, containerList);
//            IContainerDistributor distributor = new ContainerDistributor(originalShip, containerList);
//            ShipRuleTester ruleTester = new ShipRuleTester(originalShip, distributor, containerList);

//            bool OriginalMaxWeightTest = ruleTester.TestMaximumWeight();
            
//            Assert.IsTrue(OriginalMaxWeightTest);
//        }
//        [Test]
//        public void TestMinimumWeightSucceed()
//        {
//            /// <summary> TestRun with original Information</summary>
//            /// <remarks> This test should return true</remarks>
//            int width = 3;
//            int height = 3;
//            IShip originalShip = new Ship(width, height, (width * height) * 150000, containerList);
//            IContainerDistributor distributor = new ContainerDistributor(originalShip, containerList);
//            ShipRuleTester ruleTester = new ShipRuleTester(originalShip, distributor, containerList);

//            bool OriginalMinimumWeightTest = ruleTester.TestMinimumWeight();

//            Assert.IsTrue(OriginalMinimumWeightTest);

//        }
//        [Test]
//        public void TestMaxStackWeightSucceed()
//        {

//            int width = 3;
//            int height = 3;
//            IShip originalShip = new Ship(width, height, (width * height) * 150000, containerList);
//            IContainerDistributor distributor = new ContainerDistributor(originalShip, containerList);
//            ShipRuleTester ruleTester = new ShipRuleTester(originalShip, distributor, containerList);

//            bool OriginalSlotWeightMaxTest = ruleTester.TestSlotWeightMaxCapacity();


//            Assert.IsTrue(OriginalSlotWeightMaxTest);
//        }
//        [Test]
//        public void TestShipFailureBalance()
//        {

//            IShip FailureShip = new Ship(4, 4, 60000000, containerList);
//            IContainerDistributor nastyDistribute = new ContainerDistributor(FailureShip, containerList);
//            ShipRuleTester ruleTester = new ShipRuleTester(FailureShip, nastyDistribute, containerList);

//            bool FailureBalanceTest = ruleTester.TestBalance();
            
//            Assert.IsTrue(FailureBalanceTest);
//        }

//        [Test]
//        public void TestShipFailureMaximumWeight()
//        {
//            IShip FailureShip = new Ship(4, 4, 60000000, containerList);
//            IContainerDistributor nastyDistribute = new ContainerDistributor(FailureShip, containerList);
//            ShipRuleTester ruleTester = new ShipRuleTester(FailureShip, nastyDistribute, containerList);

//            bool FailureMaximumWeightTest = ruleTester.TestMaximumWeight();

//            Assert.IsTrue(FailureMaximumWeightTest);
//        }
//        [Test]
//        public void TestShipFailureMinimumWeight()
//        {
//            IShip FailureShip = new Ship(4, 4, 60000000, containerList);
//            IContainerDistributor nastyDistribute = new ContainerDistributor(FailureShip, containerList);
//            ShipRuleTester ruleTester = new ShipRuleTester(FailureShip, nastyDistribute, containerList);

//            bool FailureMinimumWeightTest = ruleTester.TestMinimumWeight();

//            Assert.IsFalse(FailureMinimumWeightTest);
//        }
//        [Test]
//        public void TestShipFailureStackMaxWeight()
//        {
//            IShip FailureShip = new Ship(4, 4, 60000000, containerList);
//            IContainerDistributor nastyDistribute = new ContainerDistributor(FailureShip, containerList);
//            ShipRuleTester ruleTester = new ShipRuleTester(FailureShip, nastyDistribute, containerList);

//            bool FaulureSlotWeightMaxTest = ruleTester.TestSlotWeightMaxCapacity();

//            Assert.IsFalse(FaulureSlotWeightMaxTest);
//        }
//    }
//}