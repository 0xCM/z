//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Security.Cryptography;

    public static class PolySeed1024
    {
        static Guid[] FixedGuids = new Guid[]
        {
            Guid.Parse("a719bf6a-b70f-473c-9a25-00f4f7169af7"),
            Guid.Parse("002ec328-4f86-4b48-8c4c-5c9002b8871b"),
            Guid.Parse("2664bdb7-7223-4026-b81b-44e509f7fa9b"),
            Guid.Parse("0d5301fa-f9c3-47ea-b774-3389f914e0fb"),
            Guid.Parse("69ab17b5-53a8-4826-83f6-a0f136b38748"),
            Guid.Parse("badc3c43-7e16-44a1-83dd-3b12b637257e"),
            Guid.Parse("86ac807c-e9ea-437e-b810-5bc7598906b1"),
            Guid.Parse("3f3771ec-99f3-404a-a28d-dbd5e10eb5cb"),
            Guid.Parse("4f1a0608-4e46-4f61-b51e-1f25c120e912"),
            Guid.Parse("bb843d6d-2240-403e-9751-ce69610912d8"),
            Guid.Parse("757510b8-4148-4322-8fff-82690a7804e8"),
            Guid.Parse("a7189c60-f706-4682-93b7-40517cf693ec"),
            Guid.Parse("ca7dca40-f3eb-4927-8bf0-0fe30c3732a8"),
            Guid.Parse("bf1eba7b-16d7-4098-8148-4ad60195b197"),
            Guid.Parse("c54c04b4-1d5d-4fc2-9fa1-285f83803cbb"),
            Guid.Parse("b2bb66e7-41df-464b-825e-223ae393bc76"),
            Guid.Parse("34cb1db5-a30a-43fd-a707-2abf7e9776ee"),
            Guid.Parse("96f5ef59-8605-4fa7-8f14-16f4bc2dc9a4"),
            Guid.Parse("da752515-ac1f-4d3f-b815-d7dfc8f67baf"),
            Guid.Parse("bf0540fc-3d46-4a63-9a45-32b5a2001c4e"),
            Guid.Parse("c19ef3ae-5598-4396-96ec-9daf5ba7e2ae"),
            Guid.Parse("1eee3063-4922-4a28-9b8e-91888e0e3e91"),
            Guid.Parse("e84b5d78-f63a-4d5f-a1ac-82fb15df9052"),
            Guid.Parse("b3e27280-ef87-4255-a357-d540444947fb"),
            Guid.Parse("3e0fa75e-6f81-455a-a428-1e8c637c080f"),
            Guid.Parse("7c2412ff-67be-4e40-b2b6-20a146e0b13b"),
            Guid.Parse("2aa476cb-fe06-4112-9d76-70a60cf82962"),
            Guid.Parse("0f79c7e1-2e5e-4517-aba3-ae365c180bb0"),
            Guid.Parse("ae502ee5-fb27-4ed4-9e80-954c35e4629e"),
            Guid.Parse("00fd59ca-47ed-4d94-9fc0-d8225d0b856e"),
            Guid.Parse("e2dc95db-7a12-49b1-8cef-6818f67180fe"),
            Guid.Parse("58d433a1-6844-4adf-8596-e6cba3d35855"),

           };

        public static ulong[] TestSeed
            = Arrays.from(
                FixedGuids[0],FixedGuids[1],FixedGuids[2],FixedGuids[3],
                FixedGuids[4],FixedGuids[5],FixedGuids[6],FixedGuids[7]).ToU64Array();

        public static ulong[] AppSeed
            = Arrays.from(FixedGuids[16],FixedGuids[17],FixedGuids[18],FixedGuids[19],
                FixedGuids[20],FixedGuids[21],FixedGuids[22],FixedGuids[23]).ToU64Array();

        public static ulong[] Default
            = Arrays.from(FixedGuids[24],FixedGuids[25],FixedGuids[26],FixedGuids[27],
                FixedGuids[28],FixedGuids[29],FixedGuids[30],FixedGuids[31]).ToU64Array();

        static ulong[] Entropy()
        {
            using var csp = new RNGCryptoServiceProvider();
            var dst = new byte[1024];
            csp.GetBytes(dst);
            return Unsafe.As<byte[],ulong[]>(ref dst);
        }

        public static ulong[] Entropic
            => Entropy();
    }
}