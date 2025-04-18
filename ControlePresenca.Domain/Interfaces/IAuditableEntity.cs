﻿using System;

namespace ControlePresenca.Domain.Interfaces;

public interface IAuditableEntity
{
    DateTime? CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

