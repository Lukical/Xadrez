namespace Xadrez.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
        public BoardGame Board { get; protected set; }
        public Piece(Position position, Color color, BoardGame board)
        {
            Position = position;
            Color = color;
            Board = board;
            Movements = 0;
        }
    }
}
