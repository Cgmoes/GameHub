using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
	public class HangmanController
	{
		private HangmanObserver hangmanObs;
		private ControllerSwitchDel cntrlDel;
		private static readonly char[] ALPHABET = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
		private char[]? guesses = new char []{ };
		private char[] guessWord = new char[] { };
		private static string CORRECT_WORD = "";
		private static string[] WORD_BANK = new string[] { };

		/// <summary>
		/// Sets the delegates
		/// </summary>
		/// <param name="h">The method in the form</param>
		/// <param name="c">the method in the main controller</param>
		public void SetDelegates(HangmanObserver h, ControllerSwitchDel c)
		{
			hangmanObs = h;
			cntrlDel = c;
		}

		/// <summary>
		/// Controls the inputs sent by the hangman form
		/// </summary>
		/// <param name="choice">The state of the game</param>
		public void MenuInput(GameChoice choice)
		{
			switch (choice)
			{
				case GameChoice.Menu:
					cntrlDel();
					break;
			}
		}

		/// <summary>
		/// Called on the first bootup of hangman
		/// </summary>
		public void Start() 
		{
			ResetVariables();
			hangmanObs(CORRECT_WORD, new string(guessWord), guesses!, false, true, true);
		}

		/// <summary>
		/// Calculates if a guess was correct or not and
		/// replaces the underline with the correct letter
		/// </summary>
		/// <param name="guess">The letter guessed</param>
		public void MadeGuess(char guess) 
		{
			bool goodGuess = false;
			if (!ValidGuess(guess))
			{
				hangmanObs(CORRECT_WORD, "ALREADY GUESSED", guesses!, false, true, false);
			}
			else
			{
				for (int i = 0; i < CORRECT_WORD.Length; i++)
				{
					if (CORRECT_WORD[i].Equals(guess))
					{
						guessWord[i * 2] = guess;
						goodGuess = true;
					}
				}
				string noSpaceGuessWrd = new string(guessWord).Replace(" ", "");
				if (CORRECT_WORD.Equals(noSpaceGuessWrd))
				{
					hangmanObs(CORRECT_WORD, new string(guessWord), guesses!, true, goodGuess, false);
				}
				else
				{
					hangmanObs(CORRECT_WORD, new string(guessWord), guesses!, false, goodGuess, false);
				}
			}
		}

		/// <summary>
		/// Determines if a guess is valid
		/// </summary>
		/// <param name="guess">The letter to guess</param>
		/// <returns>Whether or not the guess is valid</returns>
		public bool ValidGuess(char guess) 
		{
			if (guesses!.Contains(guess))
			{
				return false;
			}
			else 
			{
				char[] tempArr = new char[guesses!.Length + 1];
				Array.Copy(guesses, tempArr, guesses.Length);
				tempArr[tempArr.Length - 1] = guess;
				guesses = tempArr;
				return true;
			}
		}

		/// <summary>
		/// Resets all variables for the start of the game
		/// </summary>
		public void ResetVariables()
		{
			WORD_BANK = File.ReadAllLines("words.txt");
			Random random = new Random();
			CORRECT_WORD = WORD_BANK[random.Next(WORD_BANK.Length)];
			Debug.WriteLine(CORRECT_WORD); //THE CORRECT WORD
			guesses = new char[] { };
			guessWord = new char[CORRECT_WORD.Length * 2];
			for (int i = 0; i < guessWord.Length - 1; i += 2)
			{
				guessWord[i] = '_';
				guessWord[i + 1] = ' ';
			}
		}
	}
}