namespace Verity.CashFlow.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity()
    {
    }

    protected Entity(Guid id) => Id = id;

    public Guid Id { get; private init; }

    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; private set; }

    public override bool Equals(object? obj)
        => obj is Entity entity && Id.Equals(entity.Id);

    public bool Equals(Entity? other)
        => Equals((object?)other);

    public static bool operator ==(Entity left, Entity right)
        => Equals(left, right);

    public static bool operator !=(Entity left, Entity right)
        => !Equals(left, right);

    public override int GetHashCode()
        => Id.GetHashCode();
}
