//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Image_Practice.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public int Id { get; set; }
        public byte[] ImageBin { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
