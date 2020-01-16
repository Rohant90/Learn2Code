using NUnit.Framework;
using System;
using System.IO;
using CalculatorApp;
using Moq;

namespace Tests
{ //FYI all commented code are leftover references during learning.  Should be ignored during review.
	public class Tests
	{
		[Test]
		public void PromptUserTest()
		{
			/*test that the user is being prompted to enter a number
			Simulating the console for this to assert on expected/actual prompt*/
			var calc = new CalculatorApp.Program();
			StringWriter output = new StringWriter();
			Console.SetOut(output);
			calc.PromptUserQuestion();
			string expected = string.Format("Type a number, and then press Enter\r\n", Environment.NewLine);

			Assert.AreEqual(expected, output.ToString());

		}

		[Test]
		public void UserInput1Test()
		{
			var calc = new CalculatorApp.Program();
			//var Moq = new Mock<CalculatorApp.Program>();

			//Verify that submitting a valid string to float convertible value is accepted.
			Assert.That(calc.UserInput1("5").Equals(5));
			/*Verify that a non-integer user input will not be accepted
			Assert.That(calc.UserInput1("r").Equals(5));
			The above test results in an outofmemory exception because 
			I cannot simulate a second entry once the first input fails - test sucks and leaves vulnerability?.*/

			//Validate user input is indeed parsed as the correct value
			Assert.False(calc.UserInput1("5").Equals(6));
			//Verify that user input does not return back as a string, but instead as an integer.
			Assert.False(calc.UserInput1("6").Equals("6"));
		}
		
		[Test]
		public void UserInput2Test()
		{

			var calc = new CalculatorApp.Program();
			//Here I am simulating the console to validate a simulated input string with an the expected output.  
			/*var output = new StringWriter();
			string expectedresult = (string.Format("Type another number, and then press Enter\r\n5\r\n", Environment.NewLine));
			Console.SetOut(output);
			var input = new StringReader("5");
			Console.SetIn(input);
			var input2 = new StringReader("5");
			Console.SetIn(input2);

			calc.UserInput2();
			//num1 = (float)Convert.ToDecimal(output);

			Assert.That(output.ToString(), Is.EqualTo(expectedresult));*/

			//Assert input values are accurately parsed into decimals.  Assert false if the values don't parse to their expected outcome.
			Assert.That(calc.UserInput2("3").Equals(3));
			Assert.False(calc.UserInput2("1").Equals(1.1));
			Assert.False(calc.UserInput2("1").Equals("1"));

		}

		[Test]
		public void UserAnswer()
		{
			var calc = new CalculatorApp.Program();
			var output = new StringWriter();
			//This sort of works like an integration test because it simulates the console
			//Below, validate that when num1 & num2 are 0, the response is as expected on the console when you try to do addition arithmetic.
			string expectedresult = (string.Format("Your result: 0 + 0 = 0\r\n", Environment.NewLine));
			Console.SetOut(output);
			var input = new StringReader("a");
			Console.SetIn(input);

			calc.UserAnswer();
			Assert.That(output.ToString(), Is.EqualTo(expectedresult));
			//Assert.False(calc.UserAnswer("t").Equals("Invalid input please try again\r\n"));
			Assert.That(calc.UserAnswer("a").Equals("a"));
		}
	}
}
