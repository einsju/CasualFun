using CasualFun.AtCirclesEdge.Player;
using NUnit.Framework;

namespace CasualFun
{
    public class PlayerDataTests
    {
        [Test]
        public void SetName_ShouldUseDefaultIfBlank()
        {
            var playerData = new PlayerData();
            
            playerData.SetName("");
            
            Assert.AreEqual(playerData.Name, PlayerData.DefaultPlayerName);
        }
        
        [Test]
        public void SetName_ShouldUseDefaultIfNotAssigned()
        {
            var playerData = new PlayerData();
            
            playerData.SetName(null);
            
            Assert.AreEqual(playerData.Name, PlayerData.DefaultPlayerName);
        }
        
        [Test]
        public void SetName_ShouldNotNotifyThatPlayerDataHasBeenChanged_WhenPlayerNameRemainsTheSame()
        {
            var playerData = new PlayerData();
            var notified = false;

            PlayerData.PlayerDataUpdated += data => notified = true;

            playerData.SetName(PlayerData.DefaultPlayerName);

            Assert.IsFalse(notified);
        }

        [Test]
        public void SetName_ShouldNotifyThatPlayerDataHasBeenChanged_WhenPlayerNameHasChanged()
        {
            var playerData = new PlayerData();
            var notified = false;

            PlayerData.PlayerDataUpdated += data => notified = true;

            playerData.SetName("There is a new player in town");

            Assert.IsTrue(notified);
        }

        [Test]
        public void AddCoins_ShouldHaveValidInput()
        {
            var playerData = new PlayerData();
            var coins = playerData.Coins;
            
            playerData.AddCoins(-1);
            
            Assert.AreEqual(playerData.Coins, coins);
        }

        [Test]
        public void AddCoins_ShouldNotifyThatPlayerDataHasBeenUpdated()
        {
            var playerData = new PlayerData();
            var notified = false;

            PlayerData.PlayerDataUpdated += data => notified = true;

            playerData.AddCoins(1);

            Assert.IsTrue(notified);
        }

        [Test]
        public void SetHighScore_ShouldNotSaveWhenBelowOrEqualToCurrentHighScore()
        {
            var playerData = new PlayerData();
            
            playerData.SetHighScore(1500);
            playerData.SetHighScore(300);
            
            Assert.AreEqual(playerData.HighScore, 1500);
        }

        [Test]
        public void SetHighScore_ShouldNotifyIfNewHighScoreHasBeenAchieved()
        {
            var playerData = new PlayerData();
            var notified = false;

            PlayerData.NewHighScoreAchieved += data => notified = true;

            playerData.SetHighScore(1500);

            Assert.IsTrue(notified);
        }

        [Test]
        public void SetHighScore_ShouldNotifyThatPlayerDataHasBeenUpdated()
        {
            var playerData = new PlayerData();
            var notified = false;

            PlayerData.PlayerDataUpdated += data => notified = true;

            playerData.SetHighScore(1500);

            Assert.IsTrue(notified);
        }

        [Test]
        public void IncreaseLevel_ShouldIncreaseLevelByOne()
        {
            var playerData = new PlayerData();
        
            playerData.IncreaseLevel();
            
            Assert.AreEqual(playerData.Level, 2);
        }
    }
}
