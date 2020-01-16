using System;

namespace CalculatorApp
{
	public class Program
	{
		float Number;
		float num2;
		float num1;
		public static void Main(string[] args)
		{
			// Display title as the C# console calculator app.

			Console.WriteLine("Console Calculator in C#\r");
			Console.WriteLine("------------------------\n");
			//Console.ReadKey();
			var program = new Program();
			// execute program functions
			program.PromptUserQuestion();
			program.UserInput1();
			program.UserInput2();
			program.UserOption();
			program.UserAnswer();
			program.PromptUserExit();
		}
		public void PromptUserQuestion()
		{
			// Ask the user to type the first number.
			Console.WriteLine("Type a number, and then press Enter");
		}
		public virtual float UserInput1(string optInput = null)
		{
			bool Valid = false;
			while (Valid == false)
			{
				string Input = optInput ?? Console.ReadLine();
				//if the Input cannot be parsed into a decimal number, then reject it.
				if (!float.TryParse(Input, out Number))
				{
					Console.WriteLine("Not an integer, please try again.");
				}
				else
				{
					Valid = true;
					num1 = (float)Convert.ToDecimal(Input);
				}
			}
			return num1;
		}
		public virtual float UserInput2(string optInput = null)
		{
			// Ask the user to type the second number.
			Console.WriteLine("Type another number, and then press Enter");
			bool Valid2 = false;
			while (Valid2 == false)
			{   //if the Input cannot be parsed into a decimal number, then reject it.
				string Input2 = optInput ?? Console.ReadLine();
				if (!float.TryParse(Input2, out Number))
				{
					Console.WriteLine("Not an integer, please try again.");
				}
				else
				{
					Valid2 = true;
					num2 = (float)Convert.ToDecimal(Input2);
				} 
			}
			return num2;
		}

		public void UserOption()
		{
			// Ask the user to choose an option.
			Console.WriteLine("Choose an option from the following list:");
			Console.WriteLine("\ta - Add");
			Console.WriteLine("\ts - Subtract");
			Console.WriteLine("\tm - Multiply");
			Console.WriteLine("\td - Divide");
			Console.Write("Your option? ");
		}

		public string UserAnswer(string optInput = null) //int? num1 = 0, int? num2 = 0 - was trying to use these as optional params so i can test math expressions - failed.
		{
			bool isOperatorValid;
			do
			{
				//Validate arithmetic expression based off user Input
				string answer = optInput ?? Console.ReadLine();
				isOperatorValid = true;
				switch (answer)
				{
					case "a":
						Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
						break;
					case "s":
						Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
						break;
					case "m":
						Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
						break;
					case "d":
						Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
						break;
					default:
						Console.WriteLine("Invalid input please try again");
						isOperatorValid = false;
						break;
				};
			} while (!isOperatorValid);
			return optInput;
		}
		public void PromptUserExit()
		{
			// Wait for the user to respond before closing.
			Console.Write("Press any key to close the Calculator console app...");
			Console.ReadKey();
		}
	}
}