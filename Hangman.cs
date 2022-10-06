using System;

namespace BelastingDienst.Hangman
{
    public class Hangman

    {
        string chosenWord;
        char[] guessedWord;

        public Hangman(string WordToGuess)
        {
            chosenWord = WordToGuess;
            guessedWord = new char[chosenWord.Length];
        }

        public void DisplayCurrentGuessedWord()
        {
            Console.WriteLine("Huidige woord:");
            foreach (char c in chosenWord)
            {
                if (guessedWord.Contains(c))
                {
                    Console.Write(c);
                }
                else
                {
                    Console.Write('_');
                }
            }
        }

        public static char GetLetter()
        {
            char chosenLetter;
            while (true)
            {
                Console.Write("\nVoer een letter in: ");
                string ? userInput = Console.ReadLine() ?? string.Empty;

                if (WordValidator.ChosenLetterIsValid(userInput))
                {
                    chosenLetter = char.Parse(userInput.ToLower());
                    break;
                }
            }
            return chosenLetter;
        }

        public static string GetWord()
        {
            string ? wordToGuess;

            while (true)
            {
                Console.WriteLine("\nVoer een woord in om te raden:");
                wordToGuess = Console.ReadLine();
                if (WordValidator.WordToGuessIsValid(wordToGuess))
                {
                    break;
                }
                continue;
            }

            return wordToGuess!.ToLower();

        }

        public bool LetterInWord(char letter)
        {
            int index = chosenWord.IndexOf(letter);
            if (index > -1)
            {
                return true;
            }
            return false;   
        }

        public bool CheckIfLetterInWord(char chosenLetter)
        {
            if (guessedWord.Contains(chosenLetter))
            {
                Console.WriteLine("Deze letter zit in het woord, maar heeft u al gekozen!");
                return false;
            }

            else if (LetterInWord(chosenLetter))
            {
                Console.WriteLine("Goed gekozen!");

                int index = 0;

                foreach (var letter in chosenWord)
                {
                    if (letter == chosenLetter)
                    {
                        guessedWord[index] = letter;
                    }
                    index++;
                }
                return true;
            }
            Console.WriteLine("Deze letter zit niet in het woord");
            return false;
        }

        public bool CheckIfWordIsGuessed()
        {
            var guessedWordString = new string(guessedWord);
            return guessedWordString == chosenWord;
        }
    }
}
