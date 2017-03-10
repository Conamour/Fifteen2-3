using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fifteen
{
    class Game
    {
        public int[,] Field;
        private int zeroX;
        private int zeroY;

        public Dictionary<int, ValueCoordinates> Dictionary = new Dictionary<int, ValueCoordinates>();

        public Game(params int[] values)
        {
            bool zero = false;
            int count = 0;

            int side = (int)Math.Sqrt(values.Length);

            if (values.Length != Math.Pow(side, 2))
            {
                throw new ArgumentException("Нельзя создать поле");
            }

            if (!CheckUniqueValues(values))
            {
                throw new ArgumentException("Значения повторяются");
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

            if (!zero) throw new ArgumentException("Отсутствует поле с нулем");
        }

        public int this[int i, int j]
        {
            get
            {
                return Field[i, j];
            }
            set
            {
                Field[i, j] = value;
            }
        }

        private ValueCoordinates GetLocation(int value)
        {
            if ((value < Math.Pow(value, 2) - 1) && (value > 0))
            {
                return Dictionary[value];
            }
        }

        public void Shift(int value)
        {
            if (Dictionary[value] - Dictionary[0] == 1)
            {
                ValueCoordinates positionZero = Dictionary[0];
                this[Dictionary[0].X, Dictionary[0].Y] = value;
                this[Dictionary[value].X, Dictionary[value].Y] = 0;
                Dictionary[0] = Dictionary[value];
                Dictionary[value] = positionZero;
            }
            else
            {
                throw new ArgumentException("Невозможно передвинуть фишку");
            }
        }

        private bool CheckUniqueValues(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                temp = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == temp)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static Game ReadFromCSV(string file)
        {
            string[] Lines = File.ReadAllLines(file);
            int[] elem = new int[Lines.Length];

            for (int i = 0; i < Lines.Length; i++)
            {
                string s = Lines[i];
                string[] substring = s.Split(';');
                elem[i] = Convert.ToInt32(substring[i]);
            }
            return new Game(elem);
        }
    }

}
