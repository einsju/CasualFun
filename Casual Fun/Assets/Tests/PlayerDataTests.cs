using CasualFun.AtCirclesEdge.Player;
using NUnit.Framework;

namespace CasualFun
{
    public class PlayerDataTests
    {
        [Test]
        public void Construction_ShouldInitializeHighScore()
        {
            var playerData = new PlayerData();
            Assert.IsTrue(playerData.HighScore is 0);
        }

        [Test]
        public void SetName_ShouldUseDefaultIfNotAssigned()
        {
            var playerData = new PlayerData();
            
            playerData.SetName("");
            Assert.IsTrue(playerData.Name == PlayerData.DefaultPlayerName);
            playerData.SetName(null);
            Assert.IsTrue(playerData.Name == PlayerData.DefaultPlayerName);
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
            
            Assert.IsTrue(playerData.Coins == coins);
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
            
            Assert.IsTrue(playerData.HighScore == 1500);
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

        // [Test]
        // public void IncreaseLevel_ShouldNotExceedMaximum()
        // {
        //     var playerData = new PlayerData();
        //
        //     playerData.Level = 100;
        //     playerData.IncreaseLevel();
        // }
    }
}
