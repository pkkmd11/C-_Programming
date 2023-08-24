using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm
{
    class Program
    {
        static void Main(string[] args)
        {
            int balance = 1000; // Initial balance
            int[] deposit = new int[100]; // Array to store deposit amounts
            int[] withdraw = new int[100]; // Array to store withdraw amounts
            int depositCount = 0; // Counter for deposit transactions
            int withdrawCount = 0; // Counter for withdraw transactions
            start:
            while (true)
            {
                Console.WriteLine("Welcome. Choose your process!");
                Console.WriteLine("1. 'D' for deposit");
                Console.WriteLine("2. 'W' for withdraw");
                Console.WriteLine("3. 'E' for exit");

                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'D' || choice == 'd')
                {
                    while (true)
                    {
                        Console.Write("Enter the amount for cash deposit: ");
                        int depositAmount = int.Parse(Console.ReadLine()); 

                        balance += depositAmount;
                        deposit[depositCount] = depositAmount;
                        depositCount++;

                        Console.WriteLine("Enter "+depositAmount+"$ ,Deposit successful!");
                        while (true)
                        {
                            Console.Write("Do you want to make another deposit? (Y/N): ");
                            char depositChoice = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            if (depositChoice == 'Y' || depositChoice == 'y')
                                continue;
                            else if (depositChoice == 'N' || depositChoice == 'n')
                            {
                                goto start;
                            }
                            else
                            {
                                Console.Write("Your Choice is Invild option try again!\n");
                                continue;
                            }
                        }
                    }
                }

                else if (choice == 'W' || choice == 'w')
                {
                    while (true)
                    {
                        
                        Console.Write("Enter the amount for cash withdraw: ");
                        int withdrawAmount = int.Parse(Console.ReadLine());

                        if (withdrawAmount <= balance)
                        {
                            balance -= withdrawAmount;
                            withdraw[withdrawCount] = withdrawAmount;
                            withdrawCount++;

                            Console.WriteLine("Withdrawal successful!");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance for withdrawal.");
                        }

                        while (true)
                        {
                            Console.Write("Do you want to make another withdrawal? (Y/N): ");
                            char withdrawChoice = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            if (withdrawChoice == 'Y' || withdrawChoice == 'y')
                                break;
                            else if (withdrawChoice == 'N' || withdrawChoice == 'n')
                            {
                                goto start;
                            }
                            else
                            {
                                Console.Write("Your Choice is Invild option try again!\n");
                                continue;
                            }
                        }
                    }
                }
                else if (choice == 'E' || choice == 'e')
                {
                    int totalDeposit = 0;
                    foreach (int amount in deposit)
                    {
                        totalDeposit += amount;
                    }

                    int totalWithdraw = 0;
                    foreach (int amount in withdraw)
                    {
                        totalWithdraw += amount;
                    }

                    Console.WriteLine("Total balance: " + balance+"$");
                    Console.WriteLine("Total deposit amount: " + totalDeposit+"$");
                    Console.WriteLine("Total withdraw amount: " + totalWithdraw+"$");
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                }
            }
            Console.ReadKey();
        }
    }
}
