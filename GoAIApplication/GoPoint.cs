using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAIApplication {








    //this is simply a point with no information about what stone is at the point or even which board the point is on.
    //It is assumed it's on a board, but it can also be off the edge of the board (which is common when neighboring points are checked) 
    //immutable, right?
    public struct GoPoint {
        public int X { get; }
        public int Y { get; }


        //deep copy
        public GoPoint(GoPoint original) {
            this.X = original.X;
            this.Y = original.Y;
        }

        //null doesn't equal null, and no initialized GoPoint can equal null
        //so if either operand is null, == is false and != is true;
        public static bool operator ==(GoPoint left, GoPoint right) {
            if (left == null || right == null) return false;
            return (left.X == right.X && left.Y == right.Y);
        }
        public static bool operator !=(GoPoint left, GoPoint right) {
            if (left == null || right == null) return true;
            return (left.X != right.X || left.Y != right.Y);
        }
    }
}
