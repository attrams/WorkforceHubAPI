using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkforceHubAPI.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "34 Upper West Lane, Wa", "Ghana", "Wa Regional Tech" },
                    { new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "456 Port Lane, Tema", "Ghana", "Tema Logistics Hub" },
                    { new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "89 Northern Road, Bolgatanga", "Ghana", "Bolgatanga Rural Enterprises" },
                    { new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "89 Harbor Road, Takoradi", "Ghana", "Takoradi Energy Systems" },
                    { new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "56 Savannah Way, Tamale", "Ghana", "Tamale Business Solutions" },
                    { new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "98 Eastern Road, Koforidua", "Ghana", "Koforidua Tech Hub" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "123 Silicon Street, East Legon, Accra", "Ghana", "AccraTech Solutions" },
                    { new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "45 Ashanti Way, Adum, Kumasi", "Ghana", "Kumasi Innovations" },
                    { new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "12 Volt Road, Ho", "Ghana", "Ho Digital Services" },
                    { new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "67 Coastline Avenue, Sekondi", "Ghana", "Sekondi Marine Services" },
                    { new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "78 Ocean Drive, Cape Coast", "Ghana", "Cape Coast Ventures" },
                    { new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "34 Green Street, Sunyani", "Ghana", "Sunyani AgroTech" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("01805b3d-7178-4c8b-bff5-e53bb9d40819"), 32, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Akua Osei", "Sales Manager" },
                    { new Guid("02b6c2be-60f5-4133-8282-0cfc05558cc9"), 27, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Abena Appiah", "Supply Chain Analyst" },
                    { new Guid("02c5e378-0be4-46bc-9268-93b57564cd99"), 34, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Kwame Kofi", "Business Development Officer" },
                    { new Guid("06d8d55a-0e78-4448-b453-abead4cd522e"), 31, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Abena Boateng", "Fleet Coordinator" },
                    { new Guid("08d764ef-6226-4c83-8ae9-8bdb85ed7ff6"), 30, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Martha Annan", "Docking Supervisor" },
                    { new Guid("0b8ffb1f-2292-4135-8b89-490c8d8dfae0"), 29, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Kojo Osei", "Port Operations Officer" },
                    { new Guid("0c106fd9-9027-402e-9ca0-e431b7a1bc39"), 28, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Abena Kwaku", "Automotive Technician" },
                    { new Guid("0ef8297b-1a8f-42a6-83f3-c0e3a2ea74bb"), 30, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Martha Afia", "Supply Chain Manager" },
                    { new Guid("11831acb-b219-4557-a748-b1e01d041c51"), 32, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Kwaku Nyarko", "Logistics Coordinator" },
                    { new Guid("12545e89-d7e9-4fd6-bd33-3cf3e8d3272f"), 29, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Kofi Ntow", "UI/UX Designer" },
                    { new Guid("16e2cfe6-3bb5-4f96-a0e5-547f234bd7ac"), 31, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Kojo Bempah", "Operations Manager" },
                    { new Guid("174f4ef9-5bdf-4b67-95fe-19fd3361b5b7"), 32, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Yaw Baffour", "Project Manager" },
                    { new Guid("18f69f4e-0d34-4c19-b7e3-70c973d5f121"), 25, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Akua Asare", "Sales Manager" },
                    { new Guid("19a3bb85-bdc5-4641-9413-bd50b7a51a6d"), 35, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Yaw Kwaku", "Field Supervisor" },
                    { new Guid("1a145d32-c650-4f92-bc88-01ca36b827eb"), 32, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Yaw Frimpong", "Health & Safety Officer" },
                    { new Guid("1a283b1d-ecf4-4a62-bfc0-b4a07cc1b54a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Linda Akpene", "UI/UX Designer" },
                    { new Guid("1a6a35b6-cf47-4bbf-bbb0-c5e43b17b503"), 34, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Kwasi Fosu", "Business Analyst" },
                    { new Guid("1ac1c94a-ea9b-4c13-8d7c-96b697d2b53f"), 32, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Kofi Adu", "Agronomist" },
                    { new Guid("1b7f6b10-2396-417d-b9c1-7a31e5814727"), 33, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Yaw Frimpong", "Marine Surveyor" },
                    { new Guid("24ab8f3d-6783-4327-963b-c13c63bc285a"), 35, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Kwame Asante", "Project Manager" },
                    { new Guid("27999ad6-b49d-472b-924a-5e24f795d249"), 30, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Akosua Afia", "Operations Assistant" },
                    { new Guid("27cfb8a0-bff1-4f8a-967b-5b12c623af9b"), 32, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Abena Asare", "Project Coordinator" },
                    { new Guid("28b239d1-d3a3-4a99-9a11-ef238a91b9c4"), 27, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Kwaku Adjei", "Agricultural Technician" },
                    { new Guid("2a8dff97-7628-4dbf-aad3-240e957c5f77"), 30, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Selorm Appiah", "Software Architect" },
                    { new Guid("31adf02b-63d7-40c0-83f9-588ea6e8465b"), 28, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Selina Otieno", "Database Administrator" },
                    { new Guid("33e7a41a-9512-47f5-96be-7cc3f5d4043b"), 30, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Kwabena Bempah", "Warehouse Supervisor" },
                    { new Guid("346a2790-1d42-4264-83d9-c2dfe4e25c1d"), 36, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Kojo Frimpong", "Operations Supervisor" },
                    { new Guid("379d7cfe-9c4f-44c1-b3a5-d63d4d5227e4"), 29, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Abena Baidoo", "Project Accountant" },
                    { new Guid("4063c586-1497-411f-8b74-28a6a53f3ff2"), 30, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Kwabena Afriyie", "System Administrator" },
                    { new Guid("40b64968-d4d2-479a-bf6e-89d26f1e8d3f"), 34, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Akosua Agyemang", "Quality Control Manager" },
                    { new Guid("41208e82-cf02-4b1f-b0ba-f51ec8a212f1"), 34, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Kwabena Amoah", "DevOps Engineer" },
                    { new Guid("42a35b11-bc80-417a-8966-3ea6f06e08ec"), 35, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Yaw Duodu", "Technical Support Engineer" },
                    { new Guid("4319e7c1-b201-4c91-b417-9f5f31b9fc52"), 30, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Abena Duodu", "Business Intelligence Analyst" },
                    { new Guid("45ed3c0b-d7fe-4a58-8cc6-f7773b23795f"), 29, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Akosua Bempah", "Sales Manager" },
                    { new Guid("4933bfc7-0f01-48ac-a26e-99f1f6bb6cf5"), 31, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Kwame Akoto", "Operations Manager" },
                    { new Guid("4d478d92-3b7e-4ff0-94ac-736619b9a4d2"), 33, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Kofi Adomako", "Logistics Manager" },
                    { new Guid("4d5f2e34-0db9-488d-b0b5-67295d902ff9"), 31, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Yaw Owusu", "Compliance Officer" },
                    { new Guid("50335f56-f68f-46f1-a7b1-e348da34c7ac"), 28, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Akosua Dwamena", "Project Manager" },
                    { new Guid("50ac0be1-7bb1-4d04-b6b2-03b0638fd5f5"), 30, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Abena Akua", "Accountant" },
                    { new Guid("530f68bb-9ad6-4e5e-b2da-bf6a2324ff2a"), 27, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Martha Aidoo", "Backend Developer" },
                    { new Guid("5684c3b4-63d4-44db-a923-3e92a7a72055"), 29, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Kwame Buadi", "System Administrator" },
                    { new Guid("57717f61-0700-4a2d-b167-47316d0fcfe3"), 30, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Akosua Frempong", "Warehouse Associate" },
                    { new Guid("5c1c38b1-d57e-4d9b-95f7-e38b91c61b50"), 32, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Akosua Kofi", "Systems Analyst" },
                    { new Guid("5e93d1a9-5829-4020-89a3-dfca1d6c0ab1"), 33, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Selina Nkrumah", "HR Officer" },
                    { new Guid("5f018cf4-0d51-4644-b381-62debb0620b6"), 33, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Martha Osei", "DevOps Engineer" },
                    { new Guid("62d3b5a5-d0b6-408b-bf62-83795fd7e3ff"), 28, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Yaw Kwaku", "Civil Engineer" },
                    { new Guid("678ec9c0-97d4-4d18-a38d-f0f7883a8bcb"), 29, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Kojo Baidoo", "Procurement Officer" },
                    { new Guid("68bbaaf0-32a0-4b8d-bb42-f6c23f20b03f"), 29, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Akosua Amankwah", "Web Developer" },
                    { new Guid("69fc3c71-8d8c-4022-ae16-cb0497be2c55"), 28, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Kojo Frimpong", "Sales Executive" },
                    { new Guid("6f087b39-c8a7-417f-98c1-9b9e1ad0327f"), 33, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Kwame Owusu", "Frontend Developer" },
                    { new Guid("74a9a2b0-ea2a-43d2-8a75-5b249e1b62ab"), 34, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Kwame Frimpong", "Transport Manager" },
                    { new Guid("79c55ab3-d5bc-441d-b885-38cabe3f659b"), 29, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Kwabena Amankwah", "Product Designer" },
                    { new Guid("7b6f35ff-cc73-4968-b63a-c37d34e2a1bc"), 31, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Kwame Asiedu", "Software Engineer" },
                    { new Guid("7c60b745-bd6c-44b5-b31c-4d975f0a1e64"), 32, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Ama Mensah", "Digital Marketing Specialist" },
                    { new Guid("7cc1c7c9-3f66-4646-bfb5-d4b076b091c3"), 27, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Selina Boakye", "Parts Manager" },
                    { new Guid("7f987cbe-e071-4628-b64a-e1f49f7b4b0c"), 30, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Esi Amoah", "Architect" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software Developer" },
                    { new Guid("81024367-6ed0-4170-ae44-56b54e12bfe7"), 29, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Yaa Akosua", "Human Resources Manager" },
                    { new Guid("824b670f-72ae-4a06-bdb0-1686a1b0f8be"), 35, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Kwabena Kwarteng", "Service Advisor" },
                    { new Guid("8355b262-58c1-4b96-b85a-292bfc1d7b7d"), 29, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Abena Adomako", "Marketing Specialist" },
                    { new Guid("85d46022-7848-4694-b8f3-599c67ea79bb"), 30, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Yaa Nkrumah", "Inventory Coordinator" },
                    { new Guid("8be53912-2879-46ed-918b-6abff8b8a76e"), 30, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Evelyn Appiah", "Project Manager" },
                    { new Guid("8d16f3e4-1a2b-470d-94c3-c71208e60a72"), 31, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Martha Nana", "System Administrator" },
                    { new Guid("8db43067-b4bb-46f2-9083-bc7ca37025a0"), 27, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Kofi Mensah", "Software Developer" },
                    { new Guid("8e77a2bb-3fe4-468d-8397-9d7dff6a6719"), 34, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Yaw Adu", "Logistics Manager" },
                    { new Guid("91ff2e2b-caa2-4733-86c7-7481e55cb690"), 30, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Abena Fosu", "Front-end Developer" },
                    { new Guid("935e1d07-1534-476f-beb4-92b964772477"), 28, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Kojo Asiedu", "Logistics Coordinator" },
                    { new Guid("93917c27-d504-47e7-8b50-2c2ca5b3d8b7"), 28, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Kojo Quartey", "Database Administrator" },
                    { new Guid("9487bbf5-fd1b-4025-803b-fb8e602d9433"), 26, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Abena Ofori", "Logistics Assistant" },
                    { new Guid("948b9b8a-24de-4379-9fe2-dad8d347c920"), 30, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Akosua Sarpong", "Supply Chain Coordinator" },
                    { new Guid("94de5454-2cbf-4673-9237-e9d111b39c76"), 33, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Kwabena Frimpong", "Production Manager" },
                    { new Guid("99ae6b0e-25e6-4609-8a5d-09848f75ecbb"), 28, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Yaw Kwaku", "Business Analyst" },
                    { new Guid("9a776712-8428-4c61-b388-86bcbb98607a"), 30, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Akosua Asamoah", "Project Manager" },
                    { new Guid("9c26ad3b-17c2-4028-bf63-e01d5c9d0034"), 31, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Kojo Agyemang", "Auto Body Repair Specialist" },
                    { new Guid("9d6a2b1c-ecba-44c5-bc8b-8cfe55cb37f7"), 34, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Yaw Mensah", "Senior Developer" },
                    { new Guid("9fc8b253-f91e-4b7a-a4fa-b5f9a9a64b98"), 30, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Kojo Asante", "Mechanic" },
                    { new Guid("a30d4e91-b6fe-4774-b43e-0fc72fef0169"), 31, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Kwasi Nkrumah", "DevOps Engineer" },
                    { new Guid("a651649d-d9a0-4be3-b268-b51e22921f3a"), 31, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Esi Mensah", "Safety Officer" },
                    { new Guid("a7e5561e-1d9e-42fd-b4f8-f9b5e6512d08"), 30, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Yaw Nyarko", "Quality Assurance Engineer" },
                    { new Guid("a84d5c6c-b00c-44e2-85fa-9783248f6652"), 26, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Selina Ofori", "HR Manager" },
                    { new Guid("a87b3a9c-b2f9-4609-a9b9-ea80b6e32a60"), 28, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Kwame Boakye", "Software Engineer" },
                    { new Guid("aad9a410-13a4-44f2-8d38-acc99ad5c5e3"), 28, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Kojo Asamoah", "Backend Developer" },
                    { new Guid("ab177301-cada-4190-8f5c-c2ff62d86cd0"), 33, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Selorm Aklamanu", "Database Administrator" },
                    { new Guid("ab216b1f-85ea-419b-99b8-85fd7d1d6727"), 29, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Yaw Baidoo", "Product Development Officer" },
                    { new Guid("ab29fa9c-0a8c-43b9-b36c-c8b7905959b2"), 29, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Yaw Ofori", "Frontend Developer" },
                    { new Guid("abb8d054-d875-406a-8a98-5ad38a1eb697"), 28, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Kojo Baidoo", "Customer Service Officer" },
                    { new Guid("abe41745-c1f4-4a4e-8d09-df6b22ba53b4"), 27, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Akosua Afram", "Project Coordinator" },
                    { new Guid("add02f5c-986e-4b77-ae7d-bf8cf1ad00f1"), 27, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Yaw Nkrumah", "Operations Assistant" },
                    { new Guid("ae5c2fd3-e88e-4b85-8b56-c19328eaa04e"), 27, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Esi Boateng", "Logistics Coordinator" },
                    { new Guid("b06e76c5-6635-47cd-bfbc-22a970953118"), 34, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Richard Ansah", "Network Engineer" },
                    { new Guid("b0b75517-bc7e-4fa5-bb6b-c77356e82098"), 29, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Yaw Kwaku", "Cargo Handling Manager" },
                    { new Guid("b0c3720d-58ad-46c5-9887-b2490cfc4677"), 32, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Kofi Boateng", "Project Manager" },
                    { new Guid("b281b67d-3683-4ca5-b6d4-684d937a1c36"), 33, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Kojo Bempah", "Construction Worker" },
                    { new Guid("b3328b36-55b1-4f83-89a4-f2a71d1676ff"), 32, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Yaw Adu", "Business Development Manager" },
                    { new Guid("b3403b64-0880-4bb9-b9f6-c650c7f11fd4"), 29, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Akua Adu", "Workshop Manager" },
                    { new Guid("b36bcd61-08f4-4d45-b0fa-404eb38d85f0"), 29, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Kojo Amankwah", "Data Analyst" },
                    { new Guid("b5cb9d4c-5a57-402f-bb67-eab6587ffb68"), 28, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Akosua Esi", "Support Engineer" },
                    { new Guid("b709de80-b346-4baf-bb1b-4a8a1cd7d4c9"), 31, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Kwabena Frimpong", "Surveyor" },
                    { new Guid("b76739c2-8995-4551-bc5c-f16c274e14b7"), 31, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Ama Owusu", "Customer Service Representative" },
                    { new Guid("b774a4db-b55f-470b-b648-24f493f85de4"), 35, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Kwabena Owusu", "Supply Chain Coordinator" },
                    { new Guid("b89f6a5f-1f22-4311-b957-e545bc3f7c89"), 33, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Akua Ansah", "Finance Manager" },
                    { new Guid("b8f6a447-f3f7-44a3-8195-23d6345f4f2d"), 34, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Kwame Asante", "Construction Project Manager" },
                    { new Guid("baf6ab35-178d-49f0-b810-970b4eb908f4"), 27, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Abena Opoku", "Field Technician" },
                    { new Guid("bb742a8e-1be2-4cc0-8e0c-ec545b168943"), 32, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Isaac Owusu", "Backend Developer" },
                    { new Guid("bda1ea26-c52b-47be-b697-68273a7bdbdf"), 34, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Yaw Boateng", "Mobile App Developer" },
                    { new Guid("bdc51cf2-2f0b-4a6c-9298-8c8d00405639"), 27, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Kwame Kwaku", "DevOps Engineer" },
                    { new Guid("c01a3e8d-1493-4ca1-bbc2-2b5be7a217f7"), 28, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Evelyn Osei", "Marketing Specialist" },
                    { new Guid("c617b3ab-712b-4a60-bb1d-2a1c51f15a97"), 29, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Kojo Essien", "Product Manager" },
                    { new Guid("c6d1c697-bba5-4b22-b622-63669b40c2f7"), 28, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Yaa Osei", "Procurement Assistant" },
                    { new Guid("c72b39d0-36f6-42c6-81b0-dc85fc9f65b7"), 29, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Kwame Agyemang", "Electrical Engineer" },
                    { new Guid("c8354b67-5572-4902-8538-b78b81890b72"), 33, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Yaa Frimpong", "Customer Service Representative" },
                    { new Guid("c99b80f2-f8b3-4204-b7f0-e5f9b3cae013"), 28, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Martha Boateng", "Fleet Coordinator" },
                    { new Guid("cb8a682b-4926-4423-8f98-c8b3b32ea707"), 35, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Yaw Asare", "Mechanical Engineer" },
                    { new Guid("cc2549a1-c0f8-4f1a-8ad7-4f2a951d9ac1"), 30, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Kwabena Addo", "Electrical Design Engineer" },
                    { new Guid("cfb17e10-8ec0-40ae-bca6-d3188e39a0c9"), 28, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Martha Boakye", "Logistics Manager" },
                    { new Guid("d201d6d4-bd5f-4c27-b2ba-b302b4c6a9f9"), 28, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Yaw Afful", "Backend Developer" },
                    { new Guid("d48c5057-24bc-44b0-a847-49e02dbd49d5"), 32, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Kojo Appiah", "Marine Logistics Specialist" },
                    { new Guid("d59c4b82-fadf-49fc-bd57-8a745e6f85e4"), 28, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Akosua Asante", "Shipping Coordinator" },
                    { new Guid("d7cc1297-c455-49f4-b6ff-846f36d40b2f"), 34, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Kojo Owusu", "Marketing Officer" },
                    { new Guid("d95c5c3f-f2e4-4fe2-9797-939b63e73b51"), 31, new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"), "Selina Obeng", "Network Engineer" },
                    { new Guid("da31e7ab-b8a9-47b0-9752-ff3e6822d6f4"), 33, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Yaw Akoto", "Test Driver" },
                    { new Guid("db38e0db-cb93-4c1a-9502-815c1c575d4b"), 30, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Kojo Osei", "Construction Laborer" },
                    { new Guid("dc2efdc5-bfdd-4a0f-90b2-081ed9c17f87"), 27, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Ama Nkrumah", "Frontend Developer" },
                    { new Guid("ddf4e9ed-b459-4a1b-832d-d4a2d63cd3ba"), 28, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Selina Kwarteng", "Operations Manager" },
                    { new Guid("df99867f-5e47-4b7d-8c7d-84a55a6efca1"), 29, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Selina Ofori", "HR Manager" },
                    { new Guid("dfad8187-1a69-4637-b4be-9b84d1a430b2"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Nana Ama", "Sales Manager" },
                    { new Guid("e25cd883-c5d4-40e2-8ed3-531dfedb2118"), 32, new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"), "Kwame Owusu", "Marine Engineer" },
                    { new Guid("e318d209-26fc-4874-a533-956bd84589b5"), 31, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Kwame Boakye", "Software Developer" },
                    { new Guid("e3f462f1-92c5-463f-bc8a-2b212ea7e592"), 34, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Akua Boateng", "Quantity Surveyor" },
                    { new Guid("e53ea087-c21b-4789-8290-9783fd3d6349"), 32, new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"), "Kwame Osei", "Automotive Engineer" },
                    { new Guid("e69a8f02-0930-4f07-9da9-90227b89ae6b"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Kofi Agyekum", "Business Analyst" },
                    { new Guid("e6d1e63f-3bb2-4f2d-bcb3-bc64e4791f5e"), 26, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Grace Osei", "Laboratory Technician" },
                    { new Guid("e764879d-bd6f-4de0-bb19-18dcb09d07b5"), 31, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Martha Osei", "Business Analyst" },
                    { new Guid("e94546f0-0c58-455d-bd98-7be2e3c777c3"), 29, new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"), "Akosua Owusu", "Site Supervisor" },
                    { new Guid("f25154b1-e702-47c9-a7d6-6599be5c5b56"), 30, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Akua Appiah", "Finance Officer" },
                    { new Guid("f25a1c12-23c4-4b7b-83fa-b98a93961d90"), 29, new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"), "Akosua Nkrumah", "Agriculture Specialist" },
                    { new Guid("f38035e7-d2ad-4204-91ad-7315206019b1"), 32, new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"), "Yaw Kofi", "Quality Assurance Specialist" },
                    { new Guid("f501c1a2-c69c-4d84-baa3-0215687032a3"), 27, new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"), "Kwesi Oteng", "Database Administrator" },
                    { new Guid("f741e561-dde5-4e13-b8a2-84e489da1289"), 30, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Martha Mensah", "Environmental Engineer" },
                    { new Guid("f9e22d29-2d93-4cbe-b926-dc5b14bbf5a7"), 29, new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"), "Kojo Attah", "UI/UX Designer" },
                    { new Guid("fae211f4-55ab-47da-a464-fb62fd8de35b"), 29, new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"), "Grace Osei", "Marketing Officer" },
                    { new Guid("fb93d477-35f8-420f-b45a-3bc313bfa11b"), 28, new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"), "Abdul Aziz", "Procurement Officer" },
                    { new Guid("fdde8c11-4133-46a5-a0c4-14b39d6a8fd5"), 29, new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"), "Yaa Ampomah", "Inventory Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("01805b3d-7178-4c8b-bff5-e53bb9d40819"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("02b6c2be-60f5-4133-8282-0cfc05558cc9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("02c5e378-0be4-46bc-9268-93b57564cd99"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("06d8d55a-0e78-4448-b453-abead4cd522e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("08d764ef-6226-4c83-8ae9-8bdb85ed7ff6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("0b8ffb1f-2292-4135-8b89-490c8d8dfae0"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("0c106fd9-9027-402e-9ca0-e431b7a1bc39"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("0ef8297b-1a8f-42a6-83f3-c0e3a2ea74bb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("11831acb-b219-4557-a748-b1e01d041c51"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("12545e89-d7e9-4fd6-bd33-3cf3e8d3272f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("16e2cfe6-3bb5-4f96-a0e5-547f234bd7ac"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("174f4ef9-5bdf-4b67-95fe-19fd3361b5b7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("18f69f4e-0d34-4c19-b7e3-70c973d5f121"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("19a3bb85-bdc5-4641-9413-bd50b7a51a6d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("1a145d32-c650-4f92-bc88-01ca36b827eb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("1a283b1d-ecf4-4a62-bfc0-b4a07cc1b54a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("1a6a35b6-cf47-4bbf-bbb0-c5e43b17b503"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("1ac1c94a-ea9b-4c13-8d7c-96b697d2b53f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("1b7f6b10-2396-417d-b9c1-7a31e5814727"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("24ab8f3d-6783-4327-963b-c13c63bc285a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("27999ad6-b49d-472b-924a-5e24f795d249"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("27cfb8a0-bff1-4f8a-967b-5b12c623af9b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("28b239d1-d3a3-4a99-9a11-ef238a91b9c4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("2a8dff97-7628-4dbf-aad3-240e957c5f77"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("31adf02b-63d7-40c0-83f9-588ea6e8465b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("33e7a41a-9512-47f5-96be-7cc3f5d4043b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("346a2790-1d42-4264-83d9-c2dfe4e25c1d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("379d7cfe-9c4f-44c1-b3a5-d63d4d5227e4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("4063c586-1497-411f-8b74-28a6a53f3ff2"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("40b64968-d4d2-479a-bf6e-89d26f1e8d3f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("41208e82-cf02-4b1f-b0ba-f51ec8a212f1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("42a35b11-bc80-417a-8966-3ea6f06e08ec"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("4319e7c1-b201-4c91-b417-9f5f31b9fc52"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("45ed3c0b-d7fe-4a58-8cc6-f7773b23795f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("4933bfc7-0f01-48ac-a26e-99f1f6bb6cf5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("4d478d92-3b7e-4ff0-94ac-736619b9a4d2"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("4d5f2e34-0db9-488d-b0b5-67295d902ff9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("50335f56-f68f-46f1-a7b1-e348da34c7ac"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("50ac0be1-7bb1-4d04-b6b2-03b0638fd5f5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("530f68bb-9ad6-4e5e-b2da-bf6a2324ff2a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5684c3b4-63d4-44db-a923-3e92a7a72055"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("57717f61-0700-4a2d-b167-47316d0fcfe3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5c1c38b1-d57e-4d9b-95f7-e38b91c61b50"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5e93d1a9-5829-4020-89a3-dfca1d6c0ab1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("5f018cf4-0d51-4644-b381-62debb0620b6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("62d3b5a5-d0b6-408b-bf62-83795fd7e3ff"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("678ec9c0-97d4-4d18-a38d-f0f7883a8bcb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("68bbaaf0-32a0-4b8d-bb42-f6c23f20b03f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("69fc3c71-8d8c-4022-ae16-cb0497be2c55"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("6f087b39-c8a7-417f-98c1-9b9e1ad0327f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("74a9a2b0-ea2a-43d2-8a75-5b249e1b62ab"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("79c55ab3-d5bc-441d-b885-38cabe3f659b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7b6f35ff-cc73-4968-b63a-c37d34e2a1bc"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7c60b745-bd6c-44b5-b31c-4d975f0a1e64"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7cc1c7c9-3f66-4646-bfb5-d4b076b091c3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7f987cbe-e071-4628-b64a-e1f49f7b4b0c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("81024367-6ed0-4170-ae44-56b54e12bfe7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("824b670f-72ae-4a06-bdb0-1686a1b0f8be"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8355b262-58c1-4b96-b85a-292bfc1d7b7d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("85d46022-7848-4694-b8f3-599c67ea79bb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8be53912-2879-46ed-918b-6abff8b8a76e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8d16f3e4-1a2b-470d-94c3-c71208e60a72"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8db43067-b4bb-46f2-9083-bc7ca37025a0"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8e77a2bb-3fe4-468d-8397-9d7dff6a6719"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("91ff2e2b-caa2-4733-86c7-7481e55cb690"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("935e1d07-1534-476f-beb4-92b964772477"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("93917c27-d504-47e7-8b50-2c2ca5b3d8b7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9487bbf5-fd1b-4025-803b-fb8e602d9433"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("948b9b8a-24de-4379-9fe2-dad8d347c920"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("94de5454-2cbf-4673-9237-e9d111b39c76"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("99ae6b0e-25e6-4609-8a5d-09848f75ecbb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9a776712-8428-4c61-b388-86bcbb98607a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9c26ad3b-17c2-4028-bf63-e01d5c9d0034"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9d6a2b1c-ecba-44c5-bc8b-8cfe55cb37f7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9fc8b253-f91e-4b7a-a4fa-b5f9a9a64b98"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("a30d4e91-b6fe-4774-b43e-0fc72fef0169"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("a651649d-d9a0-4be3-b268-b51e22921f3a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("a7e5561e-1d9e-42fd-b4f8-f9b5e6512d08"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("a84d5c6c-b00c-44e2-85fa-9783248f6652"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("a87b3a9c-b2f9-4609-a9b9-ea80b6e32a60"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("aad9a410-13a4-44f2-8d38-acc99ad5c5e3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ab177301-cada-4190-8f5c-c2ff62d86cd0"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ab216b1f-85ea-419b-99b8-85fd7d1d6727"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ab29fa9c-0a8c-43b9-b36c-c8b7905959b2"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("abb8d054-d875-406a-8a98-5ad38a1eb697"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("abe41745-c1f4-4a4e-8d09-df6b22ba53b4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("add02f5c-986e-4b77-ae7d-bf8cf1ad00f1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ae5c2fd3-e88e-4b85-8b56-c19328eaa04e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b06e76c5-6635-47cd-bfbc-22a970953118"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b0b75517-bc7e-4fa5-bb6b-c77356e82098"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b0c3720d-58ad-46c5-9887-b2490cfc4677"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b281b67d-3683-4ca5-b6d4-684d937a1c36"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b3328b36-55b1-4f83-89a4-f2a71d1676ff"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b3403b64-0880-4bb9-b9f6-c650c7f11fd4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b36bcd61-08f4-4d45-b0fa-404eb38d85f0"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b5cb9d4c-5a57-402f-bb67-eab6587ffb68"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b709de80-b346-4baf-bb1b-4a8a1cd7d4c9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b76739c2-8995-4551-bc5c-f16c274e14b7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b774a4db-b55f-470b-b648-24f493f85de4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b89f6a5f-1f22-4311-b957-e545bc3f7c89"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("b8f6a447-f3f7-44a3-8195-23d6345f4f2d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("baf6ab35-178d-49f0-b810-970b4eb908f4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("bb742a8e-1be2-4cc0-8e0c-ec545b168943"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("bda1ea26-c52b-47be-b697-68273a7bdbdf"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("bdc51cf2-2f0b-4a6c-9298-8c8d00405639"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c01a3e8d-1493-4ca1-bbc2-2b5be7a217f7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c617b3ab-712b-4a60-bb1d-2a1c51f15a97"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c6d1c697-bba5-4b22-b622-63669b40c2f7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c72b39d0-36f6-42c6-81b0-dc85fc9f65b7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c8354b67-5572-4902-8538-b78b81890b72"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("c99b80f2-f8b3-4204-b7f0-e5f9b3cae013"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("cb8a682b-4926-4423-8f98-c8b3b32ea707"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("cc2549a1-c0f8-4f1a-8ad7-4f2a951d9ac1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("cfb17e10-8ec0-40ae-bca6-d3188e39a0c9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d201d6d4-bd5f-4c27-b2ba-b302b4c6a9f9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d48c5057-24bc-44b0-a847-49e02dbd49d5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d59c4b82-fadf-49fc-bd57-8a745e6f85e4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d7cc1297-c455-49f4-b6ff-846f36d40b2f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d95c5c3f-f2e4-4fe2-9797-939b63e73b51"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("da31e7ab-b8a9-47b0-9752-ff3e6822d6f4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("db38e0db-cb93-4c1a-9502-815c1c575d4b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("dc2efdc5-bfdd-4a0f-90b2-081ed9c17f87"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ddf4e9ed-b459-4a1b-832d-d4a2d63cd3ba"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("df99867f-5e47-4b7d-8c7d-84a55a6efca1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("dfad8187-1a69-4637-b4be-9b84d1a430b2"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e25cd883-c5d4-40e2-8ed3-531dfedb2118"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e318d209-26fc-4874-a533-956bd84589b5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e3f462f1-92c5-463f-bc8a-2b212ea7e592"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e53ea087-c21b-4789-8290-9783fd3d6349"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e69a8f02-0930-4f07-9da9-90227b89ae6b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e6d1e63f-3bb2-4f2d-bcb3-bc64e4791f5e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e764879d-bd6f-4de0-bb19-18dcb09d07b5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e94546f0-0c58-455d-bd98-7be2e3c777c3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f25154b1-e702-47c9-a7d6-6599be5c5b56"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f25a1c12-23c4-4b7b-83fa-b98a93961d90"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f38035e7-d2ad-4204-91ad-7315206019b1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f501c1a2-c69c-4d84-baa3-0215687032a3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f741e561-dde5-4e13-b8a2-84e489da1289"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("f9e22d29-2d93-4cbe-b926-dc5b14bbf5a7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("fae211f4-55ab-47da-a464-fb62fd8de35b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("fb93d477-35f8-420f-b45a-3bc313bfa11b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("fdde8c11-4133-46a5-a0c4-14b39d6a8fd5"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("a5e9d3c8-f3c8-4791-b7a9-3d74c8b6d5e9"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("a8c963a3-8fb8-41b2-a6cc-cb87c689d62d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("b1c97c3f-c2a5-41a2-89d7-4d85a2b3f8a2"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("b7bce287-c37f-411e-b9f4-3c34f53b7c7c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c3e47a8b-d4cf-435d-927f-6b4e92a3f4c3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c7f6b4d2-8f7b-43c5-a9e3-2d1f4c6b7a3c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("d1f8d4a7-cc3e-4429-a5dc-55a7b8c7b22c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("d3f4b98d-cd5e-4c43-a828-9c8e3d1f5b6a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("e4c8b5f3-d2f7-41a7-a8b4-9f6d5b7c4e3b"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("e6e97850-2e1c-4573-bb49-9d46cde3fc4c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("f7b48b3b-4e2b-4d1a-8f61-9b7c7f8e2f73"));
        }
    }
}
