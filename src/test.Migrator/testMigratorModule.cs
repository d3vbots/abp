using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using test.Configuration;
using test.EntityFrameworkCore;
using test.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace test.Migrator;

[DependsOn(typeof(testEntityFrameworkModule))]
public class testMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public testMigratorModule(testEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(testMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            testConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(testMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
