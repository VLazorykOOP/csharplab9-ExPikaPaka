using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT {
    class MusicCatalog {
        private Hashtable catalog = new Hashtable();

        // Method to add a new CD to the catalog
        public void AddCD(string cdTitle, string artist) {
            if (!catalog.ContainsKey(cdTitle)) {
                catalog.Add(cdTitle, new Hashtable());
            }

            Hashtable cdDetails = (Hashtable)catalog[cdTitle];
            cdDetails.Add("Artist", artist);
            cdDetails.Add("Songs", new ArrayList());
        }

        // Method to remove a CD from the catalog
        public void RemoveCD(string cdTitle) {
            if (catalog.ContainsKey(cdTitle)) {
                catalog.Remove(cdTitle);
            }
        }

        // Method to add a song to a CD
        public void AddSong(string cdTitle, string songTitle) {
            if (catalog.ContainsKey(cdTitle)) {
                Hashtable cdDetails = (Hashtable)catalog[cdTitle];
                ArrayList songs = (ArrayList)cdDetails["Songs"];
                songs.Add(songTitle);
            }
        }

        // Method to remove a song from a CD
        public void RemoveSong(string cdTitle, string songTitle) {
            if (catalog.ContainsKey(cdTitle)) {
                Hashtable cdDetails = (Hashtable)catalog[cdTitle];
                ArrayList songs = (ArrayList)cdDetails["Songs"];
                songs.Remove(songTitle);
            }
        }

        // Method to view the contents of the catalog
        public void ViewCatalog() {
            foreach (DictionaryEntry cdEntry in catalog) {
                string cdTitle = (string)cdEntry.Key;
                Hashtable cdDetails = (Hashtable)cdEntry.Value;

                Console.WriteLine($"CD Title: {cdTitle}");
                Console.WriteLine($"Artist: {cdDetails["Artist"]}");
                Console.WriteLine("Songs:");

                ArrayList songs = (ArrayList)cdDetails["Songs"];
                foreach (string song in songs) {
                    Console.WriteLine($"- {song}");
                }

                Console.WriteLine();
            }
        }

        // Method to search for all CDs by a given artist
        public void SearchByArtist(string artist) {
            bool found = false;

            foreach (DictionaryEntry cdEntry in catalog) {
                Hashtable cdDetails = (Hashtable)cdEntry.Value;
                if (cdDetails["Artist"].ToString().Equals(artist, StringComparison.OrdinalIgnoreCase)) {
                    found = true;
                    Console.WriteLine($"CD Title: {cdEntry.Key}");
                }
            }

            if (!found) {
                Console.WriteLine("No CDs found for the given artist.");
            }
        }
    }
}
