
namespace SmartStore.Core.Entities;

public class Entity<TId>
{
    protected Entity()
    {
        CreatedTime = DateTime.UtcNow;
    }

    public Entity(TId id):this() 
    {
        Id= id;
    }

    public TId Id { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

}
