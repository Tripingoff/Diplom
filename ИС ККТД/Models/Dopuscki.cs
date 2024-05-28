using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИС_ККТД.Models
{
    internal class Dopuscki
    {
        public struct BuyItem
        {
            public int Count { get; set; }
            public string Discipline { get; set; }
            public string Name { get; set; }
            public string Family { get; set; }
            public string Group { get; set; }
        }
        public static Dictionary<Итог_дисциплин, BuyItem> GetListBox { get; } = new Dictionary<Итог_дисциплин, BuyItem>();
        public static void AddProductInBasket(Итог_дисциплин product)
        {
            // если такой товар есть в корзине
            if (GetListBox.ContainsKey(product))
            {
                // увеличиваем его количество на +1
                int k = GetListBox[product].Count + 1;
                // пересчистваем стоимость
                GetListBox[product] = new BuyItem { Count = k };
            }
            else
            {
                // добавляем новый товар в корзину в количесьве 1 шт
                GetListBox[product] = new BuyItem { Count = 1 };
            }
        }
        public static int GetCount
        {
            get
            {
                return GetListBox.Count;
            }
        }
    }
}
