using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System;

class AppService : BackgroundService
{
  public string Message { get; set; }
  public AppService(string msg)
  {
    Message = msg;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    // Implementation of the background service
    while (!stoppingToken.IsCancellationRequested)
    {
      Console.WriteLine(Message);
      await Task.Delay(1000, stoppingToken);
    }
  }
}