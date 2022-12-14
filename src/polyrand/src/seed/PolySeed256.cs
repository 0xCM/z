//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Facilities deterministic/repeatable executions of pseudorandom processes
    /// </summary>
    public static class PolySeed256
    {
        static Guid[] guids = new Guid[]
        {
            Guid.Parse("5bbf8e0e-86d7-4500-8d7a-d800a31aa74c"),
            Guid.Parse("e0ceda40-871f-454e-ae55-9e8014641f11"),
            Guid.Parse("af710899-ad13-4b38-8025-686cbd11f727"),
            Guid.Parse("c241edec-70b6-4392-b772-c2c85f42847f"),
            Guid.Parse("30bbb197-c92b-4935-bcc1-cb1cd171e96b"),
            Guid.Parse("271ec2dc-d3bb-4cae-83ef-f4dc1b7e544d"),
            Guid.Parse("b0dd253e-34ea-4977-8ecd-8b4a331a1d51"),
            Guid.Parse("9a806925-ed56-45aa-a288-0bb9c0e94109"),
            Guid.Parse("fceb7851-4a2f-4a2a-bf28-b47861017731"),
            Guid.Parse("1d60d2d8-508c-4230-be74-1281f1fbdc15"),
            Guid.Parse("0b8f9f87-8824-45f3-bf5e-d95ee7c7a08a"),
            Guid.Parse("16c6f41d-a484-4f4a-9cdc-66e40fe480e1"),
            Guid.Parse("93dabe65-5a78-4a8e-8185-5a1daaff3392"),
            Guid.Parse("2c1733a7-70a8-4f29-aa07-f7621e5b1540"),
            Guid.Parse("54b56c2a-a119-48ce-8b68-4cdec7edb281"),
            Guid.Parse("d950a298-eaab-4a24-911f-0f7e44fe3711"),
            Guid.Parse("a532ce67-9ae7-4232-a005-71cd8b54ade0"),
            Guid.Parse("bc7a71e2-93c4-4d5a-87f8-987daa22bce7"),
            Guid.Parse("847b408c-5753-4ed4-b5b2-2869a9ed6060"),
            Guid.Parse("802cffa3-96cb-4f24-b629-2db4ec0b40db"),
            Guid.Parse("7bb47354-f15c-4723-b4fa-866f912e389c"),
            Guid.Parse("e98c8ab6-d495-4563-9d8d-e41a85d237b4"),
            Guid.Parse("057e3ba2-f51f-4688-906f-50bbbcf24608"),
            Guid.Parse("5a1441a2-4e80-44f0-805f-05b144a59246"),
            Guid.Parse("4d95e3d0-bd7d-4a0b-9218-b3a0f495207a"),
            Guid.Parse("f01fca82-efce-4cfb-bb3f-414d253ef261"),
            Guid.Parse("71948021-960b-4c1c-8a66-2e1709edf256"),
            Guid.Parse("50a52a45-4cda-477e-b482-1b577e76443c"),
            Guid.Parse("6c9db1a3-ef65-45ed-a3d8-c22ea2a951a1"),
            Guid.Parse("a497151d-0588-45ff-be31-2e6ecfff358e"),
            Guid.Parse("1d92198f-c528-466f-88f7-0d1e49188a44"),
            Guid.Parse("1004cb8f-60dd-4d77-bbe7-9ffb27237fd7"),
            Guid.Parse("ebcd1066-8bde-4364-8c24-e7c82c875ea7"),
            Guid.Parse("4c69602b-5c14-4ff5-88fb-0cec98b6cfd8"),
            Guid.Parse("80dd61fb-60c2-4175-8ec6-7e0b2e61717c"),
            Guid.Parse("a08032b6-0cf3-4152-8b6d-4f21a9619446"),
            Guid.Parse("df0e0e16-af70-4f19-96b1-3787322eb8ba"),
            Guid.Parse("75c116f6-b705-481b-b6f4-33272fce52fb"),
            Guid.Parse("36434804-6f60-4750-ad14-bed3daf0082e"),
            Guid.Parse("d08a272c-9a87-4712-8603-c4e4f0e25a23"),
            Guid.Parse("b86aca00-0e2e-4991-b336-741d665441e6"),
            Guid.Parse("74a2283a-1867-4e9c-b93b-937de3476224"),
            Guid.Parse("628156a2-012b-479e-8f62-ad1a0e754bc4"),
            Guid.Parse("2a7721bc-411f-4389-97a4-5e1e78fad711"),
            Guid.Parse("b69800c7-853b-41c5-ba90-698de821605d"),
            Guid.Parse("740089b8-f74b-456d-af67-0771aa9f770a"),
            Guid.Parse("43087571-321d-4219-8567-c8389d7b1b49"),
            Guid.Parse("7ed5908b-eca3-4544-a0d2-2b2dc8c4df44"),
            Guid.Parse("7b950a50-6489-44c9-af27-08ca8694c9d9"),
            Guid.Parse("bd5e6553-0dfa-4c94-8d65-7238fbed3d85"),
            Guid.Parse("c6ff027a-ea9f-47a4-ac78-4d77db221c55"),
            Guid.Parse("46a26aac-7821-4f89-9d5d-a4c777df0aec"),
            Guid.Parse("5162a9ee-ba04-483a-b8a9-f5507cd61da8"),
            Guid.Parse("77e61e21-61b7-4d47-a7d8-37bdc07cedee"),
            Guid.Parse("0716c3ee-7b51-468b-981c-86f16b61eb44"),
            Guid.Parse("8c01b4d0-30f2-491f-a113-0f34c8863e1b"),
            Guid.Parse("de931ffd-f6b3-4451-b347-53bb4839a772"),
            Guid.Parse("32216311-e4d0-4757-9775-83c79ff0a870"),
            Guid.Parse("a9d1b380-0fbf-4635-bc69-cef8e5029ace"),
            Guid.Parse("19be8390-0e3c-4696-b6c1-2859ea2c41c8"),
            Guid.Parse("5b871a95-47fe-474f-9783-b5fda6b6139a"),
            Guid.Parse("a553aa4d-4e55-4274-a5e4-45ff87220866"),
            Guid.Parse("76cb5450-a2b4-4e4a-b73f-e73e6c7b9424"),
            Guid.Parse("92220086-a11a-436e-a8a4-deaa3ac81ef0"),
            Guid.Parse("046f389f-0cd8-4589-9bf2-30322d27754d"),
            Guid.Parse("14899910-fb83-4d98-ac49-aabe9cf9f50a"),
            Guid.Parse("94307d71-6cc7-4385-921c-17b5b3a97b65"),
            Guid.Parse("d7cc3706-87a6-4251-a6b1-a6a5a38cee23"),
            Guid.Parse("b132d413-9755-45a2-84ea-2323f07642f6"),
            Guid.Parse("e84cf556-c3e9-45f7-bea3-66b96988e289"),
            Guid.Parse("914af6ec-20a2-4a67-bcd1-ad8c72c263f8"),
            Guid.Parse("042f37d5-aeca-4dd2-9fc2-177060e9cec8"),
            Guid.Parse("203372e7-ce89-4d26-ad62-f645e80642e3"),
            Guid.Parse("4f0097cf-2449-404c-9516-39492e530a3e"),
            Guid.Parse("daf11637-1e7e-49cd-992e-3e0f94037857"),
            Guid.Parse("893392ff-6bfd-4f9e-ac4e-f73993ba6200"),
            Guid.Parse("5db9c6be-baaf-4f81-ae3b-57c8ff2b29dd"),
            Guid.Parse("66e48b8d-2d7c-4207-bc7f-c9d8872a7ba2"),
            Guid.Parse("62add655-ae9a-4d37-a1e8-9e82d0ec02fd"),
            Guid.Parse("409a71f6-4aa6-4cb1-b062-f1e81dbb4eb6"),
            Guid.Parse("6115158e-a00e-4fe0-bb8c-cc89c00c58be"),
            Guid.Parse("b5e17f8a-8b9e-419c-a2bc-bc45efb4df23"),
            Guid.Parse("b65644d2-acd8-4e86-b708-ee31abceb368"),
            Guid.Parse("87a8143e-dbba-4a2a-a373-88affab63161"),
            Guid.Parse("a8f4d5d3-b76c-41b7-8eac-099fcc4f64cd"),
            Guid.Parse("33962fdd-d0cf-44f0-9c75-8ff7eed767b2"),
            Guid.Parse("871b5533-c172-4e14-8170-fcd781d6270d"),
            Guid.Parse("b6735813-a294-4ce9-a2dd-0a4eec1dc84c"),
            Guid.Parse("b13a2783-1532-4071-8e63-9196a37c75b4"),
            Guid.Parse("7f120696-2f7a-475c-8a4c-fc6eb1f248ad"),
            Guid.Parse("a35b5fac-96e0-4225-bc71-ef03bdb211e3"),
            Guid.Parse("56d71c10-0135-4971-bbaf-ef7ef47b3cf1"),
            Guid.Parse("5f898ff5-86e9-46d4-9543-1fbebbb752b2"),
            Guid.Parse("ea3d92b3-f096-41a8-9008-feacfee9faf0"),
            Guid.Parse("9c432697-e1aa-4551-b1e4-fcd1a7b38ce2"),
            Guid.Parse("1bd236dc-3788-4c69-92a1-f1b77aa964ea"),
            Guid.Parse("f2beda26-fe4f-409b-bac0-ef13e9b3b0b6"),
            Guid.Parse("a651f93c-f906-45cb-ab6a-190d7d66acd3"),
            Guid.Parse("453a9cf5-6b50-4256-8402-e33a8cca8c37"),
            Guid.Parse("c49a7501-8df5-4f5f-a99b-9d2a20ff761e"),
            Guid.Parse("f0a3c7bd-400a-4496-b56b-d2e307acd21f"),
            Guid.Parse("59eb50b2-e56d-4382-a9e4-eb2a42004306"),
            Guid.Parse("127d1d17-2194-49e4-93a1-9a7243d8cc0b"),
            Guid.Parse("ba957d88-d715-4387-968b-e6bb54159267"),
            Guid.Parse("bf509b9d-f26a-4c92-95fd-d1200372c5c1"),
            Guid.Parse("0e1286c9-9190-4ca4-8543-9ddd050eaf23"),
            Guid.Parse("9b6cce5a-56b8-4c59-84a0-4c59c63d39e9"),
            Guid.Parse("71a34af1-565c-455a-a113-47034e9490c7"),
            Guid.Parse("66d385bf-3c33-4697-974f-03e227cc8463"),
            Guid.Parse("8bb72f11-bf4e-4aad-8ee4-aef2b54d55eb"),
            Guid.Parse("c4aa64ca-fbad-4f4f-9f7d-df3998637d17"),
            Guid.Parse("2af0a554-61d6-4ca8-a2d2-23f523ff235b"),
            Guid.Parse("41b0ec82-4315-40b2-8e2b-0026988ba026"),
            Guid.Parse("fd6305ba-4b1c-43e4-8397-0af99a42a4ae"),
            Guid.Parse("a8d163ed-4bf9-4b71-9e38-f5f3bf8fc81e"),
            Guid.Parse("739e7df9-1720-4d72-ba84-034df93ea5b1"),
            Guid.Parse("a748d4ae-17bb-4cce-b479-134f9d544059"),
            Guid.Parse("de4e3325-d5c5-456d-a4d7-6786e8b72489"),
            Guid.Parse("9bd85426-d328-48be-9ad8-f28c5ab1fc90"),
            Guid.Parse("02034567-9965-4108-b2d8-42ec47a8d09f"),
            Guid.Parse("3c234099-f376-47d5-8c47-4db84ea2d069"),
            Guid.Parse("d2d736f4-a9bd-4659-894f-c74d8a43f0e4"),
            Guid.Parse("637d2670-863a-490d-99ec-e2d301913fae"),
            Guid.Parse("459d048b-f30f-4498-9ec4-5e7ff878204a"),
            Guid.Parse("4e467e35-e1ce-4d51-88cc-b4b112e4ad6f"),
            Guid.Parse("ccc0dc13-62e6-4c70-957f-1113a3839b8d"),
            Guid.Parse("d1e84d2b-1a00-409a-a29a-365a167e36eb"),
            Guid.Parse("61483600-e48c-45ae-95c7-a9e2a6845a4c"),
            Guid.Parse("fa25c33d-7b8c-4931-88c5-0b166e5bd07b"),
            Guid.Parse("7decf176-7b7f-41cb-ad8f-10f0187d7c85"),
            Guid.Parse("3d14d2a3-d5b2-4fbb-8452-e4d51870570c"),
            Guid.Parse("52c77301-b2b7-4da2-a2cc-29a63c28a579"),
            Guid.Parse("5f209e08-bbbf-4662-b5f0-e196883a8d88"),
            Guid.Parse("f402849c-584e-45bd-a28c-a6aaec018a4c"),
            Guid.Parse("f45c5f16-25fe-4108-922d-29f7816697a8"),
            Guid.Parse("a21ddebf-9c61-43da-85fd-cef3120f384c"),
            Guid.Parse("32bf7ab6-265d-4597-a2a9-1ca3ac9ca06b"),
            Guid.Parse("82d067f4-7b72-4a20-bc6b-d85247dc23a9"),
            Guid.Parse("9aff4888-443e-4a8c-b027-2b0b58dfd3ec"),
            Guid.Parse("470ce5c6-b76a-4c92-8370-27c13ccbc8cb"),
            Guid.Parse("13ea17b4-7974-402c-802a-5658b7f3d0c8"),
            Guid.Parse("3eef93f9-8a7e-4b24-93ed-0588f140c345"),
            Guid.Parse("20d404e1-7dc3-4234-8cbd-65224a0137b5"),
            Guid.Parse("7657a57d-d60f-4a19-a590-c1c9b168e08f"),
            Guid.Parse("8adbaf2a-0e4f-4395-80f0-61c455a3e5da"),
            Guid.Parse("310cbe10-71a6-4eac-9d92-cf5e43a1a279"),
            Guid.Parse("3f395ad6-b248-4351-af08-6814079a5243"),
            Guid.Parse("01658ef2-b198-4af2-95eb-13cadc05616d"),
            Guid.Parse("cfd2821b-1c34-41fe-ae02-cb8cf5a06d89"),
            Guid.Parse("97327173-46b6-4e5e-a089-821a9b51aefa"),
            Guid.Parse("8c422264-6c21-4b03-b788-2ac909b0bda3"),
            Guid.Parse("4633e8fa-7ee9-4171-bbe2-d96397af855e"),
            Guid.Parse("67bcd70f-aa24-4b7e-b950-2099ff269c72"),
            Guid.Parse("d8407b09-82b3-4e60-9c9b-5fd6c7f29591"),
            Guid.Parse("2f55689f-466f-492e-a481-cb0726cf2437"),
            Guid.Parse("604477e2-10c7-4eb3-9c94-7307078b845c"),
            Guid.Parse("e129fc1c-222c-4e49-a960-dd5b6ca8418c"),
            Guid.Parse("7bde87b3-ab15-4557-af87-143e2d7b120f"),
            Guid.Parse("bf001424-41c3-4b43-992d-b29dd5455920"),
            Guid.Parse("298c86ef-4d17-4e51-afff-3754d334f751"),
            Guid.Parse("4edbd7b2-f9ba-40d7-89b3-4674c35d3756"),
            Guid.Parse("d591f885-5fb4-46d8-ad68-5225a9efe9e1"),
            Guid.Parse("f112b71d-ca90-4471-823a-4e8b83806f78"),
            Guid.Parse("2a18b322-3298-425d-8c05-c2caf969dd7f"),
            Guid.Parse("1a355b72-cb79-42c6-8a47-f62bcac035c2"),
            Guid.Parse("7175133b-654d-4a6c-bd51-19a74a075626"),
            Guid.Parse("64aa93bb-da44-4730-be02-d0a663004dac"),
            Guid.Parse("8cf3136f-6af6-4a4d-9cbf-013602b6103d"),
        };

        public static ulong[] Default = Arrays.from(guids[18],guids[19]).ToU64Array();

        public static void generate()
        {
            static string guid()
                => text.dquote(Guid.NewGuid().ToString());

            for(var i = 0; i< 200; i++)
                Console.WriteLine($"Guid.Parse({guid()}),");
        }
    }
}