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

    public partial class Сотрудники
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Сотрудники()
        {
            this.Группы = new HashSet<Группы>();
            this.ДисцпилинаПреподователь = new HashSet<ДисцпилинаПреподователь>();
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
        public int Id_сотрудника { get; set; }
        public int Id_user { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public int Должность { get; set; }
        public Nullable<int> Должность2 { get; set; }
        public string Почта { get; set; }
        public string Фото { get; set; }
        public string Примечание { get; set; }
    
        public virtual Авторизация Авторизация { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Группы> Группы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ДисцпилинаПреподователь> ДисцпилинаПреподователь { get; set; }
        public virtual Должность Должность1 { get; set; }
    }
}
