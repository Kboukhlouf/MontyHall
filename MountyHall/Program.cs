using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountyHall
{
	class Program
	{
		static void Main(string[] args)
		{
			Prize[] possibilities = new Prize[3];
			Random random = new Random();
			Int64 numberOfTimes = 0L;
			bool playAgain = false;
			char choice;
			bool swap;

			init:
			Console.Clear();
			Console.WriteLine("Chose if you want to Swap or Not Swap {S/N}");
			ConsoleKeyInfo key = Console.ReadKey();
			if(key.Key == ConsoleKey.S || key.Key == ConsoleKey.N)
			{
				swap = key.Key == ConsoleKey.S ? true : false;
			}
			else
			{
				goto init;
			}

			start:
			Console.Clear();
			Console.WriteLine("Chose how many times you want to run the experiment?");
			if(Int64.TryParse(Console.ReadLine().ToString(), out numberOfTimes))
			{
				Prize[] results = new Prize[numberOfTimes];

				for(int i=0; i< numberOfTimes; i++)
				{
					//Setting possibilities
					for (int l = 0; l < 3; l++) possibilities[l] = Prize.GOAT;
					int car = random.Next(3);
					possibilities[car] = Prize.CAR;

					//Setting user choice
					int userChoice = random.Next(3);
					int hostChosenDoor = random.Next(3);
					if (swap)
					{
						for(int j = 0; j<3; j++)
						{
							if(j != userChoice)
							{
								if (possibilities[j] == Prize.GOAT)
								{
									possibilities[j] = Prize.UNAVAILABLE;
									hostChosenDoor = j;
									break;
								}
							}
						}

						for(int k=0; k<3; k++)
						{
							if(k != userChoice && k != hostChosenDoor)
							{
								userChoice = k;
								break;
							}
						}

						results[i] = possibilities[userChoice];
					}
					else
					{
						for (int j = 0; j < 3; j++)
						{
							if (j != userChoice)
							{
								if (possibilities[j] == Prize.GOAT)
								{
									possibilities[j] = Prize.UNAVAILABLE;
									hostChosenDoor = j;
									break;
								}
							}
						}

						results[i] = possibilities[userChoice];
					}
				}

				Console.WriteLine("Your possibility of winning is : " +((double)results.Where(r => r.Equals(Prize.CAR)).LongCount() / numberOfTimes).ToString("0.00%"));
				Console.ReadKey();
			}
			else
			{
				goto start;
			}

			play_again:
			Console.WriteLine("Play again ? (Y:N)\n");

			ConsoleKeyInfo key2 = Console.ReadKey();
			if (key2.Key == ConsoleKey.Y || key2.Key == ConsoleKey.N)
			{
				playAgain = key2.Key == ConsoleKey.Y ? true : false;
			}
			else
			{
				goto play_again;
			}

			if (playAgain) goto init;
			

		}
	}
}
