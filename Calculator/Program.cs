﻿// See https://aka.ms/new-console-template for more information

using Calculator.UserInput;

Console.WriteLine("Welcome {Environment.UserName}");
Console.WriteLine("Type 1 if you want to add two numbers");
Console.WriteLine("Type 2 if you want to subtract two numbers");
Console.WriteLine("Type 3 if you want to multiply two numbers");
Console.WriteLine("Type 4 if you want to divide two numbers");

var input = Console.ReadLine();
Func<int, int, int> func = ConsoleMask.DetermineUserOperation(input);

int valx, valy;

Console.WriteLine("Insert first number");
var x = Console.ReadLine();
Console.WriteLine("Insert second number");
var y = Console.ReadLine();


ConsoleMask.DetermineUserInput(x, y, out valx, out valy);

Console.WriteLine(func(valx, valy));

