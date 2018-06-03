using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDll
{
    class Coordinates
    {
        private List<int[]> _coordinates;

        public Coordinates()
        {
            var line = "";
            _coordinates = new List<int[]>();
            var sr = new StreamReader(@"Coordinates.txt");
            while ((line = sr.ReadLine()) != null)
            {
                _coordinates.Add(line.Split(' ').Select(x => int.Parse(x)).ToArray());
            }
        }

        public bool CheckForCards(int x, int y,int n)
        {
            var a = GetOnCards(n);
            if ((a[0] < x && a[1] < y) && (x < a[0] + 71 && y < a[1] + 95))
                return true;
            return false;
        }
        public bool CheckForCoordinates(int x, int y)
        {
            foreach (var e in _coordinates)
                if ((e[0] < x && e[1] < y) && (x < e[0] + 71 && y < e[1] + 95))
                    return true;
            return false;
        }

        public int[] GetOnCoordinates(int x, int y)
        {
            foreach (var e in _coordinates)
                if ((e[0] < x && e[1] < y) && (x < e[0] + 71 && y < e[1] + 95))
                    return e;
            return null;
        }

        public int[] GetOnCards(int n)
        {
            foreach (var e in _coordinates)
                if (e[2] == n)
                    return e;
            return null;
        }
        public List<int[]> GetAll()
        {
            return _coordinates;
        }
    }
}
