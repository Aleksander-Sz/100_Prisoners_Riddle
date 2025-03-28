using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerEscapeEmpiricalTest
{
    internal class SingleTest
    {
        BoxRoom room;
        public SingleTest(BoxRoom _room)
        {
            room = _room;
        }
        public int Run()
        {
            int current;
            int success = 0;
            for (int playerNo = 0; playerNo < BoxRoom.Count; playerNo++)
            {
                current = playerNo;
                for(int j = 0; j <= BoxRoom.Count / 2; j++)
                {
                    current = room.Boxes[current];
                    if(current == playerNo)
                    {
                        //Console.WriteLine("Player Number: " + playerNo.ToString() + ", j: " + j.ToString());
                        success++;
                        break;
                    }
                }
            }
            return success;
        }
    }
}
