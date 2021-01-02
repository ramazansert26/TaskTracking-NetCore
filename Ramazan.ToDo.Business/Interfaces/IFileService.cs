using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        ///  Returns the virtual path of the pdf file it has generated and uploaded.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        string ExportPdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// Returns excel data as a byte array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        byte[] ExportExcel<T>(List<T> list) where T : class, new();
    }
}
