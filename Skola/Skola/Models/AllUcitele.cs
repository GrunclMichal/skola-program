using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Models
{
    internal class AllUcitele
    {
        public ObservableCollection<Ucitel> Ucitele { get; set; } = new ObservableCollection<Ucitel>();

        public AllUcitele() =>
            LoadUcitele();

        public void LoadUcitele()
        {
            Ucitele.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Ucitel> ucitele = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.ucitele.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Ucitel()
                                        {
                                            Filename = filename,
                                            FirstName = File.ReadAllLines(filename)[0],
                                            LastName = File.ReadAllLines(filename)[1],
                                            Title = File.ReadAllLines(filename)[2]
                                        });

            // Add each note into the ObservableCollection
            foreach (Ucitel ucitel in ucitele)
                Ucitele.Add(ucitel);
        }
    }
}
