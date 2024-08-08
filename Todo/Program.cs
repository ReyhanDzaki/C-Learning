using System.Runtime.CompilerServices;
//Global Data
List<string> todoS = new List<string>
{
    "Run away from programming",
    "Become one with the sword",
    "time is void"
};


Console.Write("--Welcome To the Todo App--");
PrintInterface();
Console.ReadKey();

void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine($"Selected option: {selectedOption}");
}

void PrintInterface()
{
    bool condition;
    do
    {
        Console.WriteLine();
        Console.WriteLine("Hello!");
        Console.WriteLine("[S]ee all TODOs!");
        Console.WriteLine("[A]dd a TODO");
        Console.WriteLine("[R]emove a TODO");
        Console.WriteLine("[E]xit");

        string userChoice = Console.ReadLine();
        if (userChoice.ToLower() == "s")
        {
            PrintSelectedOption("See all todos");
            SeeAllTodo();
            PrintInterface();
            condition = true;
        }
        else if (userChoice.ToLower() == "a")
        {
            PrintSelectedOption("Add a todo");
            AddTodo();
            condition = true;
        }
        else if (userChoice.ToLower() == "r")
        {
            PrintSelectedOption("Remove a todo");
            DeleteTodo();
            condition = true;
        }
        else if (userChoice.ToLower() == "e")
        {
            PrintSelectedOption("Exit");
            condition = true;
        }
        else
        {
            condition = false;
            Console.WriteLine("Incorrect input");
        }
    } while (!condition);
}



void SeeAllTodo()
{
    for (int i = 0; i < todoS.Count; i++)
    {
        Console.WriteLine($"{i+1}. {todoS[i]}");
    }
    
}

void AddTodo()
{
    Console.WriteLine("Enter your todo: ");
    string userTodo = Console.ReadLine();
    if (todoS.Contains(userTodo))
    {
        Console.WriteLine("You already have that todo in your list");
        AddTodo();
    }
    else if (userTodo == string.Empty)
    {
        Console.WriteLine("Your todo cant be empty");
        AddTodo();
    }
    else
    {
        todoS.Add(userTodo);
        Console.WriteLine($"Todo Succsesfully added {userTodo}");
        PrintInterface();
    }
}

void DeleteTodo()
{
    if (todoS.Count==0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        PrintInterface();
    }
    bool isParsingSuccesful;
    int number;
    do
    {
        Console.WriteLine("== Delete Todo (Pick the Id) ==");
        SeeAllTodo();
        var userInput = Console.ReadLine();
        isParsingSuccesful = int.TryParse(userInput, out number);
         if (userInput == string.Empty)
        {
            Console.WriteLine("Selected index cannot be empty.");
            DeleteTodo();
        }
        else if(number <= 0 || number > todoS.Count)
        {
            Console.WriteLine("Index is not Valid");
            DeleteTodo();
        }
    } while (!isParsingSuccesful);
    
        Console.WriteLine($"Todo Removed {todoS[number-1]}");
        todoS.RemoveAt(number-1);
        PrintInterface();
}

Console.ReadKey();