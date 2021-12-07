using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.NotificationEvaluator
{
    public interface IEvaluated<T>
    {

    }

    public interface IEvaluated : IEvaluated<Unit>
    {

    }
}
