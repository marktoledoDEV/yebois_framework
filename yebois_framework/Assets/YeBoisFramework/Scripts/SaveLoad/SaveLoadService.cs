using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using YeBoisFramework.Utility;

namespace YeBoisFramework.SaveLoad
{
    public class SaveLoadService : IService
    {
        public enum FileType {
            Text,
            JSON
        }

        public static string SAVE_LOAD_PATH = Application.persistentDataPath + "/gameData";

        public SaveLoadService() {
            createGameDataDirectory();
        }

        public void OnSerialize(string saveName, FileType fileType, string content) {
            string filePath = createDirectoryFileText(saveName, fileType);

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(filePath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(content);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
                fs.Close();
            }

        }

        public string OnDeSerialize(string saveName, FileType fileType) {
            string filePath = createDirectoryFileText(saveName, fileType);
            // Open the stream and read it back.
            if(!File.Exists(filePath)){
                Debug.LogWarning("Unable to find file " + filePath);
                return "";
            }

            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string content = "";
                while ((content = streamReader.ReadLine()) != null)
                {
                    return content;
                }
            }

            Debug.LogWarning("Unable to find file " + saveName + " of type " + fileType);
            return "";
        }

        private string createDirectoryFileText(string fileName, FileType fileType) {
            string fileDirectory = SAVE_LOAD_PATH + "/" + fileName;
            switch (fileType)
            {
                case(FileType.Text):
                    fileDirectory += ".txt";
                    break;
                case(FileType.JSON):
                    fileDirectory += ".json";
                    break;
                default:
                    Debug.LogError("Unknown FileType: " + fileType);
                    break;
            }

            return fileDirectory;
        }

        private void createGameDataDirectory() {
            // Determine whether the directory exists.
            if (Directory.Exists(SAVE_LOAD_PATH))
            {
                Debug.Log("GameData path already exists");
                return;
            }

            // Try to create the directory.
            Debug.Log("GameData path does not exist... creating new one right now!");
            DirectoryInfo di = Directory.CreateDirectory(SAVE_LOAD_PATH);
        }
    }
}
