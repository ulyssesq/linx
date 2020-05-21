using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class DroneManagerUnitTest
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

        [TestMethod]
        public void Input_Simplified_N2N2NXX()
        {
            DroneManager manager = new DroneManager("N2N2NXX");

            Assert.AreEqual("N2", manager.GetSimplifiedInput());
        }

        [TestMethod]
        public void Input_Simplified_NNNXLLLXX()
        {
            DroneManager manager = new DroneManager("NNNXLLLXX");

            Assert.AreEqual("NNL", manager.GetSimplifiedInput());
        }
    }
}
