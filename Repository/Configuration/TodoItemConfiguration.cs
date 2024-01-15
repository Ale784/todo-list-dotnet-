using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.models;

namespace TodoList.Repository.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasData(

            new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Todo 1",
                    Description = "This is a sample todo item 1.",
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsCompleted = false,
                    UserId = Guid.Parse("d5cdcf38-62ff-491f-a278-a2b48c05eafc"),
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Todo 2",
                    Description = "This is a sample todo item 2.",
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsCompleted = true,
                    UserId = Guid.Parse("d5cdcf38-62ff-491f-a278-a2b48c05eafc"),
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Todo 3",
                    Description = "This is a sample todo item 3.",
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsCompleted = false,
                    UserId = Guid.Parse("d5cdcf38-62ff-491f-a278-a2b48c05eafc"),
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Todo 4",
                    Description = "This is a sample todo item 4.",
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsCompleted = true,
                    UserId = Guid.Parse("d5cdcf38-62ff-491f-a278-a2b48c05eafc"),
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Todo 5",
                    Description = "This is a sample todo item 5.",
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsCompleted = false,
                    UserId = Guid.Parse("d5cdcf38-62ff-491f-a278-a2b48c05eafc"),
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample Todo 6",
                    Description = "This is a sample todo item 6.",
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsCompleted = true,
                    UserId = Guid.Parse("596767dc-c295-4dc9-ae79-4e80796f51db"),
                }
                
        );
    }

}