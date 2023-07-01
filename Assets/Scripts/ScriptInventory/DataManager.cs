using System;
using System.Collections.Generic;
using UnityEngine;



    public class DataManager : MonoBehaviour
    {
        public List<ItemData> inventory;
        public static DataManager Instance;

        


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            else
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }



        public void SaveInventory(Inventory inventorySave)
        {
            inventorySave.GetItems(ref inventory);
        }

        public List<ItemData> LoadInventory()
        {
            return inventory;
        }
    }


