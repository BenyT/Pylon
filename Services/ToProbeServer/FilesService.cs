﻿using Aiursoft.Pylon.Exceptions;
using Aiursoft.Pylon.Models;
using Aiursoft.Pylon.Models.Probe.FilesAddressModels;
using Aiursoft.Pylon.Models.Probe.FilesViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aiursoft.Pylon.Services.ToProbeServer
{
    public class FilesService
    {
        private readonly HTTPService _http;
        private readonly ServiceLocation _serviceLocation;
        public FilesService(
            HTTPService http,
            ServiceLocation serviceLocation)
        {
            _http = http;
            _serviceLocation = serviceLocation;
        }

        public async Task<UploadFileViewModel> UploadFileAsync(string accessToken, string siteName, string folderNames, Stream fileStream, string fileName, bool recursiveCreate)
        {
            var url = new AiurUrl(_serviceLocation.Probe, $"/Files/UploadFile/{siteName}/{folderNames}", new UploadFileAddressModel
            {
                AccessToken = accessToken,
                RecursiveCreate = recursiveCreate
            });
            var result = await _http.PostFile(url, fileStream, fileName);
            var jResult = JsonConvert.DeserializeObject<UploadFileViewModel>(result);
            if (jResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(jResult);
            return jResult;
        }
    }
}
