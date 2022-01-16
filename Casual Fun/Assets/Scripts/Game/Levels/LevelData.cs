namespace CasualFun.AtCirclesEdge.Game.Levels
{
    public class LevelData
    {
        public int LevelNumber { get; }
        public int WaveIndex { get; private set; }
        
        public LevelData(int levelNumber)
        {
            WaveIndex = 0;
            LevelNumber = levelNumber;
        }
        
        public void MoveToNextWave() => WaveIndex++;
    }
}
