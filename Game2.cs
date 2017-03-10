using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen_2_3
{
    class Game2 : Game
    {
        public Game2(params int[] values)
        {
            int n = values.Length;

            while (n > 1)
            {
                var rand = new Random();

                int k = rand.Next(n--);
                int temp = values[n];
                values[n] = values[k];
                values[k] = temp;
            }

            bool zero = false;
            int count = 0;

            int side = (int)Math.Sqrt(values.Length);

            if (values.Length != Math.Pow(side, 2))
            {
                throw new ArgumentException("Нельзя создать поле");
            }

            this.Field = new int[side, side];

            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    if (values[count] == 0)
                    {
                        zero = true;
                        zeroX = i;
                        zeroY = j;
                        Field[i, j] = values[count];
                        Dictionary.Add(count, new ValueCoordinates(i, j));
                        count++;
                    }
                    else
                    {
                        Field[i, j] = values[count];
                        Dictionary.Add(count, new ValueCoordinates(i, j));
                        count++;
                    }

                }
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.Contains(i))
                {
                    throw new ArgumentException("Числа неправильные");
                }
            }
        }
    }

        public bool Winner()
        {
            int count = 1;
            for (int count = 1; count < Field.Lenght; count++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (Field[i, j] == count && Field[size - 1, size - 1] == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}
