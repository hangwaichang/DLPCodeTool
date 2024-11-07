using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DLPCodeCreater;
public class GoogleApiHelper
{
	static string[] Scopes = { DriveService.Scope.DriveReadonly };
	static string ApplicationName = "DLPCodeCreater";

	private DriveService _service;

	public GoogleApiHelper()
	{
		InitializeDriveService().Wait();
	}

	// Authenticate and initialize Google Drive API service
	private async Task InitializeDriveService()
	{


		if (!System.IO.File.Exists(Application.StartupPath + "/client_id.json"))
		{
			throw new Exception("client_id.json 找不到文件");
		}



		// 讀取服務帳戶的 JSON 憑證
		GoogleCredential credential;
		using (var stream = new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
		{
			credential = GoogleCredential.FromStream(stream)
						 .CreateScoped(DriveService.ScopeConstants.Drive);
		}


		// Create Drive API service
		_service = new DriveService(new BaseClientService.Initializer()
		{
			HttpClientInitializer = credential,
			ApplicationName = ApplicationName,
		});
	}

	// Method to download file from Google Drive
	public void DownloadFile(string fileId, string savePath)
	{
		try
		{
			var request = _service.Files.Get(fileId);
			using (var memoryStream = new MemoryStream())
			{
				request.MediaDownloader.ProgressChanged += (progress) =>
				{
					switch (progress.Status)
					{
						case Google.Apis.Download.DownloadStatus.Downloading:
							Console.WriteLine(progress.BytesDownloaded);
							break;

						case Google.Apis.Download.DownloadStatus.Completed:
							Console.WriteLine("Download complete.");
							break;

						case Google.Apis.Download.DownloadStatus.Failed:
							Console.WriteLine("Download failed.");
							break;
					}
				};

				request.Download(memoryStream);

				// Save the file to the provided savePath
				File.WriteAllBytes(savePath, memoryStream.ToArray());
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("An error occurred: " + ex.Message);
		}
	}
}
