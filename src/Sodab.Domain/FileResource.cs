using Sodab.Abstracts.DomainAbstracts;
using Sodab.Shared.Enums;

namespace Sodab.Domain;

public class FileResource : IEntity, ICreator
{
    public Guid Id { get; set; }

    public FileType Type { get; set; }
    public string? Name { get; set; }
    public string? Suffix { get; set; }
    public string? Path { get; set; }

    public Guid? CreateUserId { get; set; }
    public DateTime CreateTime { get; set; }
}