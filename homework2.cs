using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomework2
{
    class Program
    {
        static void Main(string[] args)
        {
            //create first option variable to be used in do/while loop
            string option1;

            //create list of customers, to be accessable throughout all of main
            List < Customer > bankCustomers = new List<Customer>();
            do
            {
                //beginning of interface, ask for options
                Console.WriteLine("1. Create Account (1)\n" + "2. View Account (2)\n" + "3. Delete Account (3)\n" + "4. Quit (4)");
                option1 = Console.ReadLine();



                //option 1 from main menu, create new account and add it to the list of customers
                if (option1 == "1")
                {
                    Customer newCus = createNewAccount();
                    bankCustomers.Add(newCus);
                }
                //option 2 from main menu, get customer information to display and update if necessary
                else if (option1 == "2")
                {
                    Console.Write("Enter Name: ");

                    //get customer info and display it
                    string customerName = Console.ReadLine().ToUpper();

                    var customerInfo = from customer in bankCustomers
                                       where customer.accountName == customerName
                                       select customer;

                    foreach (var customer in customerInfo)
                    {
                        Console.WriteLine("Name: {0} \n Account Number: {1} \n Account Balance: {2}",
            customer.accountName, customer.accountID, customer.balance);
                    }

                    
                        //ask to update account
                        Console.WriteLine("Update Account As Follows: \n 1. Deposit (1) \n 2. WithDraw (2) \n 3. Back to Main Menu (3)");
                    string option2 = Console.ReadLine();
                    var customerMoneyInfoAsVar = from customer in bankCustomers
                                                 where customer.accountName == customerName
                                                 select customer.accountID;
                
                    //deposit funds
                    if (option2 == "1")
                    {
                        Console.Write("Enter amount to deposit: ");
                        string depositString = Console.ReadLine();
                        decimal depositNum;
                        bool depositSuccess = decimal.TryParse(depositString, out depositNum);
                        if(depositSuccess == true)
                        {
                            var obj = bankCustomers.FirstOrDefault(x => x.accountName == customerName);
                            if (obj != null) obj.balance = obj.balance + depositNum;
                        }
                    }
                    //withdraw funds
                    else if (option2 == "2")
                    {
                        Console.Write("Enter amount to Withdrawal: ");
                        string withdrawalString = Console.ReadLine();
                        decimal withdrawalNum;
                        bool withdrawalSuccess = decimal.TryParse(withdrawalString, out withdrawalNum);
                        if (withdrawalSuccess == true)
                        {
                            var obj = bankCustomers.FirstOrDefault(x => x.accountName == customerName);
                            if (obj != null) obj.balance = obj.balance - withdrawalNum;
                            //customerMoneyInfo += depositNum ;
                        }
                    }
                    else if (option2 == "3")
                    {
                        
                    }else
                    {
                        Console.WriteLine("Invalid Input!");
                    }

                }
            //delete account
            else if(option1 == "3")
            {
                    Console.Write("Enter Account Name To Be Deleted: ");
                    string accountNameDeleted = Console.ReadLine().ToUpper() ;
                    var obj = bankCustomers.FirstOrDefault(x => x.accountName == accountNameDeleted);
                    if(obj != null)
                    {
                        bankCustomers.Remove(obj);
                    }
                    else
                    {
                        Console.WriteLine("Account Does Not Exist!");
                    }

                }
            else if (option1 == "4")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Please enter valid option");
                }
            } while ((option1 != ("4")));

        }

        static public Customer createNewAccount()
        {
            string newAccountType;
            Console.Write("Account Type: Checking (C) or Saving(S) ? ");
            newAccountType = Console.ReadLine().ToUpper();

            //get name and account details
            Console.Write("Enter Name: ");
            Customer customerName = new Customer();
            customerName.accountName = Console.ReadLine().ToUpper();
            Random newrand = new Random();
            customerName.accountID = newrand.Next(10000, 20000);

            //get starting balance
            decimal accountBalanceNum;
            Console.Write("Enter Starting Account Balance: ");
            string accountBalanceString = Console.ReadLine();
            bool balanceWasEntered = decimal.TryParse(accountBalanceString, out accountBalanceNum);

            if (newAccountType == "S")
            {
                accountBalanceNum *= 1.015m;
            }
            customerName.balance = accountBalanceNum;
            return customerName;
        }

        static public void viewAccountInfo()
        {
            
        }
    }



    public class Customer 
    {
        public string accountName { set; get; }
        public int accountID { set; get; }
        public decimal balance { set; get; }

        public class account
        {
            public decimal accountBalance { set; get; }
        }

        public bool Equals(Customer other)
        {
            if (other == null) return false;
            return (this.accountName.Equals(other.accountName));
        }
    }
}
