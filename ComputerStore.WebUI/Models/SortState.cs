using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerStore.WebUI.Models
{
    // Данное перечисление описывает все варианты сортировки
    public enum SortState
    {
        NameAsc, // Название по возрастанию
        NameDesc, // Название по убыванию
        PriceAsc, // Цена по возрастанию
        PriceDesc // Цена по убыванию
    }
}