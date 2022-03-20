using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerStore.WebUI.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } // Сортировка по имени
        public SortState PriceSort { get; private set; } // Сортировка по цене
        public SortState Current { get; private set; } // Текущее значение сортировки

        public SortViewModel(SortState sortState)
        {
            NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameDesc;
            PriceSort = sortState == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortState;
        }
    }
}