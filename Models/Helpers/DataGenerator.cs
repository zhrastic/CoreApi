using System;
using Microsoft.Extensions.DependencyInjection;
using CoreApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreApi
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>();
            using (var context = new TodoContext(options)) {
                if (context.TodoItems.Any()) {
                    return ;
                }

                context.TodoItems.AddRange(new TodoItem() { Id = 1, Name = "Pero" },
                                           new TodoItem() { Id = 2, Name = "Štef" },
                                           new TodoItem() { Id = 3, Name = "Jura" },
                                           new TodoItem() { Id = 4, Name = "Božo" },
                                           new TodoItem() { Id = 5, Name = "Luka" },
                                           new TodoItem() { Id = 6, Name = "Peđa" },
                                           new TodoItem() { Id = 7, Name = "Zoran" },
                                           new TodoItem() { Id = 8, Name = "Marko" });

                context.SaveChanges();
            }
        }

    }
}
