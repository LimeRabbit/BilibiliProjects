using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace BilibiliProjects
{
    public static class Compress
    {
        #region 压缩
        public static byte[] CompressString(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0)
            {
                return new byte[0];
            }
            else
            {
                byte[] rawData = Encoding.UTF8.GetBytes(s);
                byte[] zippedData = CompressBytes(rawData);
                return zippedData;
            }
        }

        /// <summary>
        /// GZip压缩
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        static byte[] CompressBytes(byte[] rawData)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(rawData, 0, rawData.Length);
            compressedzipStream.Close();
            return ms.ToArray();
        }
        #endregion

        #region 解压
        public static string DecompressString(byte[] bytes)
        {
            try
            {
                byte[] newBytes = DecompressBytes(bytes);
                return Encoding.UTF8.GetString(newBytes);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ZIP解压
        /// </summary>
        /// <param name="zippedData"></param>
        /// <returns></returns>
        public static byte[] DecompressBytes(byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream outBuffer = new MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }
        #endregion
    }
}
