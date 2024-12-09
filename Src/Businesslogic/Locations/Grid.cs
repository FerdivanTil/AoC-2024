using Businesslogic.Attributes;
using Businesslogic.Enums;

namespace Businesslogic.Locations
{
    public class Grid<T>
    {
        public List<List<T>> Lines { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }

        public List<Coordinate> All { get; private set; }

        public Grid(int sizeX, int sizeY, T value)
        {
            var init = Enumerable.Range(0, sizeY).Select(__ => Enumerable.Range(0, sizeX).Select(_ => value).ToList()).ToList();
            Parse(init);
        }

        public Grid(List<List<T>> input)
        {
            Parse(input);
        }

        protected void Parse(List<List<T>> input)
        {
            Lines = input;
            SizeX = Lines[0].Count;
            SizeY = Lines.Count;
            All = Enumerable.Range(0, SizeY).SelectMany(y => Enumerable.Range(0, SizeX).Select(x => new Coordinate(x, y))).ToList();
        }

        public bool Exists(int x, int y)
        {
            if (x < 0 || y < 0)
                return false;
            if (x > SizeX - 1 || y > SizeY - 1)
                return false;
            return true;
        }

        public void UpdateValue(int x, int y, T value)
        {
            Lines[y][x] = value;
        }

        public void UpdateValue(int x, int y, Func<T,T> update)
        {
            Lines[y][x] = update(Lines[y][x]);
        }

        public T GetValue(int x, int y)
        {
            return Lines[y][x];
        }

        public List<Coordinate> GetCoordinatesFiltered(Func<T,bool> filter)
        {
            return All.Where(i => filter(Lines[i.Y][i.X])).ToList();
        }

        public List<CoordinateValue<T>> GetDirections(int x, int y, Direction direction)
        {
            var attributes = direction.GetFlags().Select(i => i.GetAttribute<DirectionAttribute>()).Where(i => i != null).ToList();
            return attributes.ConvertAll(i => GetCoordinateValue(x + i.X, y + i.Y)).Where(i => i != null).ToList();
        }

        public List<CoordinateValue<T>> GetRow(int y)
        {
            return Enumerable.Range(0, SizeX)
                .Select(x => GetCoordinateValue(x,y))
                .ToList();
        }

        public List<CoordinateValue<T>> GetColum(int x)
        {
            return Enumerable.Range(0, SizeY)
                .Select(y => GetCoordinateValue(x, y))
                .ToList();
        }

        public CoordinateValue<T> GetCoordinateValue(int x, int y)
        {
            if (!Exists(x, y))
            {
                return null;
            }
            return new CoordinateValue<T>(x, y, Lines[y][x]);
        }

        public void ToConsole()
        {
            var table = new Table();
            foreach (var line in Lines)
            {
                table.AddRow(line.Select(i => i.ToString()).ToArray());
            }

            AnsiConsole.Write(table);
        }
    }
}
