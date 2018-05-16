using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hebb
{
  /// <summary>
  /// Class of neuron
  /// Класс нейрона
  /// </summary>
    class Web
    {
        /// <summary>
        /// Отмаштабированные сигналы
        /// </summary>
        public int[,] mul;
        /// <summary>
        /// Веса
        /// </summary>
        public int[,] weight;
        /// <summary>
        /// Входная информация
        /// </summary>
        public int[,] input;
        /// <summary>
        /// Порог
        /// </summary>
        public int limit = 640;
        /// <summary>
        /// Сумма масштабированных сигналов
        /// </summary>
        public int sum;
        /// <summary>
        /// Сивол, который определяет нейрон
        /// </summary>
        public int sizeX;
        public int sizeY;

        public Web(int sizeX, int sizeY)
        {
            weight = new int[sizeX, sizeY];
            mul = new int[sizeX, sizeY];

            input = new int[sizeX, sizeY];
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
        /// <summary>
        /// Масштабирование
        /// </summary>
        public void mul_w()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    mul[x, y] = input[x, y] * weight[x, y];
                }
            }
        }
        /// <summary>
        /// Сложение
        /// </summary>
        public void Sum()
        {
            sum = 0;
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    sum += mul[x, y];
                }
            }
        }
        /// <summary>
        /// Сравнение
        /// </summary>
        /// <returns></returns>
        public bool Rez()
        {
            return sum >= limit ? true : false;
        }

        public void incW()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    weight[x, y] += input[x, y];
                }
            }
        }
        public void decW()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    weight[x, y] -= input[x, y];
                }
            }
        }
    }
}
