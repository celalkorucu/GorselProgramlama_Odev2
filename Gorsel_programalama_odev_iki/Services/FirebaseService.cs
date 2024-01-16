﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorsel_programalama_odev_iki.Services
{
    public class FirebaseService
    {

        private readonly FirestoreDb _firestoreDb;

        public FirebaseService()
        {
            // Firestore bağlantısı kurma
            _firestoreDb = FirestoreDb.Create("1:854276152552:android:6aae738d4f4c0c40303d5d");
        }

        public async Task<List<string>> GetDocuments()
        {
            var documents = new List<string>();

            try
            {
                // Firestore koleksiyon referansı alın
                CollectionReference collection = _firestoreDb.Collection("User");

                // Koleksiyondaki belgeleri alın
                QuerySnapshot snapshot = await collection.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    // Belge verilerini işleyin
                    var data = document.ToDictionary();
                    if (data.TryGetValue("name", out var value))
                    {
                        documents.Add(value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda işlemleri burada yönetin
                Console.WriteLine($"Firestore Hatası: {ex.Message}");
            }

            return documents;
        }
    }
}