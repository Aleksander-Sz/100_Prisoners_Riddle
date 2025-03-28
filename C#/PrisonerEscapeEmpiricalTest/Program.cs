// See https://aka.ms/new-console-template for more information
using PrisonerEscapeEmpiricalTest;
const int testCount = 1000000;
Console.WriteLine("Prisoner escape test\n\n");
BoxRoom room = new BoxRoom();
SingleTest singleTest = new SingleTest(room);
int successCount = 0;
int test;
int loadInterval = testCount / 75;
Console.SetCursorPosition(0, 5);
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
        Console.SetCursorPosition(i / loadInterval + 1, 5);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        if (i == 0)
            continue;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(i / loadInterval, 5);
        Console.Write("*");
    }
}
Console.ForegroundColor = ConsoleColor.White;
double probability = (double)successCount / (double)testCount;
//Console.Clear();
Console.SetCursorPosition(0, 10);
Console.Write("\nProbability of escaping the prison: " + probability.ToString() + "\n");