using System;
using System.Runtime.InteropServices;

class Program
{

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlayGame();
  
            int result = MessageBox(IntPtr.Zero, "Хотите сыграть еще раз?", "Повторная игра", 1);
           
            if (result == 2) 
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Спасибо за игру!");
    }

    static void PlayGame()
    {
        Console.WriteLine("Загадайте число от 0 до 100, а компьютер попытается его угадать.");
        int min = 0;
        int max = 100;
        bool isGuessed = false;

        while (!isGuessed)
        {
            int guess = (min + max) / 2;
            Console.WriteLine($"Компьютер думает, что ваше число {guess}. Это правильно?");
            Console.WriteLine("1. Да, это мое число.");
            Console.WriteLine("2. Нет, мое число больше.");
            Console.WriteLine("3. Нет, мое число меньше.");
            Console.Write("Ваш выбор: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    isGuessed = true;
                    MessageBox(IntPtr.Zero, $"Компьютер угадал! Ваше число: {guess}.", "Угадано!", 0);
                    break;
                case "2":
                    min = guess + 1;
                    break;
                case "3":
                    max = guess - 1;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }
}
