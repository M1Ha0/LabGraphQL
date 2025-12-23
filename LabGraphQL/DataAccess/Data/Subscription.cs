using LabGraphQL.DataAccess.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace LabGraphQL.DataAccess.Data
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Parent>> OnParentCreate([Service] ITopicEventReceiver eventReceiver,CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Parent>("ParentCreated", cancalltionToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Child>> OnChildGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Child>("ReturnedChild", cancalltionToken);
        }
    }
}
