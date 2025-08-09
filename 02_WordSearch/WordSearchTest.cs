using LearningTaskWordSearch;

namespace LearningTaskWordSearchTest
{
	internal class WordSearchTest
	{
		[TestMethod]
		public void TestWordFound()
		{
			char[][] board = new char[][] {
				new char[] {'A','B','C','E'},
				new char[] {'S','F','C','S'},
				new char[] {'A','D','E','E'}
			};
			string strWord = "ABCCED";

			bool bResult = WordSearch.Exist(board, strWord);

			Assert.IsTrue(bResult, "The word should be found in the board.");
		}

		[TestMethod]
		public void TestWordNotFound()
		{
			char[][] board = new char[][] {
				new char[] {'A','B','C','E'},
				new char[] {'S','F','C','S'},
				new char[] {'A','D','E','E'}
			};
			string strWord = "ABCB";

			bool bResult = WordSearch.Exist(board, strWord);

			Assert.IsFalse(bResult, "The word should not be found in the board.");
		}

		[TestMethod]
		public void TestSingleLetterWordFound()
		{
			char[][] board = new char[][] {
				new char[] {'A','B'},
				new char[] {'C','D'}
			};
			string strWord = "C";

			bool bResult = WordSearch.Exist(board, strWord);

			Assert.IsTrue(bResult, "Single letter word should be found if present.");
		}

		[TestMethod]
		public void TestEmptyWord()
		{
			char[][] board = new char[][] {
				new char[] {'A','B'},
				new char[] {'C','D'}
			};
			string strWord = "";

			bool bResult = WordSearch.Exist(board, strWord);

			Assert.IsFalse(bResult, "Empty word should return false.");
		}

		[TestMethod]
		public void TestWordWithBackwardPath()
		{
			char[][] board = new char[][] {
				new char[] {'A','B','C','D'},
				new char[] {'E','F','G','H'},
				new char[] {'I','J','K','L'}
			};
			string strWord = "GFEA"; 

			bool bResult = WordSearch.Exist(board, strWord);

			Assert.IsTrue(bResult, "The word should be found even if following backward direction.");
		}
	}    
}
