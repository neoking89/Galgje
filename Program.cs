// See https://aka.ms/new-console-template for more information

using BelastingDienst.Hangman;

//blauwe piste(voorkeur):
//maak een Hangman-console-applicatie.
//* schrijf unittests die de werking van het spel controleren.
//* toon welke letters al zijn gegokt.
//* het spel moet gereset te kunnen worden.
//* het resultaat van het spel hoort duidelijk aangegeven te worden.

Console.WriteLine("Welkom bij Galgje!");
bool playing = true;


while (playing)
{
    int allowedTries = 5;

    string wordToGuess = Hangman.GetWord();
    Hangman game = new Hangman(wordToGuess);

    RunGame(game, allowedTries);

    bool wantToPlayAgain = PromptToPlayAgain();
    if (wantToPlayAgain)
    {
        continue;
    }

    break;
}




static bool PromptToPlayAgain()
{
    Console.WriteLine("Wilt u nog een keer spelen? kies Ja of Nee");
    do
    {
        switch (Console.ReadLine()!.ToLower())
        {
            case "ja":
                return true;

            case "nee":
                Console.WriteLine("Bedankt voor het spelen!");
                return false;

            default:
                Console.WriteLine("geen geldige waarde!");
                continue;
        }

    } while (true);
}



static void RunGame(Hangman game, int allowedTries)
{

    while (allowedTries > 0)
    {
        char chosenLetter = Hangman.GetLetter();
        bool chosenLetterInWord = game.CheckIfLetterInWord(chosenLetter);

        if (!chosenLetterInWord)
        {
            allowedTries--;
        }
        else
        {
            if (game.CheckIfWordIsGuessed())
            {
                Console.WriteLine("U heeft het woord geraden, gefeliciteerd!");
                break;
            }
        }

        game.DisplayCurrentGuessedWord();

        Console.WriteLine($"\ntotaal aantal pogingen over: {allowedTries}");
        if (allowedTries <= 0)
        {
            Console.WriteLine("U heeft verloren!!");
        }
    }
}

