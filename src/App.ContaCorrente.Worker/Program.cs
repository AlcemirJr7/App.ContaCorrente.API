using App.ContaCorrente.Worker.Jobs;
using Quartz;


IHost host = Host.CreateDefaultBuilder(args)    
    .ConfigureServices((hostContext, services) =>
    {        
               
        //services.AddHostedService<Worker>();        

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();

            var jobKey = new JobKey(Guid.NewGuid().ToString());

            q.AddJob<MyJob>(o => o.WithIdentity(jobKey));

            q.AddTrigger(o =>
            {
                o.ForJob(jobKey)
                .WithIdentity(Guid.NewGuid().ToString())
                .WithCronSchedule("0/10 * * * * ?");
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        });


    })
    .Build();


await host.RunAsync();
