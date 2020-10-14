using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bog.Assets.Scripts
{
    public interface InitDependable<T>
    {
        void Init (T t);
    }
}