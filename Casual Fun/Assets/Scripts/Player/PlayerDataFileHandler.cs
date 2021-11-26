using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CasualFun.Player
{
    public class PlayerDataFileHandler : MonoBehaviour, IPlayerDataHandler
    {
        string _path;

        void Awake() => _path = $"{Application.persistentDataPath}/player.data";

        public void Save(PlayerData data)
        {
            var formatter = new BinaryFormatter();
            var file = File.Create(_path);
                
            formatter.Serialize(file, data);
            file.Close();
        }

        public PlayerData Load()
        {
            if (!File.Exists(_path)) return null;
            var file = File.Open(_path, FileMode.Open);
            
            try
            {
                return new BinaryFormatter().Deserialize(file) as PlayerData;
            }
            catch
            {
                return null;
            }
            finally
            {
                file.Close();
            }
        }
    }
}
