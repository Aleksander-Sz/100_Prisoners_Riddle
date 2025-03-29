// 100_Prisoners_Riddle.cpp : Ten plik zawiera funkcję „main”. W nim rozpoczyna się i kończy wykonywanie programu.
//

#include <iostream>
#include <string>
#include <vector>
#include <chrono>
#include <thread>

class BoxRoom
{
public:
    const int Count = 100;
    std::vector<int> Boxes;
private:
    std::vector<bool> alreadyUsed;
public:
    BoxRoom()
    {
        for (int i = 0; i < Count; i++)
        {
            alreadyUsed.push_back(false);
            Boxes.push_back(0);
        }
    }
    void Randomize()
    {
        int temp;
        srand(time(NULL));
        for (int i = 0; i < Count; i++)
        {
            alreadyUsed[i] = false;
        }
        for (int i = 0; i < Count; i++)
        {
            temp = rand() % Count;
            while (alreadyUsed[temp])
            {
                temp = (temp + 1) % Count;
            }
            alreadyUsed[temp] = true;
            Boxes[i] = temp;
        }
    }
    void Print()
    {
        for (int i = 0; i < Count; i++)
        {
            if (Boxes[i] < 10)
            {
                std::cout << " ";
            }
            std::cout << Boxes[i] << "    ";
            if (i % 10 == 9)
            {
                std::cout << "\n\n";
            }
        }
    }
};

int main()
{
    std::cout << "100 Prisoners Riddle\n\nInput the number of tries: ";
    std::string numberString;
    std::cin >> numberString;
    int testCount = std::stoi(numberString);
    BoxRoom boxRoom;
    int successCount = 0;
    int successCountInOneTest;
    int current;
    for (int i = 0; i < testCount; i++)
    {
        //one test succes or fail
        boxRoom.Randomize();
        boxRoom.Print();
        std::this_thread::sleep_for(std::chrono::milliseconds(500));
        successCountInOneTest = 0;
        for (int playerId = 0; playerId < boxRoom.Count / 2; playerId++)
        {
            current = playerId;
            for (int j = 0; j < boxRoom.Count / 2; j++)
            {
                current = boxRoom.Boxes[current];
                if (current == playerId)
                {
                    successCountInOneTest++;
                    break;
                }
            }
        }
        if (successCountInOneTest == boxRoom.Count)
        {
            successCount++;
        }
        std::cout << "Escape attempt no " << i << ", " << successCountInOneTest << " prisoners were sucessful\n";
    }
    double probability = (double)successCount / (double)testCount;
    std::cout << "Probability of escaping the prison: " << probability << "\n";
}
