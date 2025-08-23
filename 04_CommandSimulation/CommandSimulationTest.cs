using CommandSimulationProject;

namespace CommandSimulationProjectTest
{
	[TestClass]
	public class CommandSimulationTest
	{
		#region Tests
		[TestMethod]
		public void Test_CommandSimulation_RelativePathCommand()
		{
			//Arrange
			List<string> inputCommands = new List<string>
										 {
											 "cd /home",
											 "cd user",
											 "pwd",
											 "cd ..",
											 "pwd",
											 "cd ./projects/../code",
											 "pwd"
										 };
			//Act
			List<string> outputPaths = CommandSimulation.SimulateCommands(inputCommands);

			//Assert
			Assert.AreEqual(outputPaths.Count, 3);
			Assert.AreEqual(outputPaths[0], "/home/user/");
			Assert.AreEqual(outputPaths[1], "/home/");
			Assert.AreEqual(outputPaths[2], "/home/code/");
		}
		[TestMethod]
		public void Test_CommandSimulation_AbsolutePathCommand()
		{
			//Arrange
			List<string> inputCommands = new List<string>
										 {
											 "cd /",
											 "cd home",
											 "cd ./user//",
											 "cd ../..",
											 "cd ../..",
											 "cd var/log",
											 "pwd",
											 "cd /etc/./nginx/../ssh",
											 "pwd",
											 "cd ..",
											 "pwd"
										 };
			//Act
			List<string> outputPaths = CommandSimulation.SimulateCommands(inputCommands);

			//Assert
			Assert.AreEqual(outputPaths.Count, 3);
			Assert.AreEqual(outputPaths[0], "/var/log/");
			Assert.AreEqual(outputPaths[1], "/etc/ssh/");
			Assert.AreEqual(outputPaths[2], "/etc/");
		}
		[TestMethod]
		public void Test_CommandSimulation_WrongCommand()
		{
			//Arrange
			List<string> inputCommands = new List<string>
										 {
											 "cd /home",
											 "cd user",
											 "cdn",
											 "pwd",
											 "cd ./projects/../code",
											 "pwd"
										 };
			//Act
			List<string> outputPaths = CommandSimulation.SimulateCommands(inputCommands);

			//Assert
			Assert.AreEqual(outputPaths.Count, 3);
			Assert.AreEqual(outputPaths[0], "Enter Valid command");
			Assert.AreEqual(outputPaths[1], "/home/user/");
			Assert.AreEqual(outputPaths[2], "/home/user/code/");
		}
		[TestMethod]
		public void Test_CommandSimulation_NoCommand()
		{
			//Arrange
			List<string> inputCommands = new List<string> { };

			//Act
			List<string> outputPaths = CommandSimulation.SimulateCommands(inputCommands);

			//Assert
			Assert.AreEqual(outputPaths.Count, 0);
		}
		#endregion
	}
}