using Algorithm.Logic.Enum;
using Algorithm.Logic.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class DroneCommandUnitTest
    {
        [TestMethod]
        public void Input_N3()
        {
            var droneCommand = CommandFactory.GetInstance("N3");
            var move = droneCommand.GetMove();

            Assert.IsTrue(droneCommand.Is(CommandType.N));
            Assert.AreEqual("N3", droneCommand.ToString());
            Assert.AreEqual(0, move.X);
            Assert.AreEqual(3, move.Y);
        }

        [TestMethod]
        public void Input_N()
        {
            var droneCommand = CommandFactory.GetInstance("N");
            var move = droneCommand.GetMove();

            Assert.IsTrue(droneCommand.Is(CommandType.N));
            Assert.AreEqual("N", droneCommand.ToString());
            Assert.AreEqual(0, move.X);
            Assert.AreEqual(1, move.Y);
        }

        [TestMethod]
        public void Input_X()
        {
            var droneCommand = CommandFactory.GetInstance("X");
            var move = droneCommand.GetMove();

            Assert.IsTrue(droneCommand.Is(CommandType.X));
            Assert.IsTrue(droneCommand.IsCancel());
            Assert.AreEqual("X", droneCommand.ToString());
            Assert.AreEqual(0, move.X);
            Assert.AreEqual(0, move.Y);
        }

        [TestMethod]
        public void Input_O999()
        {
            var droneCommand = CommandFactory.GetInstance("O999");
            var move = droneCommand.GetMove();

            Assert.IsTrue(droneCommand.Is(CommandType.O));
            Assert.AreEqual("O999", droneCommand.ToString());
            Assert.AreEqual(-999, move.X);
            Assert.AreEqual(0, move.Y);
        }
    }
}