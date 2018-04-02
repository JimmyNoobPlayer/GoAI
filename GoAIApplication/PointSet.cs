using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAIApplication {





    /// <summary>
    /// right now this class is DEPRECATED. I think I should use simply Chain, or other specific uses of sets of GoPoints instead of a general use set of GoPoints.
    /// </summary>







    //simply a collection of points, two ints (GoPoint). The points should be on a Board of a certain size (BoardSize), and include no duplicates.
    //Doesn't store the color of the stone at that point. Can also be empty points.
    //the points in the set can have many properties which can be checked independently. Notably the points can be compared to a BoardState and the points in the set can correspond to points on the board (all black stones, all black territory, all neutral territory, et cetera)





//this possibly, maybe, might not be used at all.


    public class PointSet {

        public List<GoPoint> setList;

        //create an empty set
        PointSet() {
            setList = new List<GoPoint>();
        }

        //deep copy
        PointSet(PointSet original) {
            setList = new List<GoPoint>(original.setList.Count);
            foreach (GoPoint x in original.setList) {
                setList.Add(new GoAIApplication.GoPoint(x));
            }
        }

        public bool isContained(GoPoint newPoint) {
            foreach (GoPoint x in setList) {
                if (x == newPoint) return true;
            }
            return false;
        }

        /// <summary>
        /// the restrictions are that the newPoint must be on a given board and not duplicate a previous point in the set.
        /// If these restrictions are not met, nothing is added to the PointSet. Null GoPoints are not added in any way.
        /// The newPoint isn't copied first, it just gloms into the setList.
        /// </summary>
        /// <param name="newPoint"></param>
        public bool addWithRestrictions(GoPoint newPoint, BoardShape board) {
            if (newPoint == null) return false;
            if (!board.isOnBoard(newPoint)) return false;
            if (isContained(newPoint)) return false;

            setList.Add(newPoint);
            return true;
        }


        //check for no-duplicates
        public bool hasDuplicates() {
            int i, j;
            int length = setList.Count;
            for (i=0; i<length; i++) {
                for (j=i; j<length; j++) {
                    if (setList.ElementAt(i) == setList.ElementAt(j)) return true;
                }
            }
            return false;
        }

        //check for on-board
        //check for continuity
    }

    //public class CompleteChainSet {
    //    CompleteChainSet
    //}
}
