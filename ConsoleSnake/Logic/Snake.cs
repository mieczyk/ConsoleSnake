using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleSnake.Logic
{
    public class Snake
    {
        private List<Point> _segments;
        private Direction _currentDirection;

        public IReadOnlyCollection<Point> Segments
        {
            get { return _segments.AsReadOnly(); }
        }

        public Direction CurrentDirection 
        {
            get { return _currentDirection; } 
            set
            {
                if (CanChangeDirection(value))
                    _currentDirection = value;
            }
        }

        public Snake(int initialLength, Point head)
        {
            _currentDirection = Direction.Right;

            _segments = new List<Point>(initialLength);
            
            for(int i = 0; i < initialLength; i++)
            {
                Point segment = new Point { X = head.X - i, Y = head.Y };

                _segments.Add(segment);
            }
        }

        public void Move()
        {
            Tuple<int, int> vector = GetMoveVector();

            Point[] currentPositions = _segments.ToArray();

            Point head = _segments[0];
            _segments[0] = new Point(head.X + vector.Item1, head.Y + vector.Item2);

            for(int i = 1; i < _segments.Count; i++)
            {
                _segments[i] = currentPositions[i - 1];
            }
        }

        public void AddSegment()
        {
            Point last = _segments.Last();
            Point penultimate = _segments[_segments.Count - 2];

            if (penultimate.X == last.X + 1)
                _segments.Add(new Point(last.X - 1, last.Y));
            else if(penultimate.X == last.X - 1)
                _segments.Add(new Point(last.X + 1, last.Y));
            else if(penultimate.Y == last.Y + 1)
                _segments.Add(new Point(last.X, last.Y - 1));
            else if (penultimate.Y == last.Y - 1)
                _segments.Add(new Point(last.X, last.Y + 1));
        }

        private Tuple<int, int> GetMoveVector()
        {
            int dx = 0;
            int dy = 0;

            switch (_currentDirection)
            {
                case Direction.Up: dy = -1; break;
                case Direction.Right: dx = 1; break;
                case Direction.Down: dy = 1; break;
                case Direction.Left: dx = -1; break;
            }

            return new Tuple<int, int>(dx, dy);
        }

        public bool IsSelfCollision()
        {
            return _segments.Where(s => s == _segments[0]).Count() > 1;
        }

        private bool CanChangeDirection(Direction direction)
        {
            bool result = true;

            if(_currentDirection == Direction.Up && direction == Direction.Down 
                || _currentDirection == Direction.Right && direction == Direction.Left
                || _currentDirection == Direction.Down && direction == Direction.Up
                || _currentDirection == Direction.Left && direction == Direction.Right)
            {
                result = false;
            }

            return result;
        }
    }
}
