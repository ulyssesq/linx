using System.Linq;
using Algorithm.Logic.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class DroneCommandUnitTest
    {
        [TestMethod]
        public void Input_N3()
        {
            var droneCommand = new DroneCommand("N3");

            Assert.AreEqual(CommandType.N, droneCommand.Type);
            Assert.AreEqual(3, droneCommand.Quantity);
        }

        [TestMethod]
        public void Input_N()
        {
            var droneCommand = new DroneCommand("N");

            Assert.AreEqual(CommandType.N, droneCommand.Type);
            Assert.AreEqual(1, droneCommand.Quantity);
        }

        [TestMethod]
        public void Input_X()
        {
            var droneCommand = new DroneCommand("X");

            Assert.AreEqual(CommandType.X, droneCommand.Type);
            Assert.AreEqual(1, droneCommand.Quantity);
        }

        [TestMethod]
        public void Input_O999()
        {
            var droneCommand = new DroneCommand("O999");

            Assert.AreEqual(CommandType.O, droneCommand.Type);
            Assert.AreEqual(999, droneCommand.Quantity);
        }

        [TestMethod]
        public void Input_O999_ToString()
        {
            var droneCommand = new DroneCommand("O999");
            Assert.AreEqual("O999", droneCommand.ToString());
        }

        [TestMethod]
        public void Input_X_ToString()
        {
            var droneCommand = new DroneCommand("X");
            Assert.AreEqual("X", droneCommand.ToString());
        }
    }
}