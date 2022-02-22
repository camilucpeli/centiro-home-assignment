using CentiroHomeAssignment.DataReader;
using CentiroHomeAssignment.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.HostedServices
{
    public class OrdersFileWatcherHostedService : IHostedService, IDisposable
    {
        private readonly Settings _settings;
        private readonly IServiceProvider _provider;
        private FileSystemWatcher _watcher;

        public OrdersFileWatcherHostedService(Settings settings,IServiceProvider provider)
        {
            _settings = settings;
            _provider = provider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            AddOrderFilesDataToDB(_settings.AppDataFolderPath);

            _watcher = new FileSystemWatcher(_settings.AppDataFolderPath);
            _watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            _watcher.Created += OnCreated;

            _watcher.Filter = "*.txt";
            _watcher.EnableRaisingEvents = true;
            return Task.CompletedTask;
        }

        public void OnCreated(object sender, FileSystemEventArgs e)
        {
            AddOrderFilesDataToDB(e.FullPath);
        }

        public async void AddOrderFilesDataToDB(string path)
        {
            using var scope = _provider.CreateScope();
            var fileReader = scope.ServiceProvider.GetService<IFileReader>();
            var orderDTOs = await fileReader.GetOrdersDTOAsync(path);
            var orderDtoFromFileToDb = scope.ServiceProvider.GetService<OrderDTOFromFileToDB>();
            await orderDtoFromFileToDb.InsertOrdersDTOs(orderDTOs);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _watcher.Created -= OnCreated;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}
