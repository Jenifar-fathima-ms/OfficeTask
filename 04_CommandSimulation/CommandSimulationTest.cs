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
			Assert.AreEqual(3, outputPaths.Count);
			Assert.AreEqual("/home/user/", outputPaths[0]);
			Assert.AreEqual("/home/", outputPaths[1]);
			Assert.AreEqual("/home/code/", outputPaths[2]);
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
			Assert.AreEqual(3, outputPaths.Count);
			Assert.AreEqual("/var/log/", outputPaths[0]);
			Assert.AreEqual("/etc/ssh/", outputPaths[1]);
			Assert.AreEqual("/etc/", outputPaths[2]);
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
			Assert.AreEqual(3, outputPaths.Count);
			Assert.AreEqual("Enter Valid command", outputPaths[0]);
			Assert.AreEqual("/home/user/", outputPaths[1]);
			Assert.AreEqual("/home/user/code/", outputPaths[2]);
		}
		[TestMethod]
		public void Test_CommandSimulation_NoCommand()
		{
			//Arrange
			List<string> inputCommands = new List<string> { };

			//Act
			List<string> outputPaths = CommandSimulation.SimulateCommands(inputCommands);

			//Assert
			Assert.AreEqual(0, outputPaths.Count);
		}
		#endregion
	}
}