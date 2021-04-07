using System;
using Xunit;

namespace StarwarsWebSockets.Tests
{
    public class GameTest
    {
        [Fact]
        public void Should_GetValueOne_When_SetEvent_One()
        {
            var game = new Game("game1");
            game.SetEvent("evento1", "valor 1");

            Assert.Single(game.Events);
            Assert.Equal(1, game.Events["evento1"]);

        }

        [Fact]
        public void Should_GetValueTwo_When_SetEvent_Twice()
        {
            var game = new Game("game1");
            game.SetEvent("evento1", "valor 1");
            game.SetEvent("evento1", "valor 2");

            Assert.Single(game.Events);
            Assert.Equal(2, game.Events["evento1"]);

        }


        [Fact]
        public void Should_GetDataJson_When_Call()
        {
            var expected = "{\"game\":\"game1\",\"events\":[{\"eventName\":\"evento1\",\"count\":2}]}";
            
            var game = new Game("game1");
            game.SetEvent("evento1", "valor 1");
            game.SetEvent("evento1", "valor 2");

            var result = game.ToJson();

            Assert.Equal(expected, result);

        }


    }
}
