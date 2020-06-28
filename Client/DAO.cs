using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class DAO {

        public List<string> getSubDirectoriesAndFiles(string directoryName) {

            List<string> sub = new List<string>();
            return null;
        }

        public List<string> getDrives() {
            return new List<string>(Environment.GetLogicalDrives());
        } 

        public string[] getFilesContent(string[] files) {

            List<string> contents = new List<string>();

            foreach(string file in files) {
                contents.Add(File.ReadAllText(file));
            }

            return contents.Cast<string>().ToArray();
        }

    }
}
