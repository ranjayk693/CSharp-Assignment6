using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    // Main method
    public static async Task Main(string[] args)
    {
        // enter the url
        Console.WriteLine("Enter the URL");
        string url = Console.ReadLine();

        try{
            // Read content and extract all the html from the given URL
            string content = await ReadHTML(url);

            // Call the function AsyncWriteSystem to perform write operation
            await AsyncWriteSystem(content);

            Console.WriteLine("Sucess!");
        }
        catch (Exception exception){
            Console.WriteLine("An error occurred");
        }
    }

    // Method to read content from URL asynchronously
    public static async Task<string> ReadHTML(string url)
    {
        // Make the HTTP request
        using (var httpClient = new HttpClient()){
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // throw error if it is failed.
            response.EnsureSuccessStatusCode();

            // Read the content of the response asynchronously and return
            return await response.Content.ReadAsStringAsync();
        }
    }

    // Method to write content to a file asynchronously
    public static async Task AsyncWriteSystem(string content)
    {
        // write the content of html onto the Ranjay.txt
        using (StreamWriter writer = File.CreateText("Ranjay.txt")){
            await writer.WriteAsync(content);
        }
    }
}
