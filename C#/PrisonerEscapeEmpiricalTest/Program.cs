// See https://aka.ms/new-console-template for more information
using PrisonerEscapeEmpiricalTest;
int testCount;
Console.Write("100 Prisoners Riddle\n\nInput the number of tries: ");
String? numberString = Console.ReadLine();
try
{
    testCount = Int32.Parse(numberString);
}
catch
{
    Console.WriteLine("The value needs to be a number.\n");
    return;
}
if(testCount<1)
{
    Console.WriteLine("The value needs to be a number above 0.\n");
    return;
}
BoxRoom room = new BoxRoom();
SingleTest singleTest = new SingleTest(room);
int successCount = 0;
int test;
int loadInterval = Math.Max(testCount / 75, 1);
Console.SetCursorPosition(0, 4);
Console.Write("[                                                                            ]");
for(int i = 0; i < testCount; i++)
{
    room.Randomize();
    //Console.Clear();
    //Console.SetCursorPosition(0, 0);
    //Console.Write(room.BoxesToString());
    if (BoxRoom.Count==(test = singleTest.Run()))
    {
        successCount++;
    }
    //Console.Write("\n\nResult: " + test.ToString());
    //Thread.Sleep(500);
    if (i % loadInterval == 0)
    {
        Console.SetCursorPosition(i / loadInterval + 1, 4);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        if (i == 0)
            continue;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(i / loadInterval, 4);
        Console.Write("*");
    }
}
Console.ForegroundColor = ConsoleColor.White;
double probability = (double)successCount / (double)testCount;
//Console.Clear();
Console.SetCursorPosition(0, 6);
Console.Write("Probability of escaping the prison: " + probability.ToString() + "\n");