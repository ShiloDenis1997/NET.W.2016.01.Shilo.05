using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public interface IRowsComparator
    {
        int Compare(long[] row1, long[] row2);
    }
}
