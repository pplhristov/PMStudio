using PMStudio.Web.ViewModels.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMStudio.Services.Data
{
    public interface IGetTotalCountsService
    {
        IndexViewModel GetTotalCount(string userId);
    }
}
