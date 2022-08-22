using AngiesCleaningRobot;

namespace TestMyCleaningRobot
{
    [TestClass]
    public class CleaningRobotTests
    {
        [TestMethod]
        public void TestStartingPosition()
        {
            List<Command> commands = new List<Command>() { new Command(Direction.DontMove) }; 
            MyRobot robot = new MyRobot(10, 10);
            RobotCommander commander = new RobotCommander(robot, commands);

            Assert.AreEqual("Cleaned: 1", commander.CleanAll(), "Robot should also clean it's starting point before moving.");
        }


        [TestMethod]
        public void TestNotCleanedPositions()
        {
            List<Command> commands = new List<Command>();
            commands.Add(new Command(Direction.E, 2));
            commands.Add(new Command(Direction.N, 1));

            MyRobot robot = new MyRobot(10, 10);
            RobotCommander commander = new RobotCommander(robot, commands);

            Assert.AreEqual("Cleaned: 4", commander.CleanAll(), "Robot should have cleaned 4 places");
        }


        [TestMethod]
        public void TestAlreadyCleanedPositions()
        {
            List<Command> commands = new List<Command>();
            commands.Add(new Command(Direction.E, 1));
            commands.Add(new Command(Direction.W, 1));

            MyRobot robot = new MyRobot(10, 10);
            RobotCommander commander = new RobotCommander(robot, commands);

            var totatCleaned = commander.CleanAll();
            Assert.AreEqual("Cleaned: 2", totatCleaned, "Robot should have cleaned 2 places");
        }


        [TestMethod]
        public void TestAlreadyCleanedPositionsComplex()
        {
            List<Command> commands = new List<Command>();
            commands.Add(new Command(Direction.E, 5));
            commands.Add(new Command(Direction.N, 7));
            commands.Add(new Command(Direction.W, 5));
            commands.Add(new Command(Direction.W, 7));

            MyRobot robot = new MyRobot(10, 10);
            RobotCommander commander = new RobotCommander(robot, commands);

            var totatCleaned = commander.CleanAll();
            Assert.AreEqual("Cleaned: 2", totatCleaned, "Robot should have cleaned 24 places");
        }
    }
}