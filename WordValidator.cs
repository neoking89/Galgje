using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelastingDienst.Hangman
{
    public static class WordValidator
    {
        public static bool ContainsOnlyLetters(string word)
        {
            return word.All(Char.IsLetter);
        }

        public static bool ContainsWhiteSpace(string word)
        {
            return word.Any(x => Char.IsWhiteSpace(x));
        }

        public static bool WordToGuessIsValid(string wordToGuess)
        {
            if (string.IsNullOrEmpty(wordToGuess))
            {
                Console.WriteLine("niks ingevoerd!");
                return false;
            }
            else if (WordValidator.ContainsWhiteSpace(wordToGuess))
            {
                Console.WriteLine($"{wordToGuess} bevat spaties! Kies aub een woord zonder spaties.");
                return false;
            }
            else if (!WordValidator.ContainsOnlyLetters(wordToGuess))
            {
                Console.WriteLine($"{wordToGuess} gekozen, maar woord mag alleen letters bevatten!");
                return false;
            }
            return true;
        }

        public static bool ChosenLetterIsValid(string chosenLetter)
        {
            if (string.IsNullOrEmpty(chosenLetter))
            {
                Console.WriteLine("geen letter gekozen! probeer opnieuw.");
                return false;
            }
            else if (!WordValidator.ContainsOnlyLetters(chosenLetter))
            {
                Console.WriteLine("gekozen letter is geen letter!");
                return false;
            }
            else if (chosenLetter.Length > 1)
            {
                Console.WriteLine("gekozen letter overschrijdt lengte van 1!");
                return false;
            }
            return true;
        }
    }
}
