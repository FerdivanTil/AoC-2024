﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslogic.Locations
{
    public class Grid<T>
    {
        public List<List<T>> Lines { get; set; }

        public int SizeX { get; private set; }
        public int SizeY { get; private set; }

        public List<(int x, int y)> All { get; private set; }

        public Grid()
            {}
        public void Init(int sizeX, int sizeY, T value)
        {
            var init = Enumerable.Range(0, sizeY).Select(__ => Enumerable.Range(0, sizeX).Select(_ => value).ToList()).ToList();
            Parse(init);
        }

        public void Parse(List<List<T>> input)
        {
            Lines = input;
            SizeX = Lines[0].Count;
            SizeY = Lines.Count;
            All = Enumerable.Range(0, SizeY).SelectMany(y => Enumerable.Range(0, SizeX).Select(x => (x, y))).ToList();
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

        public List<(int x,int y)> GetCoordinatesFiltered(Func<T,bool> filter)
        {
            return All.Where(i => filter(Lines[i.y][i.x])).ToList();
        }

        public List<CoordinateValue<T>> GetAdjoiningAll(int x, int y)
        {
            return new[] { GetCoordinateValue(x, y - 1), // Top
                           GetCoordinateValue(x + 1, y - 1), // Top Right
                           GetCoordinateValue(x + 1, y), // Right
                           GetCoordinateValue(x + 1, y + 1), // Bottom Right
                           GetCoordinateValue(x, y + 1),  // Bottom
                           GetCoordinateValue(x - 1, y + 1), // Bottom Left
                           GetCoordinateValue(x - 1, y), // Left
                           GetCoordinateValue(x - 1, y - 1), // Top Left
                         }.Where(i => i != null).ToList();
        }

        public List<CoordinateValue<T>> GetAdjoiningCross(int x, int y)
        {
            return new[] { GetCoordinateValue(x, y - 1), // Top
                           GetCoordinateValue(x + 1, y), // Right
                           GetCoordinateValue(x, y + 1),  // Bottom
                           GetCoordinateValue(x - 1, y), // Left
                         }.Where(i => i != null).ToList();
        }

        public List<CoordinateValue<T>> GetRow(int y)
        {
            return Enumerable.Range(0, SizeX).Select(x => GetCoordinateValue(x,y))
            .ToList();
        }

        public List<CoordinateValue<T>> GetColum(int x)
        {
            return Enumerable.Range(0, SizeY).Select(y => GetCoordinateValue(x, y))
            .ToList();
        }
        public CoordinateValue<T> GetCoordinateValue(int x, int y)
        {
            if (!Exists(x, y))
                return null;
            return new CoordinateValue<T>(x, y, Lines[y][x]);
        }
    }
}
