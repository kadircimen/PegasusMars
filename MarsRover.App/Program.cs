using Microsoft.Extensions.DependencyInjection;
using System;
using MarsRover.Actions.Interfaces;
using MarsRover.Services.Interfaces;
using MarsRover.Services.Services;
namespace MarsRover.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var areas = Console.ReadLine();
                var location = Console.ReadLine();
                var moveDirection = Console.ReadLine();

                var services = new ServiceCollection();
                services.AddSingleton<IAction, Actions.Action>();
                services.AddSingleton<IMove, MoveAction>();
                var serviceProvider = services.BuildServiceProvider(true);
                var _appService = serviceProvider.GetService<IAction>();
                var _mover = serviceProvider.GetService<IMove>();

                var coordinates = _appService.BringTheAction(_mover, areas, location, moveDirection);
                Console.WriteLine($"{coordinates.X} {coordinates.Y} {coordinates.Directions}");
            }
            catch
            {
                Console.WriteLine("HATALI DEĞER GİRİLDİ");
            }
        }
    }
}
