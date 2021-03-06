﻿namespace PMStudio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PMStudio.Web.ViewModels;

    public interface IPropertiesService
    {
        Task CreateAsync(CreatePropertiesViewModel input, string imagePath);

        IEnumerable<T> GetAll<T>(int page, string userId, int itemsPerPage = 10);

        int GetCount();

        T GetById<T>(int id);

        Task DeleteAsync(int id);

        Task EditAsync(int id, EditPropertiesViewModel input);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairsForServices();

        bool IsPropertyWithUniqueNameAndAddress(CreatePropertiesViewModel input);
    }
}
