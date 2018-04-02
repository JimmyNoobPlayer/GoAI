using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAIApplication {


    //wait a second isnt' this PointSet? I'm stupid I need to rethink things. Okay I think using PointSet should be a deprecated practice.

    //the chain is created with a specific seed point, which sets the color of the chain. Different points on the Board can be compared to the Chain, then the Chain will take them if 
    //this is not an abstract collection of points, it only represents a contiguous collection of matching stones on a specific BoardState.
    //There could possibly be matching connecting stones onthe BoardState that are not contained int this Chain, since the Chain may be in an intermediate state.
    //Only when the entire Board is examined can we be sure the Chain is complete, but since that is done by the UsableGoBoard class, this Chain class has no way to determine if the Chain is complete.



     
    //I think I should take a break. I think ChainCollection should be used and Chain made a private class.
    public class ChainCollection 


    public class Chain {

        public bool isBlack { get; }
        public int numLiberties { get; }

        private BoardState theBoard; // a reference to the actual board with the stones
        private List<GoPoint> theList;

        //the Seedpoint should be known to be an actual Black or White stone, will throw an Exception if the seedpoint is PointState.empty or invalid.
        public Chain(GoPoint seedpoint, BoardState board) {
            theBoard = board;
            PointState seedState = board.getPoint(seedpoint);
            if (seedState == PointState.empty || seedState == PointState.invalid) throw new Exception("Tried to create a Chain with an empty or invalid seedpoint.");

            isBlack = (seedState == PointState.black);

            theList = new List<GoPoint>();
            theList.Add(new GoPoint(seedpoint));
        }

        //I think this is the only way to add GoPoints to the Chain, it must check every time. This is a waste of time but I think it's necessary to prevent adding Points that aren't actually on the Chain.
        public bool addIfTouching(GoPoint x) {

        }

        public bool isContained(GoPoint x) {

        }

        private unsafeAdd
    }
}
