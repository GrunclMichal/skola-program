using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Models
{
    internal class AllUdrzbari
    {
        public ObservableCollection<Udrzbar> Udrzbari { get; set; } = new ObservableCollection<Udrzbar>();

        public AllUdrzbari() =>
            LoadUdrzbari();

        public void LoadUdrzbari()
        {
            Udrzbari.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Udrzbar> udrzbari = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.udrzbari.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Udrzbar()
                                        {
                                            Filename = filename,
                                            FirstName = File.ReadAllLines(filename)[0],
                                            LastName = File.ReadAllLines(filename)[1]
                                        });

            // Add each note into the ObservableCollection
            foreach (Udrzbar udrzbar in udrzbari)
                Udrzbari.Add(udrzbar);
        }
    }
}
