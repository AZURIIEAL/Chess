using ChessLogic.Movement;
using ChessLogic.Pieces;
using Player = ChessLogic.Enums.Player;

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
            get { return this[position.Row, position.Column]; }
            set { this[position.Row, position.Column] = value; }
        }
        public static Board Initial()
        {
            Board board = new();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            Type[] blackPieces = { typeof(Rook), typeof(Knight), typeof(Bishop), typeof(Queen), typeof(King), typeof(Bishop), typeof(Knight), typeof(Rook) };
            Type[] whitePieces = { typeof(Rook), typeof(Knight), typeof(Bishop), typeof(Queen), typeof(King), typeof(Bishop), typeof(Knight), typeof(Rook) };

            for (int col = 0; col < 8; col++)
            {
                this[0, col] = (Piece?)Activator.CreateInstance(blackPieces[col], Player.Black) ?? throw new InvalidOperationException("Failed to create piece.");
                this[1, col] = new Pawn(Player.Black);
            }

            for (int col = 0; col < 8; col++)
            {
                this[7, col] = (Piece?)Activator.CreateInstance(whitePieces[col], Player.White) ?? throw new InvalidOperationException("Failed to create piece."); ;
                this[6, col] = new Pawn(Player.White);
            }
        }
        public static bool IsInside(Position position)
        {
            return (position.Row >= 0 && position.Row < 8) && (position.Column >= 0 && position.Column < 8);
        }
        public bool IsEmpty(Position position)
        {
            return this[position] is null;
        }
    }
}
