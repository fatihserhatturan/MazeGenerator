using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenrator
{
    internal class singletoon
    {
        private static singletoon _instance;


        public int[] array;
        public int counterEn;
        public int counterBoy;
        public int counterBosluk;
        public dynamic[,] shortestPath;
        public dynamic[,] textboxes;
        public int i;
        public int j;
        public static singletoon GetInstance()
        {
            if (_instance == null)
            {
                _instance = new singletoon();
                _instance.array = new int[5];
                _instance.counterEn = 0;
                _instance.counterBoy = 0;
                _instance.counterBosluk = 0;
                _instance.textboxes = new dynamic[100, 100];
                _instance.shortestPath = new dynamic[_instance.counterEn, _instance.counterBoy];
                _instance.i = 3;
                _instance.j = 3;
            }
            return _instance;
        }
    }
}
