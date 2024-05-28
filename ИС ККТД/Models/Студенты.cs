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
    using System.IO;

    public partial class Студенты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Студенты()
        {
            this.Итог_дисциплин = new HashSet<Итог_дисциплин>();
            this.Пропуски = new HashSet<Пропуски>();
            this.Успеваемость = new HashSet<Успеваемость>();
        }

        public string GetPhoto
        {
            get
            {
                if (Фото is null)
                    return null;
                return Directory.GetCurrentDirectory() + @"\Images\" + Фото.Trim();
            }
        }
        public int id_студента { get; set; }
        public string Код_студента { get; set; }
        public int id_user { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public int Id_группы { get; set; }
        public string Фото { get; set; }
        public string Пол { get; set; }
        public System.DateTime Дата_рождения { get; set; }
        public string ИНН { get; set; }
        public string СНИЛС { get; set; }
        public string Паспорт { get; set; }
        public string Полис { get; set; }
        public string Прописное { get; set; }
        public string Флюрография { get; set; }
        public System.DateTime Дата { get; set; }
        public string Манту { get; set; }
        public System.DateTime Дата1 { get; set; }
        public string Примечания { get; set; }
    
        public virtual Авторизация Авторизация { get; set; }
        public virtual Группы Группы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Итог_дисциплин> Итог_дисциплин { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Пропуски> Пропуски { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Успеваемость> Успеваемость { get; set; }
    }
}
