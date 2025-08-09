namespace OfficeTask.Tests
{
	[TestClass]
	public class ExpressionCalculatorTest
	{
		[TestMethod]
		public void CalculateExpression_SimpleAdditiont()
		{
			string strExpression = "2+3";
			double dExpected = 5;
			double dActual = ExpressionCalculator.CalculateExpression(strExpression);
			Assert.AreEqual(dExpected, dActual);
		}

		[TestMethod]
		public void CalculateExpression_MixedOperators()
		{
			string strExpression = "8+2-(2*3)/5-1";
			double dExpected = 7.8;
			double dActual = ExpressionCalculator.CalculateExpression(strExpression);
			Assert.AreEqual(dExpected, dActual, 0.0001);
		}

		[TestMethod]
		public void CalculateExpression_InBetweenWhiteSpaces()
		{
			string strExpression = "3 + (2 * 4)- 5 / (1 + 1)";
			double dExpected = 8.5;
			double dActual = ExpressionCalculator.CalculateExpression(strExpression);
			Assert.AreEqual(dExpected, dActual, 0.0001);
		}

		[TestMethod]
		public void CalculateExpression_WithParentheses()
		{
			string strExpression = "(8+2)*(5-3)";
			double dExpected = 20;
			double dActual = ExpressionCalculator.CalculateExpression(strExpression);
			Assert.AreEqual(dExpected, dActual);
		}

		[TestMethod]
		public void CalculateExpression_DecimalNumbers()
		{
			string strExpression = "6/3+1.5*2";
			double dExpected = 5;
			double dActual = ExpressionCalculator.CalculateExpression(strExpression);
			Assert.AreEqual(dExpected, dActual);
		}

		[TestMethod]
		[ExpectedException(typeof(System.DivideByZeroException))]
		public void CalculateExpression_DivisionByZero()
		{
			string strExpression = "10/0";
			ExpressionCalculator.CalculateExpression(strExpression);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void CalculateExpression_InvalidCharacter()
		{
			string strExpression = "2+3a";
			ExpressionCalculator.CalculateExpression(strExpression);
		}

		[TestMethod]
		public void CalculateExpression_SingleNumber()
		{
			string strExpression = "42";
			double dExpected = 42;
			double dActual = ExpressionCalculator.CalculateExpression(strExpression);
			Assert.AreEqual(dExpected, dActual);
		}
	}
}
