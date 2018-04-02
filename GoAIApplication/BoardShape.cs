using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAIApplication {


    /*board geometry: x and y int points, x is the column value and y is the row.
0,0  1,0 x,0
0,1  x,y
0,y



    zero-based indexing, so a board with five columns will have columns numbered 0,1,2,3,4.
*/


    //is a given point on the board? The BoardShape class mainly checks the answer to that question.
    //non-square boards are possible but of course square is the most common and probably the only practical use for a BoardSize object.
    //this represents the entire shape of the board
    public interface BoardShape {
        bool isOnBoard(int x, int y);
        bool isOnBoard(GoPoint a);

        bool isEqual(BoardShape other);

        //these values are the lowest or highest possible values for the board, so for example there is no point on the board with an x-value less than leftBorder().
        int getMaxDimension(); //this is the greatest distance between either left and right or top and bottom. (can be calculated from the Border methods below)
        int getWidth();
        int getHeight(); //return bottomBorder - topBorder + 1
        int leftBorder();
        int rightBorder();
        int topBorder();
        int bottomBorder();
    }


    public class SquareBoardShape : BoardShape {
        readonly int size;
        const int minSize = 1;

        public SquareBoardShape(int _size) {
            if (_size < minSize) size = minSize;
            else size = _size;
        }

        //uh... I guess it's logically possible for a board to be the same shape but represented as a different BoardShape class... but
        //we should ignore those cases and say for example a Board represented as a rectangle with both sides equal is not the same as a
        //Board represented by a square of the same size.

        /// <summary>
        /// Must be the same subclass, so a BoardShape that happens to have the same points
        /// will not be considered the same if it is represented differently.
        /// </summary>
        /// <param name=""></param>
        public bool isEqual(BoardShape other) {
            if (!(other is SquareBoardShape)) return false;
            return size == ((SquareBoardShape)(other)).size;
        }

        public int leftBorder() { return 0; }
        public int rightBorder() { return size - 1; }
        public int topBorder() { return 0; }
        public int bottomBorder() { return size - 1; }
        public int getMaxDimension() { return size; }
        public int getWidth() { return size; }
        public int getHeight() { return size; }

        public bool isOnBoard(int x, int y) {
            return (x >= 0 && x < size && y >= 0 && y < size);
        }
        public bool isOnBoard(GoPoint a) {
            if (a == null) return false;
            return isOnBoard(a.X, a.Y);
        }
    }
}
