using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkforceHubAPI.Repository.Configuration;

/// <summary>
/// Configures predefined roles for the Identity system.
/// </summary>
public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    /// <summary>
    /// Seeds the default roles into the database during model creation.
    /// </summary>
    /// <param name="builder">The builder used to configure IdentityRole entities.</param>
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = Guid.Parse("456ac4f6-d40a-437b-ad56-02dc4ca48af4").ToString(),
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new IdentityRole
            {
                Id = Guid.Parse("3e0eed4f-1476-4ca7-9f5a-bc4cf6dc7f27").ToString(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}