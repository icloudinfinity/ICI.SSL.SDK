﻿namespace ICI.SSL.Core.Test
{
    [TestClass]
    public class CsrInfoTest
    {
        private readonly ICsrInfoService _csrInfoService;

        public CsrInfoTest()
        {
            _csrInfoService = (ICsrInfoService)DependencyResolver.ServiceProvider().GetService(typeof(ICsrInfoService));
        }

        [TestMethod]
        public async Task CsrInfoCreateTest()
        {
            try
            {
                CsrInfo csrInfo = new CsrInfo
                {
                    countryName = "Trinidad",
                    locality = "Homeland Gardens",
                    state = "Cunupia",
                    organization = "iCloud Infinity",
                    organizationUnit = "IT",
                    subscriptionId = 1
                };

                CsrInfo newCsrInfo = await _csrInfoService.CreateOrUpdateCsrInfoAsync(csrInfo);

                Assert.AreEqual(csrInfo.organization, newCsrInfo?.organization ?? String.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CsrInfoUpdateTest()
        {
            try
            {
                CsrInfo csrInfo = new CsrInfo
                {
                    Id = 2,
                    countryName = "Trinidad and Tobago",
                    locality = "Homeland Gardens",
                    state = "Cunupia",
                    organization = "iCloud Infinity",
                    organizationUnit = "IT",
                    subscriptionId = 1
                };

                CsrInfo updatedCsrInfo = await _csrInfoService.CreateOrUpdateCsrInfoAsync(csrInfo);

                Assert.AreEqual(csrInfo.countryName, updatedCsrInfo?.countryName ?? String.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CsrInfoGetBySubscriptionTest()
        {
            try
            {
                CsrInfo csrInfo = await _csrInfoService.GetCsrInfoBySubscriptionAsync();

                Assert.AreNotEqual(String.Empty, csrInfo?.organization ?? String.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CsrInfoGetByIdTest()
        {
            try
            {
                CsrInfo csrInfo = await _csrInfoService.GetCsrInfoByIdAsync(2);

                Assert.AreEqual(2, csrInfo?.Id);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CsrInfoDeleteTest()
        {
            try
            {
                await _csrInfoService.DeleteCsrInfoAsync(2);

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }
}