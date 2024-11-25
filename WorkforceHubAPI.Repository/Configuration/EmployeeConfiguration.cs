using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Repository.Configuration;

/// <summary>
/// Configures the entity model for the <see cref="Employee"/> entity in the database.
/// Implements the <see cref="IEntityTypeConfiguration{TEntity}"/> interface to provide
/// configuration for the Employee entity.
/// </summary>
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    /// <summary>
    /// Configures the properties and seed data for the <see cref="Employee"/> entity.
    /// </summary>
    /// <param name="builder">
    /// An instance of <see cref="EntityTypeBuilder{TEntity}"/> used to configure the Employee entity.
    /// </param>
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(
            // AccraTech Solutions employees
            new Employee
            {
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Name = "Sam Raiden",
                Age = 26,
                Position = "Software Developer",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("1a283b1d-ecf4-4a62-bfc0-b4a07cc1b54a"),
                Name = "Linda Akpene",
                Age = 30,
                Position = "UI/UX Designer",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("24ab8f3d-6783-4327-963b-c13c63bc285a"),
                Name = "Kwame Asante",
                Age = 35,
                Position = "Project Manager",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("c01a3e8d-1493-4ca1-bbc2-2b5be7a217f7"),
                Name = "Evelyn Osei",
                Age = 28,
                Position = "Marketing Specialist",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("bb742a8e-1be2-4cc0-8e0c-ec545b168943"),
                Name = "Isaac Owusu",
                Age = 32,
                Position = "Backend Developer",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("79c55ab3-d5bc-441d-b885-38cabe3f659b"),
                Name = "Kwabena Amankwah",
                Age = 29,
                Position = "Product Designer",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("dc2efdc5-bfdd-4a0f-90b2-081ed9c17f87"),
                Name = "Ama Nkrumah",
                Age = 27,
                Position = "Frontend Developer",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("a30d4e91-b6fe-4774-b43e-0fc72fef0169"),
                Name = "Kwasi Nkrumah",
                Age = 31,
                Position = "DevOps Engineer",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("e69a8f02-0930-4f07-9da9-90227b89ae6b"),
                Name = "Kofi Agyekum",
                Age = 26,
                Position = "Business Analyst",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("31adf02b-63d7-40c0-83f9-588ea6e8465b"),
                Name = "Selina Otieno",
                Age = 28,
                Position = "Database Administrator",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("dfad8187-1a69-4637-b4be-9b84d1a430b2"),
                Name = "Nana Ama",
                Age = 30,
                Position = "Sales Manager",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Employee
            {
                Id = new Guid("b06e76c5-6635-47cd-bfbc-22a970953118"),
                Name = "Richard Ansah",
                Age = 34,
                Position = "Network Engineer",
                CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            // Kumasi Innovations employees
            new Employee
            {
                Id = new Guid("a87b3a9c-b2f9-4609-a9b9-ea80b6e32a60"),
                Name = "Kwame Boakye",
                Age = 28,
                Position = "Software Engineer",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("7c60b745-bd6c-44b5-b31c-4d975f0a1e64"),
                Name = "Ama Mensah",
                Age = 32,
                Position = "Digital Marketing Specialist",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("ab29fa9c-0a8c-43b9-b36c-c8b7905959b2"),
                Name = "Yaw Ofori",
                Age = 29,
                Position = "Frontend Developer",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("8be53912-2879-46ed-918b-6abff8b8a76e"),
                Name = "Evelyn Appiah",
                Age = 30,
                Position = "Project Manager",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("1a6a35b6-cf47-4bbf-bbb0-c5e43b17b503"),
                Name = "Kwasi Fosu",
                Age = 34,
                Position = "Business Analyst",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("530f68bb-9ad6-4e5e-b2da-bf6a2324ff2a"),
                Name = "Martha Aidoo",
                Age = 27,
                Position = "Backend Developer",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("12545e89-d7e9-4fd6-bd33-3cf3e8d3272f"),
                Name = "Kofi Ntow",
                Age = 29,
                Position = "UI/UX Designer",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("d95c5c3f-f2e4-4fe2-9797-939b63e73b51"),
                Name = "Selina Obeng",
                Age = 31,
                Position = "Network Engineer",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("4063c586-1497-411f-8b74-28a6a53f3ff2"),
                Name = "Kwabena Afriyie",
                Age = 30,
                Position = "System Administrator",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("bdc51cf2-2f0b-4a6c-9298-8c8d00405639"),
                Name = "Kwame Kwaku",
                Age = 27,
                Position = "DevOps Engineer",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("18f69f4e-0d34-4c19-b7e3-70c973d5f121"),
                Name = "Akua Asare",
                Age = 25,
                Position = "Sales Manager",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            new Employee
            {
                Id = new Guid("ab177301-cada-4190-8f5c-c2ff62d86cd0"),
                Name = "Selorm Aklamanu",
                Age = 33,
                Position = "Database Administrator",
                CompanyId = new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"),
            },
            // Cape Coast Ventures employees
            new Employee
            {
                Id = new Guid("8db43067-b4bb-46f2-9083-bc7ca37025a0"),
                Name = "Kofi Mensah",
                Age = 27,
                Position = "Software Developer",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("9a776712-8428-4c61-b388-86bcbb98607a"),
                Name = "Akosua Asamoah",
                Age = 30,
                Position = "Project Manager",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("6f087b39-c8a7-417f-98c1-9b9e1ad0327f"),
                Name = "Kwame Owusu",
                Age = 33,
                Position = "Frontend Developer",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("8355b262-58c1-4b96-b85a-292bfc1d7b7d"),
                Name = "Abena Adomako",
                Age = 29,
                Position = "Marketing Specialist",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("d201d6d4-bd5f-4c27-b2ba-b302b4c6a9f9"),
                Name = "Yaw Afful",
                Age = 28,
                Position = "Backend Developer",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("e764879d-bd6f-4de0-bb19-18dcb09d07b5"),
                Name = "Martha Osei",
                Age = 31,
                Position = "Business Analyst",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("41208e82-cf02-4b1f-b0ba-f51ec8a212f1"),
                Name = "Kwabena Amoah",
                Age = 34,
                Position = "DevOps Engineer",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("a84d5c6c-b00c-44e2-85fa-9783248f6652"),
                Name = "Selina Ofori",
                Age = 26,
                Position = "HR Manager",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("5684c3b4-63d4-44db-a923-3e92a7a72055"),
                Name = "Kwame Buadi",
                Age = 29,
                Position = "System Administrator",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("01805b3d-7178-4c8b-bff5-e53bb9d40819"),
                Name = "Akua Osei",
                Age = 32,
                Position = "Sales Manager",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("2a8dff97-7628-4dbf-aad3-240e957c5f77"),
                Name = "Selorm Appiah",
                Age = 30,
                Position = "Software Architect",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            new Employee
            {
                Id = new Guid("f501c1a2-c69c-4d84-baa3-0215687032a3"),
                Name = "Kwesi Oteng",
                Age = 27,
                Position = "Database Administrator",
                CompanyId = new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"),
            },
            // Takoradi Energy Systems employees
            new Employee
            {
                Id = new Guid("c72b39d0-36f6-42c6-81b0-dc85fc9f65b7"),
                Name = "Kwame Agyemang",
                Age = 29,
                Position = "Electrical Engineer",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("a651649d-d9a0-4be3-b268-b51e22921f3a"),
                Name = "Esi Mensah",
                Age = 31,
                Position = "Safety Officer",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("baf6ab35-178d-49f0-b810-970b4eb908f4"),
                Name = "Abena Opoku",
                Age = 27,
                Position = "Field Technician",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("cb8a682b-4926-4423-8f98-c8b3b32ea707"),
                Name = "Yaw Asare",
                Age = 35,
                Position = "Mechanical Engineer",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("b0c3720d-58ad-46c5-9887-b2490cfc4677"),
                Name = "Kofi Boateng",
                Age = 32,
                Position = "Project Manager",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("df99867f-5e47-4b7d-8c7d-84a55a6efca1"),
                Name = "Selina Ofori",
                Age = 29,
                Position = "HR Manager",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("b89f6a5f-1f22-4311-b957-e545bc3f7c89"),
                Name = "Akua Ansah",
                Age = 33,
                Position = "Finance Manager",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("cc2549a1-c0f8-4f1a-8ad7-4f2a951d9ac1"),
                Name = "Kwabena Addo",
                Age = 30,
                Position = "Electrical Design Engineer",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("fb93d477-35f8-420f-b45a-3bc313bfa11b"),
                Name = "Abdul Aziz",
                Age = 28,
                Position = "Procurement Officer",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("e6d1e63f-3bb2-4f2d-bcb3-bc64e4791f5e"),
                Name = "Grace Osei",
                Age = 26,
                Position = "Laboratory Technician",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("346a2790-1d42-4264-83d9-c2dfe4e25c1d"),
                Name = "Kojo Frimpong",
                Age = 36,
                Position = "Operations Supervisor",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            new Employee
            {
                Id = new Guid("f741e561-dde5-4e13-b8a2-84e489da1289"),
                Name = "Martha Mensah",
                Age = 30,
                Position = "Environmental Engineer",
                CompanyId = new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"),
            },
            // Tema Logistics Hub employees
            new Employee
            {
                Id = new Guid("11831acb-b219-4557-a748-b1e01d041c51"),
                Name = "Kwaku Nyarko",
                Age = 32,
                Position = "Logistics Coordinator",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("fdde8c11-4133-46a5-a0c4-14b39d6a8fd5"),
                Name = "Yaa Ampomah",
                Age = 29,
                Position = "Inventory Manager",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("33e7a41a-9512-47f5-96be-7cc3f5d4043b"),
                Name = "Kwabena Bempah",
                Age = 30,
                Position = "Warehouse Supervisor",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("02b6c2be-60f5-4133-8282-0cfc05558cc9"),
                Name = "Abena Appiah",
                Age = 27,
                Position = "Supply Chain Analyst",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("4d478d92-3b7e-4ff0-94ac-736619b9a4d2"),
                Name = "Kofi Adomako",
                Age = 33,
                Position = "Logistics Manager",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("74a9a2b0-ea2a-43d2-8a75-5b249e1b62ab"),
                Name = "Kwame Frimpong",
                Age = 34,
                Position = "Transport Manager",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("c99b80f2-f8b3-4204-b7f0-e5f9b3cae013"),
                Name = "Martha Boateng",
                Age = 28,
                Position = "Fleet Coordinator",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("b76739c2-8995-4551-bc5c-f16c274e14b7"),
                Name = "Ama Owusu",
                Age = 31,
                Position = "Customer Service Representative",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("678ec9c0-97d4-4d18-a38d-f0f7883a8bcb"),
                Name = "Kojo Baidoo",
                Age = 29,
                Position = "Procurement Officer",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("ddf4e9ed-b459-4a1b-832d-d4a2d63cd3ba"),
                Name = "Selina Kwarteng",
                Age = 28,
                Position = "Operations Manager",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("b774a4db-b55f-470b-b648-24f493f85de4"),
                Name = "Kwabena Owusu",
                Age = 35,
                Position = "Supply Chain Coordinator",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            new Employee
            {
                Id = new Guid("57717f61-0700-4a2d-b167-47316d0fcfe3"),
                Name = "Akosua Frempong",
                Age = 30,
                Position = "Warehouse Associate",
                CompanyId = new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"),
            },
            // Sunyani AgroTech employees
            new Employee
            {
                Id = new Guid("1ac1c94a-ea9b-4c13-8d7c-96b697d2b53f"),
                Name = "Kofi Adu",
                Age = 32,
                Position = "Agronomist",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("948b9b8a-24de-4379-9fe2-dad8d347c920"),
                Name = "Akosua Sarpong",
                Age = 30,
                Position = "Supply Chain Coordinator",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("19a3bb85-bdc5-4641-9413-bd50b7a51a6d"),
                Name = "Yaw Kwaku",
                Age = 35,
                Position = "Field Supervisor",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("fae211f4-55ab-47da-a464-fb62fd8de35b"),
                Name = "Grace Osei",
                Age = 29,
                Position = "Marketing Officer",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("69fc3c71-8d8c-4022-ae16-cb0497be2c55"),
                Name = "Kojo Frimpong",
                Age = 28,
                Position = "Sales Executive",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("5e93d1a9-5829-4020-89a3-dfca1d6c0ab1"),
                Name = "Selina Nkrumah",
                Age = 33,
                Position = "HR Officer",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("28b239d1-d3a3-4a99-9a11-ef238a91b9c4"),
                Name = "Kwaku Adjei",
                Age = 27,
                Position = "Agricultural Technician",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("40b64968-d4d2-479a-bf6e-89d26f1e8d3f"),
                Name = "Akosua Agyemang",
                Age = 34,
                Position = "Quality Control Manager",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("16e2cfe6-3bb5-4f96-a0e5-547f234bd7ac"),
                Name = "Kojo Bempah",
                Age = 31,
                Position = "Operations Manager",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("c6d1c697-bba5-4b22-b622-63669b40c2f7"),
                Name = "Yaa Osei",
                Age = 28,
                Position = "Procurement Assistant",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("9487bbf5-fd1b-4025-803b-fb8e602d9433"),
                Name = "Abena Ofori",
                Age = 26,
                Position = "Logistics Assistant",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            new Employee
            {
                Id = new Guid("ab216b1f-85ea-419b-99b8-85fd7d1d6727"),
                Name = "Yaw Baidoo",
                Age = 29,
                Position = "Product Development Officer",
                CompanyId = new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"),
            },
            // Ho Digital Services employees
            new Employee
            {
                Id = new Guid("b8f6a447-f3f7-44a3-8195-23d6345f4f2d"),
                Name = "Kwame Asante",
                Age = 34,
                Position = "Construction Project Manager",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("e94546f0-0c58-455d-bd98-7be2e3c777c3"),
                Name = "Akosua Owusu",
                Age = 29,
                Position = "Site Supervisor",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("62d3b5a5-d0b6-408b-bf62-83795fd7e3ff"),
                Name = "Yaw Kwaku",
                Age = 28,
                Position = "Civil Engineer",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("7f987cbe-e071-4628-b64a-e1f49f7b4b0c"),
                Name = "Esi Amoah",
                Age = 30,
                Position = "Architect",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("b281b67d-3683-4ca5-b6d4-684d937a1c36"),
                Name = "Kojo Bempah",
                Age = 33,
                Position = "Construction Worker",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("b709de80-b346-4baf-bb1b-4a8a1cd7d4c9"),
                Name = "Kwabena Frimpong",
                Age = 31,
                Position = "Surveyor",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("abe41745-c1f4-4a4e-8d09-df6b22ba53b4"),
                Name = "Akosua Afram",
                Age = 27,
                Position = "Project Coordinator",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("cfb17e10-8ec0-40ae-bca6-d3188e39a0c9"),
                Name = "Martha Boakye",
                Age = 28,
                Position = "Logistics Manager",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("1a145d32-c650-4f92-bc88-01ca36b827eb"),
                Name = "Yaw Frimpong",
                Age = 32,
                Position = "Health & Safety Officer",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("db38e0db-cb93-4c1a-9502-815c1c575d4b"),
                Name = "Kojo Osei",
                Age = 30,
                Position = "Construction Laborer",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("e3f462f1-92c5-463f-bc8a-2b212ea7e592"),
                Name = "Akua Boateng",
                Age = 34,
                Position = "Quantity Surveyor",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            new Employee
            {
                Id = new Guid("379d7cfe-9c4f-44c1-b3a5-d63d4d5227e4"),
                Name = "Abena Baidoo",
                Age = 29,
                Position = "Project Accountant",
                CompanyId = new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"),
            },
            // Tamale Business Solutions employees
            new Employee
            {
                Id = new Guid("e53ea087-c21b-4789-8290-9783fd3d6349"),
                Name = "Kwame Osei",
                Age = 32,
                Position = "Automotive Engineer",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("b3403b64-0880-4bb9-b9f6-c650c7f11fd4"),
                Name = "Akua Adu",
                Age = 29,
                Position = "Workshop Manager",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("9fc8b253-f91e-4b7a-a4fa-b5f9a9a64b98"),
                Name = "Kojo Asante",
                Age = 30,
                Position = "Mechanic",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("c8354b67-5572-4902-8538-b78b81890b72"),
                Name = "Yaa Frimpong",
                Age = 33,
                Position = "Customer Service Representative",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("7cc1c7c9-3f66-4646-bfb5-d4b076b091c3"),
                Name = "Selina Boakye",
                Age = 27,
                Position = "Parts Manager",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("824b670f-72ae-4a06-bdb0-1686a1b0f8be"),
                Name = "Kwabena Kwarteng",
                Age = 35,
                Position = "Service Advisor",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("0c106fd9-9027-402e-9ca0-e431b7a1bc39"),
                Name = "Abena Kwaku",
                Age = 28,
                Position = "Automotive Technician",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("9c26ad3b-17c2-4028-bf63-e01d5c9d0034"),
                Name = "Kojo Agyemang",
                Age = 31,
                Position = "Auto Body Repair Specialist",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("85d46022-7848-4694-b8f3-599c67ea79bb"),
                Name = "Yaa Nkrumah",
                Age = 30,
                Position = "Inventory Coordinator",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("da31e7ab-b8a9-47b0-9752-ff3e6822d6f4"),
                Name = "Yaw Akoto",
                Age = 33,
                Position = "Test Driver",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("45ed3c0b-d7fe-4a58-8cc6-f7773b23795f"),
                Name = "Akosua Bempah",
                Age = 29,
                Position = "Sales Manager",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            new Employee
            {
                Id = new Guid("02c5e378-0be4-46bc-9268-93b57564cd99"),
                Name = "Kwame Kofi",
                Age = 34,
                Position = "Business Development Officer",
                CompanyId = new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"),
            },
            // Bolgatanga Rural Enterprises employees
            new Employee
            {
                Id = new Guid("4933bfc7-0f01-48ac-a26e-99f1f6bb6cf5"),
                Name = "Kwame Akoto",
                Age = 31,
                Position = "Operations Manager",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("f25a1c12-23c4-4b7b-83fa-b98a93961d90"),
                Name = "Akosua Nkrumah",
                Age = 29,
                Position = "Agriculture Specialist",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("99ae6b0e-25e6-4609-8a5d-09848f75ecbb"),
                Name = "Yaw Kwaku",
                Age = 28,
                Position = "Business Analyst",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("d7cc1297-c455-49f4-b6ff-846f36d40b2f"),
                Name = "Kojo Owusu",
                Age = 34,
                Position = "Marketing Officer",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("27cfb8a0-bff1-4f8a-967b-5b12c623af9b"),
                Name = "Abena Asare",
                Age = 32,
                Position = "Project Coordinator",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("0ef8297b-1a8f-42a6-83f3-c0e3a2ea74bb"),
                Name = "Martha Afia",
                Age = 30,
                Position = "Supply Chain Manager",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("94de5454-2cbf-4673-9237-e9d111b39c76"),
                Name = "Kwabena Frimpong",
                Age = 33,
                Position = "Production Manager",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("81024367-6ed0-4170-ae44-56b54e12bfe7"),
                Name = "Yaa Akosua",
                Age = 29,
                Position = "Human Resources Manager",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("abb8d054-d875-406a-8a98-5ad38a1eb697"),
                Name = "Kojo Baidoo",
                Age = 28,
                Position = "Customer Service Officer",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("f25154b1-e702-47c9-a7d6-6599be5c5b56"),
                Name = "Akua Appiah",
                Age = 30,
                Position = "Finance Officer",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("b3328b36-55b1-4f83-89a4-f2a71d1676ff"),
                Name = "Yaw Adu",
                Age = 32,
                Position = "Business Development Manager",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            new Employee
            {
                Id = new Guid("ae5c2fd3-e88e-4b85-8b56-c19328eaa04e"),
                Name = "Esi Boateng",
                Age = 27,
                Position = "Logistics Coordinator",
                CompanyId = new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"),
            },
            // Wa Regional Tech employees
            new Employee
            {
                Id = new Guid("7b6f35ff-cc73-4968-b63a-c37d34e2a1bc"),
                Name = "Kwame Asiedu",
                Age = 31,
                Position = "Software Engineer",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("50335f56-f68f-46f1-a7b1-e348da34c7ac"),
                Name = "Akosua Dwamena",
                Age = 28,
                Position = "Project Manager",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("9d6a2b1c-ecba-44c5-bc8b-8cfe55cb37f7"),
                Name = "Yaw Mensah",
                Age = 34,
                Position = "Senior Developer",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("b36bcd61-08f4-4d45-b0fa-404eb38d85f0"),
                Name = "Kojo Amankwah",
                Age = 29,
                Position = "Data Analyst",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("4319e7c1-b201-4c91-b417-9f5f31b9fc52"),
                Name = "Abena Duodu",
                Age = 30,
                Position = "Business Intelligence Analyst",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("f38035e7-d2ad-4204-91ad-7315206019b1"),
                Name = "Yaw Kofi",
                Age = 32,
                Position = "Quality Assurance Specialist",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("8d16f3e4-1a2b-470d-94c3-c71208e60a72"),
                Name = "Martha Nana",
                Age = 31,
                Position = "System Administrator",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("b5cb9d4c-5a57-402f-bb67-eab6587ffb68"),
                Name = "Akosua Esi",
                Age = 28,
                Position = "Support Engineer",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("add02f5c-986e-4b77-ae7d-bf8cf1ad00f1"),
                Name = "Yaw Nkrumah",
                Age = 27,
                Position = "Operations Assistant",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("c617b3ab-712b-4a60-bb1d-2a1c51f15a97"),
                Name = "Kojo Essien",
                Age = 29,
                Position = "Product Manager",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            new Employee
            {
                Id = new Guid("50ac0be1-7bb1-4d04-b6b2-03b0638fd5f5"),
                Name = "Abena Akua",
                Age = 30,
                Position = "Accountant",
                CompanyId = new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"),
            },
            // Sekondi Marine Services employees
            new Employee
            {
                Id = new Guid("e25cd883-c5d4-40e2-8ed3-531dfedb2118"),
                Name = "Kwame Owusu",
                Age = 32,
                Position = "Marine Engineer",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("d59c4b82-fadf-49fc-bd57-8a745e6f85e4"),
                Name = "Akosua Asante",
                Age = 28,
                Position = "Shipping Coordinator",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("8e77a2bb-3fe4-468d-8397-9d7dff6a6719"),
                Name = "Yaw Adu",
                Age = 34,
                Position = "Logistics Manager",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("0b8ffb1f-2292-4135-8b89-490c8d8dfae0"),
                Name = "Kojo Osei",
                Age = 29,
                Position = "Port Operations Officer",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("06d8d55a-0e78-4448-b453-abead4cd522e"),
                Name = "Abena Boateng",
                Age = 31,
                Position = "Fleet Coordinator",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("1b7f6b10-2396-417d-b9c1-7a31e5814727"),
                Name = "Yaw Frimpong",
                Age = 33,
                Position = "Marine Surveyor",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("d48c5057-24bc-44b0-a847-49e02dbd49d5"),
                Name = "Kojo Appiah",
                Age = 32,
                Position = "Marine Logistics Specialist",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("08d764ef-6226-4c83-8ae9-8bdb85ed7ff6"),
                Name = "Martha Annan",
                Age = 30,
                Position = "Docking Supervisor",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("b0b75517-bc7e-4fa5-bb6b-c77356e82098"),
                Name = "Yaw Kwaku",
                Age = 29,
                Position = "Cargo Handling Manager",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("27999ad6-b49d-472b-924a-5e24f795d249"),
                Name = "Akosua Afia",
                Age = 30,
                Position = "Operations Assistant",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("935e1d07-1534-476f-beb4-92b964772477"),
                Name = "Kojo Asiedu",
                Age = 28,
                Position = "Logistics Coordinator",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            new Employee
            {
                Id = new Guid("4d5f2e34-0db9-488d-b0b5-67295d902ff9"),
                Name = "Yaw Owusu",
                Age = 31,
                Position = "Compliance Officer",
                CompanyId = new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"),
            },
            // Koforidua Tech Hub employees
            new Employee
            {
                Id = new Guid("e318d209-26fc-4874-a533-956bd84589b5"),
                Name = "Kwame Boakye",
                Age = 31,
                Position = "Software Developer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("68bbaaf0-32a0-4b8d-bb42-f6c23f20b03f"),
                Name = "Akosua Amankwah",
                Age = 29,
                Position = "Web Developer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("bda1ea26-c52b-47be-b697-68273a7bdbdf"),
                Name = "Yaw Boateng",
                Age = 34,
                Position = "Mobile App Developer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("aad9a410-13a4-44f2-8d38-acc99ad5c5e3"),
                Name = "Kojo Asamoah",
                Age = 28,
                Position = "Backend Developer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("91ff2e2b-caa2-4733-86c7-7481e55cb690"),
                Name = "Abena Fosu",
                Age = 30,
                Position = "Front-end Developer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("174f4ef9-5bdf-4b67-95fe-19fd3361b5b7"),
                Name = "Yaw Baffour",
                Age = 32,
                Position = "Project Manager",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("5f018cf4-0d51-4644-b381-62debb0620b6"),
                Name = "Martha Osei",
                Age = 33,
                Position = "DevOps Engineer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("93917c27-d504-47e7-8b50-2c2ca5b3d8b7"),
                Name = "Kojo Quartey",
                Age = 28,
                Position = "Database Administrator",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("a7e5561e-1d9e-42fd-b4f8-f9b5e6512d08"),
                Name = "Yaw Nyarko",
                Age = 30,
                Position = "Quality Assurance Engineer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("f9e22d29-2d93-4cbe-b926-dc5b14bbf5a7"),
                Name = "Kojo Attah",
                Age = 29,
                Position = "UI/UX Designer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("5c1c38b1-d57e-4d9b-95f7-e38b91c61b50"),
                Name = "Akosua Kofi",
                Age = 32,
                Position = "Systems Analyst",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            },
            new Employee
            {
                Id = new Guid("42a35b11-bc80-417a-8966-3ea6f06e08ec"),
                Name = "Yaw Duodu",
                Age = 35,
                Position = "Technical Support Engineer",
                CompanyId = new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"),
            }
        );
    }
}
