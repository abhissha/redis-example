using System;
using System.Collections.Generic;
using System.Text;

namespace example.library.Services.cache
{
    public interface ICacheService
    {
        void Set<T, U>(T key, U value);

        U Get<T, U>(T key);
    }
}
