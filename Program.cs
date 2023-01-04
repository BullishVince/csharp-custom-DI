var di = new CustomDependencyInjector();
di.Add<IAwesomeService, AwesomeService>();

var x = di.Get<IAwesomeService>();
Console.WriteLine(x.GetText());

di.Dispose<IAwesomeService>();
var y = di.Get<IAwesomeService>(); //return [Unhandled exception. System.InvalidOperationException: Type is not dependency injected]