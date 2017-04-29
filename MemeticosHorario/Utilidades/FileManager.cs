using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MemeticosHorario.Utilidades
{
    public class File_Manager : IDisposable
    {
        #region Declarations:

        private StreamReader reader;
        private StreamWriter writer;

        #endregion

        #region Properties:

        public int LineNum
        {
            get
            {
                int n = 0;
                using (reader)
                {
                    while (Readable)
                    {
                        reader.ReadLine();
                        n++;
                    }                    
                }
                return n;
            }
        }

        public bool Readable
        {
            get
            {
                if (reader != null)
                    return !reader.EndOfStream;
                else
                    return false;
            }
        }        

        #endregion

        #region File Opening:

        public void OpenFile(string filePath, bool toWrite, bool append)
        {

            try
            {
                if (toWrite)
                {
                    writer = new StreamWriter(filePath, append);
                }
                else
                {
                    reader = new StreamReader(filePath);
                    reader.DiscardBufferedData();
                }
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        #endregion

        #region Read & Write:

        public void WriteLine(string line)
        {
            try
            {
                writer.WriteLine(line);
            }
            catch (IOException e)
            {
                throw e;
            }
        }
        public string ReadLine()
        {
            string line = "";
            try
            {
                line = reader.ReadLine();
            }
            catch (IOException e)
            {
                throw e;
            }
            return line;
        }

        #endregion

        #region Dispose:

        public void Dispose()
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
            if (writer != null)
            {
                writer.Close();
                writer.Dispose();
            }
        }

        #endregion
    }
}
