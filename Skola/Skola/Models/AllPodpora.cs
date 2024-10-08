using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Models
{
    internal class AllPodpora
    {
        public ObservableCollection<Podpora> Podpora { get; set; } = new ObservableCollection<Podpora>();

        public AllPodpora() =>
            LoadPodpora();

        public void LoadPodpora()
        {
            Podpora.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Podpora> podpora = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.podpora.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Podpora()
                                        {
                                            Filename = filename,
                                            FirstName = File.ReadAllLines(filename)[0],
                                            LastName = File.ReadAllLines(filename)[1]
                                        });

            // Add each note into the ObservableCollection
            foreach (Podpora _podpora in podpora)
                Podpora.Add(_podpora);
        }
    }
}

