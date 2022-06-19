// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var read = new ConsoleExtension.Library.ReadWrite.ReadDataFromConsole();
var test = read.ReadData();

var write = new ConsoleExtension.Library.ReadWrite.WriteDataToConsole();
write.WriteLine(test);
write.Write(test);

