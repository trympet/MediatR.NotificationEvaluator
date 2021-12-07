using Autofac;

namespace MediatR.NotificationEvaluator.AutoFac
{
    /// <summary>
    /// Base class single notification providers.
    /// </summary>
    /// <typeparam name="T">Parameter passed to <see cref="GetNotificationAsync(T)"/></typeparam>
    public abstract class NotificationEvaluator<T>
    {
        protected NotificationEvaluator(ILifetimeScope scope)
        {
            Scope = scope;
        }

        protected ILifetimeScope Scope { get; }

        /// <summary>
        /// Gets a task from the result of <see cref="GetNotifications(T)"/>.
        /// </summary>
        /// <returns></returns>
        public virtual Task<IEnumerable<INotification>> GetNotificationsAsync(T parameter)
        {
            return Task.FromResult(GetNotifications(parameter));
        }

        /// <summary>
        /// Stub for creating a notification syncronously. Used by <see cref="GetNotificationsAsync"/>'s default implementation.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">If </exception>
        public virtual IEnumerable<INotification> GetNotifications(T parameter)
        {
            return new List<INotification> { GetNotification(parameter) };
        }

        public virtual INotification GetNotification(T parameter)
        {
            throw new NotImplementedException();
        }

        public virtual Task<INotification> GetNotificationAsync(T parameter)
        {
            return Task.FromResult(GetNotification(parameter));
        }
    }

    public class NotificationEvaluator : NotificationEvaluator<Unit>
    {
        public NotificationEvaluator(ILifetimeScope scope) : base(scope)
        {
        }

        public sealed override INotification GetNotification(Unit parameter)
        {
            return GetNotification();
        }

        public sealed override Task<INotification> GetNotificationAsync(Unit parameter)
        {
            return GetNotificationAsync();
        }

        public sealed override IEnumerable<INotification> GetNotifications(Unit parameter)
        {
            return GetNotifications();
        }

        public sealed override Task<IEnumerable<INotification>> GetNotificationsAsync(Unit parameter)
        {
            return GetNotificationsAsync();
        }

        public virtual Task<INotification> GetNotificationAsync()
        {
            return Task.FromResult(GetNotification())
        }

        public virtual INotification GetNotification()
        {
        }

        public virtual Task<IEnumerable<INotification>> GetNotificationsAsync()
        {
        }

        public virtual IEnumerable<INotification> GetNotifications()
        {
            return new List<INotification> { GetNotification() };
        }
    }

    class Demo : NotificationEvaluator, INotificationEvaluator<Req>
    {
        public Demo(ILifetimeScope scope) : base(scope)
        {
        }

        public bool NotificationRequired(Req request, Unit parameter)
        {
            throw new NotImplementedException();
        }
    }

    class Req : IRequest, IEvaluated { }
}