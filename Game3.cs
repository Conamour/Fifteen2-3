using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen_2_3
{
    class Game3 : Game2
    {
        private List<int> History;

        public Game3(params int[] values) : base(values)
        {
            History = new List<int>();
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            History.Add(value);
        }

        public void Rollback()
        {
            int lastMove = History.Last();
            History.Remove(lastMove);
            base.Shift(lastMove);
        }
    }
}
