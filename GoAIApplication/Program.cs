using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAIApplication {
    class Program {
        static void Main(string[] args) {

            BoardState quickBoard = new GoAIApplication.BoardState();
            quickBoard.addStone(3, 0, true); //x=3, y=0
            quickBoard.addStone(2, 2, false);

            quickBoard.addStone(10, 5, true);//off the board

            /*
             +++0+
             +++++
             ++0++
             +++++
             +++++
             */
        

            quickBoard.writeBoard();
            Console.ReadKey();

        }
    }
}
