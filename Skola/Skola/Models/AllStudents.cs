using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Models
{
    internal class AllStudents
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public AllStudents() =>
            LoadStudents();

        public void LoadStudents()
        {
            Students.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Student> students = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.studenti.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Student()
                                        {
                                            Filename = filename,
                                            FirstName = File.ReadAllLines(filename)[0],
                                            LastName = File.ReadAllLines(filename)[1],
                                            Class = File.ReadAllLines(filename)[2]
                                        });
                                        
            // Add each note into the ObservableCollection
            foreach (Student student in students)
                Students.Add(student);
        }
    }
}
