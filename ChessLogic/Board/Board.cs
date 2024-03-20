using ChessLogic.Movement;
using ChessLogic.Pieces;

namespace ChessLogic.Board
{
    public class Board
    {
        private readonly Piece[,] _pieces = new Piece[8, 8];
        public Piece this[int row, int col]
        {
            get { return _pieces[row, col]; }
            set { _pieces[row, col] = value; }
        }
        public Piece this[Position position]
        {
            get { return this[position.Row,position.Column]; }
            set { this[position.Row,position.Column] = value;}
        }
    }
}
