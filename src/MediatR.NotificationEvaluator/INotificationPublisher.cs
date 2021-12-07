namespace MediatR.NotificationEvaluator
{
    public interface INotificationPublisher
    {
        void Evaluate(IEvaluated request);

        void Evaluate<TParam>(IEvaluated<TParam> request, TParam parameter);

        Task Publish(CancellationToken cancellationToken = default);
    }
}
