using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ИС_ККТД.Windows;

namespace ИС_ККТД.Models
{
    internal class PDF
    {
        public struct BuyItem
        {
            public int Count { get; set; }
            public string FIO { get; set; }
          
        }
        public static Dictionary<Итог_дисциплин, BuyItem> GetDataGrid { get; } = new Dictionary<Итог_дисциплин, BuyItem>();
        public static void AddProductInBasket(Итог_дисциплин product)
        {
            // если такой товар есть в корзине
            if (GetDataGrid.ContainsKey(product))
            {
                // увеличиваем его количество на +1
                int k = GetDataGrid[product].Count + 1;
                // пересчистваем стоимость
                GetDataGrid[product] = new BuyItem { Count = k};
            }
            else
            {
                // добавляем новый товар в корзину в количесьве 1 шт
                GetDataGrid[product] = new BuyItem { Count = 1};
            }
        }
        public static int GetCount
        {
            get
            {
                return GetDataGrid.Count;
            }
        }
    }
}
