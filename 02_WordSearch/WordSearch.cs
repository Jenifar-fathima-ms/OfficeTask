namespace LearningTaskWordSearch
{
	public class WordSearch
	{
		static int nRow, nCol;
		static char[][] board;
		static string strWord;

		public static bool Exist(char[][] boardInput, string strWordInput)
		{
			board = boardInput;
			strWord = strWordInput;
			nRow = board.Length;
			nCol = board[0].Length;

			for(int r = 0; r < nRow; r++)
			{
				for(int c = 0; c < nCol; c++)
				{
					if(board[r][c] == strWord[0])
					{
						if(SearchWord(r, c, 0)) return true;
					}
				}
			}
			return false;
		}

		static bool SearchWord(int nLetterRow, int nLetterCol, int nIndex)
		{
			if(nIndex == strWord.Length) return true; 
			if(nLetterRow < 0 || nLetterCol < 0 || nLetterRow >= nRow || nLetterCol >= nCol || board[nLetterRow][nLetterCol] != strWord[nIndex]) return false;

			char cTemp = board[nLetterRow][nLetterCol];
			board[nLetterRow][nLetterCol] = '#'; 

			bool bFound = SearchWord(nLetterRow + 1, nLetterCol, nIndex + 1) ||
			             SearchWord(nLetterRow - 1, nLetterCol, nIndex + 1) ||
			             SearchWord(nLetterRow, nLetterCol + 1, nIndex + 1) ||
			             SearchWord(nLetterRow, nLetterCol - 1, nIndex + 1);

			board[nLetterRow][nLetterCol] = cTemp; 
			return bFound;
		}
	}
}
