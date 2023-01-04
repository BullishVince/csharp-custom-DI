var di = new CustomDependencyInjector();
di.Register<IAwesomeService, AwesomeService>();

var x = di.Resolve<IAwesomeService>();
Console.WriteLine(x.GetText());
