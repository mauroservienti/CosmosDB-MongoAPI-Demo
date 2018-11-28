using NServiceBus;
using NServiceBus.MongoDB;
using System.Threading.Tasks;

namespace MongoCosmos
{
    public class SamplePolicy : Saga<SamplePolicyState>, IAmStartedByMessages<SomethingHappened>
    {
        public Task Handle(SomethingHappened message, IMessageHandlerContext context)
        {
            return Task.CompletedTask;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SamplePolicyState> mapper)
        {
            mapper.ConfigureMapping<SomethingHappened>(m => m.EventId).ToSaga(s => s.EventId);
        }
    }

    public class SamplePolicyState : ContainMongoSagaData
    {
        public string EventId { get; set; }
    }
}
