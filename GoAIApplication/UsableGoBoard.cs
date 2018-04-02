using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAIApplication {

    //this board only stores the stones (I mean it stores no chain information or liberty information) of a BoardState. It has three methods, CheckForBlackCapture, CheckForWhiteCapture, CheckForKo.
    //It also stores past legal board states to check for Ko.
    //also the method CheckForOverlap, to check that the move is actually not on top of another stone.
    //As well as a StoneAdd method (which can return false if the move is illegal)




    //with this class, suicides will not be considered illegal.
    //Illegal moves:
    //off the board completely
    //over another stone
    //BASIC LEGALITY

        //process for adding a stone:
        //check for basic legality, reject if fails.
        //check for enemy captures
        //check for friendly captures (suicides)
        //check for Ko 

    public class UsableGoBoard {
        public BoardState CurrentBoard { get; }

        private List<BoardState> history;

        public UsableGoBoard() {
            history = new List<BoardState>();
            CurrentBoard = new BoardState();
            recordCurrentBoard();
        }

        //false if the CurrentBoard is illegal somehow. Returns true after the CurrentBoard is added to history.
        private bool recordCurrentBoard() {
            //verify the board is okay, if needed.
            if(CheckForBlackCapture()) return false;
            if(CheckForWhiteCapture()) return false;
            if(CheckForKo()) return false;
            history.Add(new GoAIApplication.BoardState(CurrentBoard));
            return true;
        }

        //single stone checking methods, assumes the current board is legal.

        //full board checking methods, assumes nothing about the board or previous boards.
        private bool CheckForKo() {
            foreach (BoardState b in history) {
                if (BoardState.checkForSameBoardState(b, CurrentBoard)) return false;
            }
            return true;
        }
        //iterate through every point, adding that point to a collection of Chains. If the point is Black or White, that point checks for matching stones in the four directions and adds it to a chain if a match is found.
        //if the point is empty, check the four directions for chains, adding a liberty to the chains it touches.
        private bool CheckForBlackCapture() {

        }

    }
}
