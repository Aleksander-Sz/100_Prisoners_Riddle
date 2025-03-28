using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerEscapeEmpiricalTest
{
    internal class BoxRoom
    {
        public const int Count = 100;
        public List<int> Boxes;
        private List<bool> alreadyUsed;
        public BoxRoom()
        {
            Boxes = new List<int>(100);
            alreadyUsed = new List<bool>();
            for (int i = 0; i < Count; i++)
            {
                alreadyUsed.Add(false);
            }
        }
        public void Randomize()
        {
            for (int i = 0; i < Count; i++)
            {
                alreadyUsed[i] = false;
            }
            Boxes.Clear();
            int temp;
            Random gen = new Random();
            for(int i = 0;i<Count; i++)
            {
                temp = gen.Next()%100;
                while (alreadyUsed[temp])
                {
                    temp = (temp + 1) % Count;
                }
                alreadyUsed[temp] = true;
                Boxes.Add(temp);
            }
        }
        public String BoxesToString()
        {
            String text = new String("");
            for(int i = 0;i<Count;i++)
            {
                if (Boxes[i]<10)
                {
                    text += " ";
                }
                text += Boxes[i].ToString();
                if(i%10==9)
                {
                    text += "\n\n";
                }
                else
                {
                    text += "   ";
                }
            }
            return text;
        }
    }
}
