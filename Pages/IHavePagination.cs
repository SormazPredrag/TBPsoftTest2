using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBPsoftTest2.Pages
{
    public interface IHavePagination
    {
        int GetCurrentPageNumber();
        void OpenNextPage();
        void OpenPreviousPage();
        void GoOnPage(int pageNumber);
    }
}
