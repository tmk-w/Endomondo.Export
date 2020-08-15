using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Endomondo.Export.Models.Gpx;
using Microsoft.Extensions.Logging;

namespace Endomondo.Export
{
    public class FileService : IFileService
    {
        private readonly Options _options;
        private readonly ILogger<IFileService> _logger;

        public FileService(Options options, ILogger<IFileService> logger)
        {
            _logger = logger;
            _options = options;
        }

        public void Save(Gpx gpx)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Gpx));

            var directory = _options.Path;
            var fileName = $@"{directory}\{gpx.trk.name}.gpx";

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                mySerializer.Serialize(fileStream, gpx);
                Console.WriteLine($"File saved at: {fileName}");
            }
        }
    }

    public interface IFileService
    {
        void Save(Gpx gpx);
    }
}
