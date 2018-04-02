using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAIApplication {


    //enum separate from the  BoardState class, but I think it makes the most sense to put it here.
    public enum PointState {
        empty,
        black,
        white,
        invalid //useful for representing neighboring points that are off the board, other possible uses that I haven't thought of.
        //a BoardState should never contain an invalid point.
    }







    /*board geometry: x and y int points, x is the column value and y is the row.
    0,0  1,0 x,0
    0,1  x,y
    0,y
        


        zero-based indexing, so a board with five columns will have columns numbered 0,1,2,3,4.
    */




    public class BoardState {

        //horizontal size is the number of columns (first dimension)
        //columns are chosen by the first number in the getPoint method

        //when you read every point as if it were a list of English text, the first point will be 1,0, then 2,0, then on next line, 0,1



        //choices of a single point are made by two integers, first giving the column, then row. x, y.  x is horizontal, number of column. y is vertical, number of row

        //should all be zero-indexed including on display.





        //const int HorizSize = 5;
        //const int VertSize = 5;

        //use the BoardSize class instead


        //the boardsize and the board will both never be null for an initialized BoardState object.
        //aw jeez, I think I should restrict the Boards to being only squares. I need to be able to iterate
        //over every point on the board, and I don't really know the details of doing that for an interface... There might be a way but it's too much of a hassle.
        const int size = 5;
        readonly SquareBoardShape boardshape = new SquareBoardShape(size); //make the BoardShape for this BoardState a square, no other options.

        private PointState[,] board;


        //unicode for 
        //greek cross: 1f7a1, 128929
        //black large circle: 2b24, 11044
        //white medium circle: 1f785, 128901
        //nah, console can't reliably print Unicode, just use ASCII with foreground color changing.





            //Two methods to help with writing the board to console.
        public string getChar(PointState x) {
            switch(x) {
                case PointState.invalid: return " ";
                case PointState.empty: return "+";
                case PointState.black: return "O";
                case PointState.white: return "o";
                default: return "unexpected error when finding char for a PointState";
            }
        }
        public ConsoleColor getColor(PointState x) {
            switch(x) {
                case PointState.empty: return ConsoleColor.Gray;
                case PointState.invalid: return ConsoleColor.Red;
                case PointState.black: return ConsoleColor.Black;
                case PointState.white: return ConsoleColor.White;
                default: return ConsoleColor.Red;
            }
        }





        public PointState getPoint(int x, int y) {
            //if (board == null) return PointState.empty;
            //if (x < 0 || y < 0 || x >= board.GetLength(0) || y >= board.GetLength(1)) return PointState.empty;
            if (!boardshape.isOnBoard(x, y)) return PointState.invalid;
            return board[x, y];
        }
        public PointState getPoint(GoPoint a) {
            return getPoint(a.X, a.Y);
        }

        //create an empty BoardState
        public BoardState() {
            board = new PointState[size,size];
            int i, j;
            for(i=0; i<size; i++) {
            for(j=0; j<size; j++) {
                board[i, j] = PointState.empty;
            }
            }
        }

        //create a deep copy BoardState
        public BoardState(BoardState original) {
            board = new PointState[size, size];
            int i, j;
            for (i = 0; i < size; i++) {
            for (j = 0; j < size; j++) {
                board[i, j] = original.getPoint(i,j);
            }
            }
        }

        //returns not equal if the sizes are different, even if the pattern of stones is the same.
        public static bool checkForSameBoardState(BoardState left, BoardState right) {
            if (!left.boardshape.isEqual(right.boardshape)) return false;

            int i, j;
            for(i=0; i<left.boardshape.getWidth(); i++) {
            for(j=0; j<left.boardshape.getHeight(); j++) {
                if (left.getPoint(i, j) != right.getPoint(i, j)) return false;
            }
            }
            return true;
        }

        public int getSize() {
            //if (board != null) { return board.GetLength(0); } else return size;
            return size;
        }

        public void changePoint(int x, int y, PointState finalState) {
            if (!boardshape.isOnBoard(x, y)) throw new Exception("Tried to add a point to a BoardState that was not contained in the boardshape.");
            //if (board == null) return;
            if (finalState == PointState.invalid) throw new Exception("Tried to add a PointState.invalid to a BoardState.");
            unsafeChangePoint(x, y, finalState);
        }
        public void unsafeChangePoint(int x, int y, PointState finalState) {
            board[x, y] = finalState;
        }

        //returns true if the addition was successful
        public bool addStone(int x,  int y, bool isBlack) {
            if (!boardshape.isOnBoard(x, y)) return false;
            //if (board == null) return false;
            if (board[x, y] != PointState.empty) return false;

            if (isBlack) unsafeChangePoint(x, y, PointState.black);
            else unsafeChangePoint(x, y, PointState.white);
            return true;
        }



        //*********************************************************************************************
        //writing the board to Console

        //doesn't change the background color, leaves the foreground color white after writing the character.
        public void writeStone(PointState p) {
            Console.ForegroundColor = getColor(p);
            Console.Write(getChar(p));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void writeBoard() {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string spacer = " ";
            Console.WriteLine(" " + spacer + "0" + spacer + "1" + spacer + "2" + spacer + "3" + spacer + "4");
            int i, j;

            //loop down the rows, the first dimension which varies slower.
            for(j=0; j<board.GetLength(0); j++ ) {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write((j).ToString() + spacer);

                Console.BackgroundColor = ConsoleColor.DarkYellow;

                //loop down the places on a single row
                for(i=0; i<board.GetLength(1); i++) {

                    writeStone(getPoint(i,j));
                    Console.Write(spacer);

                }
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }//end method writeBoard


    }//end class SimpleBoardState










}
