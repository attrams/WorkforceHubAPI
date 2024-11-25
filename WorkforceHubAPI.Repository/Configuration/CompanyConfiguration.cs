using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Repository.Configuration;

/// <summary>
/// Configures the entity model for the <see cref="Company"/> entity in the database.
/// Implements the <see cref="IEntityTypeConfiguration{TEntity}"/> interface to provide
/// configuration for the Company entity.
/// </summary>
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    /// <summary>
    /// Configures the properties and seed data for the <see cref="Company"/> entity.
    /// </summary>
    /// <param name="builder">
    /// An instance of <see cref="EntityTypeBuilder{TEntity}"/> used to configure the Company entity.
    /// </param>
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        // Adds seed data for the Company entity.
        builder.HasData(
            new Company
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "AccraTech Solutions",
                Address = "123 Silicon Street, East Legon, Accra",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
                Name = "Kumasi Innovations",
                Address = "45 Ashanti Way, Adum, Kumasi",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
                Name = "Cape Coast Ventures",
                Address = "78 Ocean Drive, Cape Coast",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
                Name = "Takoradi Energy Systems",
                Address = "89 Harbor Road, Takoradi",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
                Name = "Tema Logistics Hub",
                Address = "456 Port Lane, Tema",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
                Name = "Sunyani AgroTech",
                Address = "34 Green Street, Sunyani",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
                Name = "Ho Digital Services",
                Address = "12 Volt Road, Ho",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
                Name = "Tamale Business Solutions",
                Address = "56 Savannah Way, Tamale",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
                Name = "Bolgatanga Rural Enterprises",
                Address = "89 Northern Road, Bolgatanga",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
                Name = "Wa Regional Tech",
                Address = "34 Upper West Lane, Wa",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
                Name = "Sekondi Marine Services",
                Address = "67 Coastline Avenue, Sekondi",
                Country = "Ghana",
            },
            new Company
            {
                Id = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
                Name = "Koforidua Tech Hub",
                Address = "98 Eastern Road, Koforidua",
                Country = "Ghana",
            }
        );
    }
}
