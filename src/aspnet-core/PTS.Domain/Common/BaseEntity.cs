﻿using PTS.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        //private readonly List<BaseEvent> _domainEvents = new();

       
        //public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        //public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
        //public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
        //public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
