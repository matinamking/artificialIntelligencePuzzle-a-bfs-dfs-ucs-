using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pazel.shofle;

namespace Pazel.createPazle
{
    class Start : Pazle
    {
        public void start(int[,] pazle1,int[,] pazle2, List<Button> buttonsPazel2, Panel AgentMatrix, int[] location2)
        {
            //Random rand = new Random();
            //Shofle.Shuffle(rand, pazle2);
            freList(buttonsPazel2, AgentMatrix);
            frePazleControler(buttonsPazel2, pazle2);
            locationZero(pazle2,location2);
            if (equalArray(pazle1, pazle2))
            {
                MessageBox.Show("You Win");
            }
        }
    }
}
