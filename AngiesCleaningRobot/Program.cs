using AngiesCleaningRobot;

Console.WriteLine("Insert number of commands:");
int commandNum = int.Parse(Console.ReadLine());

Console.WriteLine("Insert robot position:");
var pos = Console.ReadLine().Split(" ");

List<Command> commands = new List<Command>();
MyRobot robot = new MyRobot(int.Parse(pos[0]), int.Parse(pos[1]));

for(int i = 1; i <= commandNum; i++)
{
    Console.WriteLine($"Insert {i} command:");
    var command = Console.ReadLine().Split(" ");
    commands.Add(new Command((Direction)Enum.Parse(typeof(Direction), command[0]), int.Parse(command[1])));
}

RobotCommander commander = new RobotCommander(robot, commands);
var cleanedMessage = commander.CleanAll();
Console.WriteLine(cleanedMessage);