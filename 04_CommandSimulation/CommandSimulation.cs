using System.Text;

namespace CommandSimulationProject
{
	public class CommandSimulation
	{
		static Stack<string> folderStack = new Stack<string>();

		public static List<string> SimulateCommands(List<string> commands)
		{
			List<string> finalpathList = new List<string>();
			StringBuilder pathBuilder = new StringBuilder();

			foreach(var command in commands)
			{
				string[] commandTypes = command.Split(' ');

				switch(commandTypes[0])
				{
					case "cd":
						GetFolderStack(commandTypes[1]);
						break;

					case "pwd":
						pathBuilder.Clear().Append("/");
						string[] reversedFolderList = folderStack.ToArray();
						for(int j = reversedFolderList.Length - 1; j >= 0; j--)
						{
							pathBuilder.Append(reversedFolderList[j]).Append("/");
						}

						finalpathList.Add(pathBuilder.ToString());
						break;

					default:
						finalpathList.Add("Enter Valid command");
						break;
				}
			}

			return finalpathList;
		}

		public static void GetFolderStack(string strFolderCommand)
		{
			if(strFolderCommand.StartsWith("/"))
			{
				folderStack.Clear();
			}

			string[] folders = strFolderCommand.Split('/').Where(x => x != "").ToArray();

			foreach(string strFolder in folders)
			{
				switch(strFolder)
				{
					case ".":
						break;
					case "..":
						if(folderStack.Count > 0)
							folderStack.Pop();
						break;
					default:
						folderStack.Push(strFolder);
						break;
				}
			}
		}
	}
}