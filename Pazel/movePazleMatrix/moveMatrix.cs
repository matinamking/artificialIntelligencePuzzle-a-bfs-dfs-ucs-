using Pazel.createPazle;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pazel.movePazleMatrix
{
    class moveMatrix : Pazle
    {
        public void btnUp(int[] location,int[,] pazle, List<Button> buttonsPazel)
        {
            int i = location[0];
            int j = location[1];
            int l = 0;
            if (i > 0)
            {
                pazle[i, j] = pazle[i - 1, j];
                pazle[i - 1, j] = l;
                location[0] = i - 1;
                frePazleControler(buttonsPazel, pazle);
            }
        }
        public void btnDown(int[] location, int[,] pazle, List<Button> buttonsPazel)
        {
            int i = location[0];
            int j = location[1];
            int l = 0;
            if (i < 2)
            {
                pazle[i, j] = pazle[i + 1, j];
                pazle[i + 1, j] = l;
                location[0] = i + 1;
                frePazleControler(buttonsPazel, pazle);
            }
        }
        public void btnRight(int[] location, int[,] pazle, List<Button> buttonsPazel)
        {
            int i = location[0];
            int j = location[1];
            int l = 0;
            if (j < 2)
            {
                pazle[i, j] = pazle[i, j + 1];
                pazle[i, j + 1] = l;
                location[1] = j + 1;
                frePazleControler(buttonsPazel, pazle);
            }
        }
        public void btnLeft(int[] location, int[,] pazle, List<Button> buttonsPazel)
        {
            int i = location[0];
            int j = location[1];
            int l = 0;
            if (j > 0)
            {
                pazle[i, j] = pazle[i, j - 1];
                pazle[i, j - 1] = l;
                location[1] = j - 1;
                frePazleControler(buttonsPazel, pazle);
            }
        }
        public bool result(int[,] pazle1, int[,] pazle2,int counter, int endCount)
        {
            if (endCount < counter)
            {
                MessageBox.Show("You Lose");
                return true;
            }
            else if (equalArray(pazle1, pazle2))
            {
                MessageBox.Show("You Win");
                return true;
            }
            return false;
        }
    }
}
