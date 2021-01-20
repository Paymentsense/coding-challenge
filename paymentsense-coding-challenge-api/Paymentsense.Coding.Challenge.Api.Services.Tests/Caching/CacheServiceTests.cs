using Autofac;
using Autofac.Extras.Moq;
using AutoFixture;
using FluentAssertions;
using MemoryCache.Testing.Moq;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services.Caching;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Services.Tests.Caching
{
    public class CacheServiceTests
    {
        private const string CacheKey = nameof(CacheServiceTests);

        private const int CacheInTimeSeconds = 300;

        private readonly Fixture fixture;

        private readonly AutoMock mocker;

        private readonly IMemoryCache mockedCache;

        private readonly CacheService sut;

        public CacheServiceTests()
        {
            fixture = new Fixture();
            mocker = AutoMock.GetLoose();

            mockedCache = Create.MockedMemoryCache();
            sut = mocker.Create<CacheService>(new NamedParameter("memorycache", mockedCache));
        }

        [Fact]
        public async Task GetAsync_OnInvoke_IfNoDataInCache_ReturnsFuncCallResult()
        {
            // Arrange
            var funcCountry = fixture.Create<Country>();
            Func<Task<Country>> func = () =>
            {
                return Task.FromResult(funcCountry);
            };

            // Act
            var result = await sut.GetAsync(CacheKey, func, CacheInTimeSeconds).ConfigureAwait(false);

            // Assert
            result.Should().BeEquivalentTo(funcCountry);
        }

        [Fact]
        public async Task GetAsync_OnInvoke_DataInCache_ReturnsCachedData()
        {
            // Arrange
            var cacheCountry = fixture.Create<Country>();
            mockedCache.GetOrCreate(CacheKey, entry => cacheCountry);

            var funcCountry = fixture.Create<Country>();
            Func<Task<Country>> func = () =>
            {
                return Task.FromResult(funcCountry);
            };

            // Act
            var result = await sut.GetAsync(CacheKey, func, CacheInTimeSeconds).ConfigureAwait(false);

            // Assert
            result.Should().BeEquivalentTo(cacheCountry);
        }
    }
}
