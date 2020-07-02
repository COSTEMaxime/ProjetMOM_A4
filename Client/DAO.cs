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

        public byte[][] getFilesContents(string[] files) {

            List<byte[]> contents = new List<byte[]>();

            foreach(string file in files) {
                try {
                    contents.Add(File.ReadAllBytes(file));
                    //contents.Add(new byte[10000] );
                }
                catch (UnauthorizedAccessException) {
                    //contents.Add("");
                } catch(IOException) {
                    //contents.Add("");
                }
            }

            return contents.Cast<byte[]>().ToArray();
        }
    }
}
