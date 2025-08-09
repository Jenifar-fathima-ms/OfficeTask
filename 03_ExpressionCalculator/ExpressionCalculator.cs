namespace OfficeTask
{
	public class ExpressionCalculator
	{
		public static double CalculateExpression(string strExpression)
		{
			strExpression = strExpression.Replace(" ", "");

			List<string> elements = GetExpressionElements(strExpression);

			double dResult = CalculateExpressionElements(elements);

			return dResult;
		}

		private static List<string> GetExpressionElements(string strExpression)
		{
			List<string> elements = new List<string>();
			int i = 0;
			while(i < strExpression.Length)
			{
				char cElement = strExpression[i];

				if(char.IsDigit(cElement) || cElement == '.')
				{
					int nStart = i;
					while(i < strExpression.Length && (char.IsDigit(strExpression[i]) || strExpression[i] == '.'))
						i++;
					elements.Add(strExpression.Substring(nStart, i - nStart));
					continue;
				}
				else
				{
					elements.Add(cElement.ToString());
					i++;
				}
			}
			return elements;
		}

		private static double CalculateExpressionElements(List<string> elements)
		{
			int nOpenIndex;
			while((nOpenIndex = elements.IndexOf("(")) != -1)
			{
				int nCloseIndex = FindMatchingParenthesis(elements, nOpenIndex);

				if(nCloseIndex == -1)
					throw new ArgumentException("Mismatched parentheses");

				List<string> subElements = elements.GetRange(nOpenIndex + 1, nCloseIndex - nOpenIndex - 1);

				double dSubResult = CalculateExpressionElements(subElements);

				elements.RemoveRange(nOpenIndex, nCloseIndex - nOpenIndex + 1);
				elements.Insert(nOpenIndex, dSubResult.ToString());
			}

			for(int i = 0; i < elements.Count; i++)
			{
				if(elements[i] == "*" || elements[i] == "/")
				{
					double dLeft = double.Parse(elements[i - 1]);
					double dRight = double.Parse(elements[i + 1]);
					double dResult = 0;

					if(elements[i] == "*")
						dResult = dLeft * dRight;
					else
					{
						if(dRight == 0) throw new DivideByZeroException();
						dResult = dLeft / dRight;
					}

					elements.RemoveRange(i - 1, 3);
					elements.Insert(i - 1, dResult.ToString());

					i = i - 1;
				}
			}

			for(int i = 0; i < elements.Count; i++)
			{
				if(elements[i] == "+" || elements[i] == "-")
				{
					double dLeft = double.Parse(elements[i - 1]);
					double dRight = double.Parse(elements[i + 1]);
					double dResult = 0;

					if(elements[i] == "+")
						dResult = dLeft + dRight;
					else
						dResult = dLeft - dRight;

					elements.RemoveRange(i - 1, 3);
					elements.Insert(i - 1, dResult.ToString());

					i = i - 1;
				}
			}
			if(elements.Count != 1)
				throw new Exception("Invalid expression");

			return double.Parse(elements[0]);
		}

		private static int FindMatchingParenthesis(List<string> elements, int nOpenIndex)
		{
			int nLevel = 1;
			for(int i = nOpenIndex + 1; i < elements.Count; i++)
			{
				if(elements[i] == "(") nLevel++;
				else if(elements[i] == ")") nLevel--;

				if(nLevel == 0) return i;
			}
			return -1;
		}

	}
}
