using System;
using System.Collections.Generic;

namespace Academy.Domain.DataAccess
{
    public interface INewsStorage<T>
    {
        void Add(T news);

        void Read(int newsId);

        void Remove(int newsId);

        bool Exists(int userId, int entityId);

        IEnumerable<T> Get(int userId);

        IPageData<T> Get(int userId, int page, int size);
    }
}
