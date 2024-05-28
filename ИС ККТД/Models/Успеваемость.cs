//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ИС_ККТД.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Успеваемость
    {
        public int Id_успеваемости { get; set; }
        public int Id_студента { get; set; }
        public int Id_плана { get; set; }
        public System.DateTime Дата { get; set; }
        public System.TimeSpan Время { get; set; }
        public Nullable<int> Оценка { get; set; }
    
        public virtual Студенты Студенты { get; set; }
        public virtual Учебный_план Учебный_план { get; set; }

        public double CalculateAverageGradeForStudent
        {
            get
            {
                var grades = IS_KKTDEntities.GetContext().Успеваемость.OrderBy(g => g.Оценка).ToList();
                int k = 0;
                int sum = 0;
                double avg;
                if (Id_плана > 0)
                {
                    if (grades.Count > 0)
                    {
                        for (int i = 0; i < grades.Count; i++)
                        {
                            sum = +(int)(Оценка);
                            k++;
                            return sum;
                        }
                        avg = sum / k;
                        return avg;
                    }
                    else
                    {
                        return 0;
                    }

                }
                return Id_плана;
            }

        }
        public double CalculateAverageGradeForStudent2
        {
            get
            {
                var grades = IS_KKTDEntities.GetContext().Успеваемость.OrderBy(g => g.Оценка).ToList();
                int k = 0;
                int sum = 0;
                double avg;
                if (Id_студента > 0)
                {
                    if (Id_плана > 0)
                    {
                        if (grades.Count > 0)
                        {
                            for (int i = 0; i < grades.Count; i++)
                            {
                                sum = +(int)(Оценка);
                                k++;
                                return sum;
                            }
                            avg = sum / k;
                            return avg;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    return Id_плана;

                }
                return Id_студента;
            }

        }
    }
}
