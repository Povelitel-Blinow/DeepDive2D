using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Menu
{
    public class ApiReader : MonoBehaviour
    {
        private string url = "https://2025.nti-gamedev.ru/api/games/36f5aee8-a612-4329-a849-be59c7ba7d08/players/";

        public void GetPlayer(string playerName)
        {
            Debug.Log("Started");
            StartCoroutine(CheckPlayerInList(playerName));
        }

        IEnumerator CheckPlayerInList(string playerName)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                Debug.Log("1");
                yield return request.SendWebRequest();
                Debug.Log("Finished");
                if (request.result == UnityWebRequest.Result.Success)
                {
                    string responseText = request.downloadHandler.text;
                    Debug.Log("Ответ от API: " + responseText);
                    
                    List<PlayerData> players = JsonHelper.FromJson<PlayerData>(responseText);
                    
                    bool playerFound = false;
                    foreach (var player in players)
                    {
                        if (player.name == playerName)
                        {
                            playerFound = true;
                            Debug.Log($"Игрок \"{playerName}\" найден!");
                            break;
                        }
                    }

                    if (!playerFound)
                    {
                        Debug.Log($"Игрок \"{playerName}\" не найден.");
                    }
                }
                else
                {
                    Debug.LogError("Ошибка при обращении к API: " + request.error);
                }
            }
        }
    }
    
    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public object resources;
    }
    
    public static class JsonHelper
    {
        public static List<T> FromJson<T>(string json)
        {
            string newJson = "{ \"items\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return new List<T>(wrapper.items);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] items;
        }
    }
}
