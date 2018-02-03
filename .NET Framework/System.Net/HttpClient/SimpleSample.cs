// A simple sample of downloading a page by HttpClient
// And showcase of using async / await.

class Program
    {
        static void Main(string[] args)
        {
			var t = new System.Threading.Tasks.Task(DownloadPageAsync);
			t.Start();
			Console.WriteLine("Downloading page...");
			Console.Read();

		}

		static async void DownloadPageAsync()
		{
			string targetPage = "http://en.wikipedia.org/";

			using (HttpClient client = new HttpClient())
			using (HttpResponseMessage response = await client.GetAsync(targetPage))
			using (HttpContent content = response.Content)
			{
				// ... Read the string.
				string result = await content.ReadAsStringAsync();

				// ... Display the result.
				if (result != null &&
					result.Length >= 50)
				{
					Console.WriteLine("Page downloaded.");
					//Console.WriteLine(result);
				}
			}
		}
    }
