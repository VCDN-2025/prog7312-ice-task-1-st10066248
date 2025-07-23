using System;
using System.Collections.Generic;

class GuessingGame
{
    static void Main()
    {
        Console.WriteLine("🌟 Welcome to the Guessing Game! 🌟");
        Console.WriteLine("Try to guess the secret word (it's an animal).");
        Console.WriteLine("You get 5 guesses, +10 points for correct, -1 for wrong.");
        Console.WriteLine("----------------------------------------");

        // List of possible secret words
        List<string> animals = new List<string> { "elephant", "giraffe", "kangaroo", "dolphin", "penguin", "cheetah" };

        // Initialize leaderboard
        List<int> leaderboard = new List<int>();

        bool playAgain = true;

        while (playAgain)
        {
            // Select a random word
            Random random = new Random();
            string secretWord = animals[random.Next(animals.Count)];
            string hintShown = secretWord.Substring(0, 1).ToUpper();

            int score = 0;
            int guessesLeft = 5;
            bool guessedCorrectly = false;

            while (guessesLeft > 0 && !guessedCorrectly)
            {
                Console.WriteLine($"\nYou have {guessesLeft} guesses left.");
                Console.Write("Enter your guess: ");
                string guess = Console.ReadLine().ToLower();

                if (guess == secretWord)
                {
                    score += 10;
                    guessedCorrectly = true;
                    Console.WriteLine($"\n🎉 Correct! The secret word was '{secretWord}'.");
                    Console.WriteLine($"Your score: {score}");
                }
                else
                {
                    score = Math.Max(0, score - 1); // Ensure score doesn't go below 0
                    guessesLeft--;

                    if (guessesLeft > 0)
                    {
                        Console.WriteLine("❌ Wrong guess!");
                        Console.WriteLine($"💡 Hint: The word starts with '{hintShown}'");
                    }
                }
            }

            if (!guessedCorrectly)
            {
                Console.WriteLine($"\n😢 Game over! The secret word was '{secretWord}'.");
                Console.WriteLine($"Your final score: {score}");
            }

            // Add score to leaderboard
            leaderboard.Add(score);
            leaderboard.Sort((a, b) => b.CompareTo(a)); // Sort descending
            if (leaderboard.Count > 5) leaderboard.RemoveAt(5); // Keep top 5

            // Display leaderboard
            Console.WriteLine("\n🏆 Leaderboard:");
            for (int i = 0; i < Math.Min(leaderboard.Count, 5); i++)
            {
                Console.WriteLine($"{i + 1}. {leaderboard[i]} points");
            }

            // Ask to play again
            Console.Write("\nPlay again? (y/n): ");
            string playChoice = Console.ReadLine().ToLower();
            playAgain = (playChoice == "y" || playChoice == "yes");
        }

        Console.WriteLine("\nThanks for playing! Goodbye! 👋");
    }
}