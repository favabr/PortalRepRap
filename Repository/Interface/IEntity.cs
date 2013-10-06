namespace PortalRepRap.Framework.Repository.Interface
{
    public interface IEntity
    {
        string[] Errors { get; }

        long? Id { get; set; }

        bool IsValid();
    }
}
