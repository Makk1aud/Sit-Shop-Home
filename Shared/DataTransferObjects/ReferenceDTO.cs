using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    //Класс для таблиц (статичных справочников) в которых есть только дополнения для других таблиц, по типу гендера или категорий
    public record class ReferenceDTO
    {
        public Guid id { get; init; }
        public string title { get; init; }
    }
}
