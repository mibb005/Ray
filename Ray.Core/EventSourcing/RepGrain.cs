﻿using System.Threading.Tasks;

namespace Ray.Core.EventSourcing
{
    public abstract class RepGrain<K, S, W> : AsyncGrain<K, S, W>
        where S : class, IState<K>, new()
        where W : MessageWrapper
    {
        protected abstract IEventHandle EventHandle { get; }
        protected override Task Handle(IEventBase<K> @event)
        {
            EventHandle.Apply(State, @event);
            return Task.CompletedTask;
        }
    }
}