using System;
using Xunit;

namespace StarwarsWebSockets.Tests
{
    public class GameManagerTest
    {
        [Fact]
        public void Demo()
        {
            GameManager.Instance.Clean();
            GameManager.Instance.SetEvent("game1", "evento1", "valor 1");

            Assert.Single(GameManager.Instance.Games);
            Assert.Single(GameManager.Instance.Games["game1"].Events);
            Assert.Equal(1, GameManager.Instance.Games["game1"].Events["evento1"]);

        }

        [Fact]
        public void Should_GetValueTwo_When_SetEvent_Twice()
        {
            GameManager.Instance.Clean();
            GameManager.Instance.SetEvent("game1", "evento1", "valor 1");
            GameManager.Instance.SetEvent("game1", "evento1", "valor 2");

            Assert.Single(GameManager.Instance.Games);
            Assert.Single(GameManager.Instance.Games["game1"].Events);
            Assert.Equal(2, GameManager.Instance.Games["game1"].Events["evento1"]);

        }
    }
}
