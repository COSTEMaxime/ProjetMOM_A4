using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class DAO {

        public string[] getSubDirectories(string directoryName) {
            return Directory.GetDirectories(directoryName);
        }

        public string[] getDirectoryFiles(string directoryName) {
            return Directory.GetFiles(directoryName);
        }

        public string[] getDrives() {
            return Environment.GetLogicalDrives();
        } 

        public string[] getFilesContents(string[] files) {

            List<string> contents = new List<string>();

            foreach(string file in files) {
                try {
                    contents.Add(File.ReadAllText(file));
                } catch(UnauthorizedAccessException) {
                    contents.Add("");
                }
            }

            return contents.Cast<string>().ToArray();
        }
    }
}
