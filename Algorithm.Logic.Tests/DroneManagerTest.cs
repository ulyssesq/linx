using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class DroneManagerTest
    {
        [TestMethod]
        public void Input_NNN()
        {
            DroneManager manager = new DroneManager("NNN");
            manager.DroneCommands.Count();

            int exptected = 3;
            Assert.AreEqual(exptected, manager.DroneCommands.Count());
        }

        [TestMethod]
        public void Input_N2N2NXX()
        {
            DroneManager manager = new DroneManager("N2N2NXX");
            manager.DroneCommands.Count();

            int exptected = 5;
            Assert.AreEqual(exptected, manager.DroneCommands.Count());
        }
    }
}
