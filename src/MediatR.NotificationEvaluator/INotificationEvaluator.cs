using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.NotificationEvaluator
{
    public interface INotificationEvaluator<TRequest, TParam>
        where TRequest : IEvaluated<TParam>
    {
        bool NotificationRequired(TRequest request, TParam parameter);

        Task<IEnumerable<INotification>> GetNotificationsAsync();
    }

    public interface INotificationEvaluator<TRequest> : INotificationEvaluator<TRequest, Unit>
        where TRequest : IEvaluated
    {

    }
}
