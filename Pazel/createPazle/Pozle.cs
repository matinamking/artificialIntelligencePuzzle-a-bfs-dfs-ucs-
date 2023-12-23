using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazel.createPazle
{
    class Pazle
    {
        protected bool equalArray(int[,] arr1, int[,] arr2)
        {
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (arr1[i, j] != arr2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public void freList(List<Button> t, Panel b)
        {
            foreach (Button button in b.Controls)
            {
                t.Add(button);
            }
        }
        public void frePazleControler(List<Button> t, Array arr)
        {
            int counter = 0;
            foreach (var num in arr)
            {
                int i = t.FindIndex(x => x.TabIndex == counter);
                counter++;
                t[i].Text = num.ToString();
            }
        }
        public void frePazleControlerColor(List<Button> t, Array arr)
        {
            int counter = 0;
            foreach (var num in arr)
            {
                int i = t.FindIndex(x => x.TabIndex == counter);
                counter++;
                t[i].Text = num.ToString();
                t[i].BackColor = Color.Green;
            }
        }
        public void locationZero(int[,] arr, int[] location)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        location[0] = i;
                        location[1] = j;
                        break;
                    }
                }
            }
        }
    }
}
