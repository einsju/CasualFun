using System.Collections.Generic;
using CasualFun.Managers;
using NUnit.Framework;
using UnityEngine;

namespace CasualFun
{
    public class ScreenManagerTests
    {
        IList<GameObject> _screens;
        ScreenManager Sut => new ScreenManager(_screens);
        
        [Test]
        public void OpenScreen_ShouldNotActivateScreen_WhenScreensAreNotAssigned()
        {
            var screen = new GameObject();
            
            screen.SetActive(false);
            _screens = new List<GameObject>();

            Sut.OpenScreen(screen);
            
            Assert.IsFalse(screen.activeSelf);
        }

        [Test]
        public void OpenScreen_ShouldActivateScreen_WhenScreensAreAssigned()
        {
            var screen = new GameObject();
            
            screen.SetActive(false);
            _screens = new List<GameObject> { new GameObject(), new GameObject() };
            
            Sut.OpenScreen(screen);
            
            Assert.IsTrue(screen.activeSelf);
        }
    }
}
