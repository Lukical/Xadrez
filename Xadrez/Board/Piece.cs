namespace Xadrez.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
        public BoardGame Board { get; protected set; }
        public Piece(BoardGame board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            Movements = 0;
        }
        public void IncrementMovements()
        {
            Movements++;
        }
        public bool ExistsPossibleMoviments()
        {
            bool[,] mat = PossibleMoviments();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMoveto(Position pos)
        {
            return PossibleMoviments()[pos.Line, pos.Column];
        }
        public abstract bool[,] PossibleMoviments();
    }
}
